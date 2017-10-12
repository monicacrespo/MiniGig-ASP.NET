using System;
using System.Collections.Generic;
using System.Linq;
using Util.Dao;
using System.Data.Objects;


namespace Model.GigDao
{
    /// <summary>
    /// Used to implement persistence layer to create and read 
    /// instances of the Gig Entity Class. 
    /// The data access and storage is done using the ORM Entity Framework.
    /// </summary>
    class GigDaoEntityFramework :
        GenericDaoEntityFramework<Gig, Int32>, IGigDao
    {

        #region IGigDao Members

        public List<Gig> FindByDate(DateTime startDate, DateTime endDate, 
                                    int startIndex, int count)
        {
            #region Using Linq.
            
            ObjectSet<Gig> gigs = Context.CreateObjectSet<Gig>();
            var result =
                (from a in gigs                 
                 where a.date >= startDate
                 && a.date <= endDate
                 orderby a.gigId
                 select a).Skip(startIndex).Take(count).ToList();
            return result;

            #endregion
        }

        public int GetNumberOfGigs(DateTime startDate, DateTime endDate)
        {

            #region Using Linq.

            ObjectSet<Gig> gigs = Context.CreateObjectSet<Gig>();

            int result = 
                (from a in gigs
                 where a.date >= startDate
                 && a.date <= endDate
                 orderby a.gigId
                 select a).Count();

            return result;
            
            #endregion
          
         
        }

        #endregion
    }
}
