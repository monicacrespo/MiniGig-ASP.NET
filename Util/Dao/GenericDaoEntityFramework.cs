using System;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

using Util.Exceptions;
using Microsoft.Practices.Unity;


namespace Util.Dao
{
    /// <summary>
    /// Important feature in generics is the ability to use constraints, 
    /// which can restrict what types are allowed. 
    /// Creation of a class that supports any type that meets a certain interface (IEntityWithKey). 
    /// In this case, just use the new where keyword.
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <typeparam name="PK"></typeparam>
    public class GenericDaoEntityFramework<E, PK> : IGenericDao<E, PK>
        where E : IEntityWithKey
    {

        // entityClass is set in the constructor of this class
        private Type entityClass;

        // Context must be set by means of Context property
        private ObjectContext context;

        private String entityContainerName;

        public GenericDaoEntityFramework()
        {
            this.entityClass = typeof(E);
        }

        [Dependency]
        public ObjectContext Context
        {
            set
            {
                // The value of the Context property is established
                context = value;

                entityContainerName = (context.MetadataWorkspace.
                    GetItems<EntityContainer>(DataSpace.CSpace))[0].Name;

                context.DefaultContainerName = entityContainerName;
                
                context.MetadataWorkspace.LoadFromAssembly(
                    entityClass.Assembly);
            }
            get
            {
                return context;
            }

        }

        /// <summary>
        /// Creates the entity key. It is needed to get primary key field name
        /// from metadata.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The EntityKey</returns>
        public EntityKey CreateEntityKey(PK id)
        {

            EntityType entityType =
                (EntityType)context.MetadataWorkspace.GetType(entityClass.Name,
                    entityClass.Namespace, DataSpace.CSpace);

            /* We assume that the DAO works only with single field primary 
             * key classes
             */
            String primaryKeyFieldName =
                ((EntityType)entityType).KeyMembers.First().ToString();

            EntityKey entityKey = 
                new EntityKey(GetQualifiedEntitySetName(entityClass.Name), 
                    primaryKeyFieldName, id);

            return entityKey;

        }

        /// <summary>
        /// Returns the qualified EntitySet name (the EntityContainer name plus 
        /// the EntitySet name) for a given entityClassName.
        /// </summary>
        /// <param name="entityClassName">Type name of an entity</param>
        /// <returns>The EntitySet name</returns>
        private String GetQualifiedEntitySetName(String entityClassName)
        {
            EntityContainer container = context.MetadataWorkspace.
                GetEntityContainer(context.DefaultContainerName, 
                DataSpace.CSpace);
            EntitySetBase entitySet = container.BaseEntitySets.Where(item =>
                item.ElementType.Name.Equals(entityClassName)).FirstOrDefault();
            return (entityContainerName + "." + entitySet.Name);
        }

        #region IGenericDao<E> Members

        public void Create(E entity)
        {
            /* Adds the object to the object context. The entity's EntityState 
             * will be set to Added. Therefore, when SaveChanges is called, it 
             * will be clear to the Entity Framework that this entity needs to 
             * be inserted into the database.
             */
            context.AddObject(GetQualifiedEntitySetName(entityClass.Name), 
                entity);

            /* Persists back to the database all of the changes made to 
             * the entities. By default, the SaveChanges method calls the method
             * AcceptAllChanges after it has performed the database 
             * modifications. AcceptAllChanges pushes the current values of 
             * every attached entity into the original values and then changes 
             * their EntityState to Unchanged.
             */
            context.SaveChanges();
            
        }

        /// <exception cref="InstanceNotFoundException"/>
        public E Find(PK id)
        {
            EntityKey entityKey = this.CreateEntityKey(id);

            try
            {
                E result = (E)context.GetObjectByKey(entityKey);
                return result;
            }
            catch (ObjectNotFoundException)
            {
                throw new InstanceNotFoundException(id, entityClass.FullName);

            }

        }

        public Boolean Exists(PK id)
        {
            Boolean objectFound = true;

            EntityKey entityKey = this.CreateEntityKey(id);

            try
            {
                object result = context.GetObjectByKey(entityKey);
            }
            catch (ObjectNotFoundException)
            {
                objectFound = false;
            }

            return objectFound;

        }

        public void Update(E entity)
        {
            // Last updates are sent to database
            context.Refresh(RefreshMode.ClientWins, entity);
            context.SaveChanges();
        }

        /// <exception cref="InstanceNotFoundException"/>
        public void Remove(PK id)
        {
            E objectToRemove = default(E);

            try
            {
                // First we need to find the object
                objectToRemove = Find(id);
                context.DeleteObject(objectToRemove);
                context.SaveChanges();
            }
            catch (InstanceNotFoundException)
            {
                throw;
            }
            catch (OptimisticConcurrencyException)
            {
                context.Refresh(RefreshMode.ClientWins, objectToRemove);
                context.DeleteObject(objectToRemove);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new InstanceNotFoundException(id, entityClass.FullName);
            }
        }

        #endregion

    }

}