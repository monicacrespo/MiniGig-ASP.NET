using System;
using System.Collections.Generic;
using System.Linq;
using Util.Dao;
using System.Data.Objects;


namespace Model.MusicTypeDao
{
    /// <summary>
    /// Used to implement persistence layer to create and read 
    /// instances of the MusicType Entity Class. 
    /// The data access and storage is done using the ORM Entity Framework.
    /// </summary>
    class MusicTypeDaoEntityFramework :
        GenericDaoEntityFramework<MusicType, byte>, IMusicTypeDao
    {

        #region IMusicTypeDao Members

        public List<MusicType> GetMusicTypes()
        {

            #region Using Linq.

            ObjectSet<MusicType> types = Context.CreateObjectSet<MusicType>();
            //var result = types.ToList();
          
            var result =
                 from a in types
                 orderby a.typeId
                 select a;

            return result.ToList();

            #endregion

        }

       

        #endregion
    }
}
