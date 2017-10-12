using System;
using System.Collections.Generic;
using Model.GigDao;
using Model.MusicTypeDao;
using Microsoft.Practices.Unity;
using Model.GigMusicTypeVo;
using Model.GigMusicTypeDao;
namespace Model.GigFacade
{
    public class GigService : IGigService
    {
        public GigService() { }

        [Dependency]
        public IGigDao GigDao { private get; set; }

        [Dependency]
        public IMusicTypeDao MusicTypeDao { private get; set; }

        [Dependency]
        public IGigWithMusicTypeDao GigMusicTypeDao { private get; set; }

        #region IGigService Members


        #endregion

        public Gig CreateGig(Gig gig)
        {
            GigDao.Create(gig);
            return gig;
        }

        public Gig FindGig(int gigIdentifier)
        {
            Gig gig = null;
            gig = GigDao.Find(gigIdentifier);

            return gig;
        }

        public void RemoveGig(int gigIdentifier)
        {
            GigDao.Remove(gigIdentifier);
        }

        public List<Gig> FindGigsByDate(DateTime startDate, DateTime endDate,
            int startIndex, int count)
        {

            List<Gig> gigs = GigDao.FindByDate(startDate, endDate, startIndex, count);

            return gigs;
        }

        public int GetNumberOfGigsByDate(DateTime startDate, DateTime endDate)
        {
            /* Return count. */
            return GigDao.GetNumberOfGigs(startDate, endDate);

        }

        public void UpdateGig(Gig gig)
        {
            GigDao.Update(gig);
        }

        public List<MusicType> GetMusicTypes()
        {
            List<MusicType> types = MusicTypeDao.GetMusicTypes();

            return types;
        }

        public MusicType FindMusicType(byte musicTypeIdentifier)
        {
            MusicType musicType = null;
            musicType = MusicTypeDao.Find(musicTypeIdentifier);

            return musicType;
        }


        public List<GigWithMusicType> GetGigsWithMusicType(DateTime startDate,
            DateTime endDate, int startIndex, int count)
        {

            List<GigWithMusicType> gigsMusic = GigMusicTypeDao.GetGigsWithMusicType(startDate, endDate, startIndex, count);

            return gigsMusic;
        }


        /// <summary>
        ///  Returns all the <c>GigWithMusicTypeDao</c> objects stored in the database.
        /// </summary>
        /// <returns>The collection of <c>GigWithMusicTypeDao</c> objects.</returns>
        public List<GigWithMusicType> GetGigsWithMusicType()
        {
            List<GigWithMusicType> gigsMusic = GigMusicTypeDao.GetGigsWithMusicType();

            return gigsMusic;
        }


    }
}