using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Util.Dao;
using System.Data.Objects;
using Model.GigMusicTypeVo;

namespace Model.GigMusicTypeDao
{
    /// <summary>
    /// This class is a new object encapsulating the two classes Gig and MusicType into one.
    /// It is used to display the gig data and the music type description (not id) of the gig.
    /// </summary>
    public class GigWithMusicTypeDao:
        GenericDaoEntityFramework<Gig, Int32>, IGigWithMusicTypeDao
    {            
        public List<GigWithMusicType> GetGigsWithMusicType(DateTime startDate, DateTime endDate,
            int startIndex, int count)
        {
           
            #region Using Linq.

            //var db = new Entities();
            ObjectSet<Gig> gigs = Context.CreateObjectSet<Gig>();
            ObjectSet<MusicType> types = Context.CreateObjectSet<MusicType>();

            var result1 =
                (from a in gigs
                 join t in types on a.typeId equals t.typeId
                 where a.date >= startDate
                 && a.date <= endDate
                 orderby a.gigId
                 select new GigWithMusicType ()
                        { 
                            Gig = a,
                            MusicType = t.description
                        }).Skip(startIndex).Take(count);
        
            return result1.ToList();

            #endregion
        }

        public List<GigWithMusicType> GetGigsWithMusicType()
        {

            #region Using Linq.

            //var db = new Entities();
            ObjectSet<Gig> gigs = Context.CreateObjectSet<Gig>();
            ObjectSet<MusicType> types = Context.CreateObjectSet<MusicType>();

            var result1 =
                (from a in gigs
                 join t in types on a.typeId equals t.typeId
                 orderby a.gigId
                 select new GigWithMusicType()
                 {
                     Gig = a,
                     MusicType = t.description
                 });

            return result1.ToList();

            #endregion
        }
    }
}
