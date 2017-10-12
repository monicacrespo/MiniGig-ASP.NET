using System;
using System.Collections.Generic;
using Model.GigMusicTypeVo;

namespace Model.GigFacade
{
    public interface IGigService
    {      
        /// <summary>
        /// Creates a gig.
        /// </summary>
        /// <param name="gig">The gig.</param>
        /// <returns>The gig created</returns>
        /// <exception cref="InternalErrorException"/>          
        Gig CreateGig(Gig gig);

        /// <summary>
        /// Finds the gig specified by <c>gigIdentifier</c>.
        /// </summary>
        /// <param name="gigIdentifier">The gig identifier.</param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="InternalErrorException"/>
        Gig FindGig(int gigIdentifier);


        /// <summary>
        /// Removes the specified <c>GIG</c>.
        /// </summary>
        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="InternalErrorException"/>
        void RemoveGig(int gigIdentifier);

        /// <summary>
        /// Returns a collection of <c>Gig</c> objects
        /// made between two dates. If the venue
        /// has no gigs, a collection of zero elements is returned.
        /// By consistency with <see>GigVO</see>, the search is
        /// executed without taking into account the millisecond field
        /// in the dates passed as parameters.
        /// </summary>
        /// <param name="startDate">The older date of the gigs to be
        /// returned (including this date)</param>
        /// <param name="endDate">The newer date of the gigs to be
        /// returned (including this date).</param>
        /// <param name="startIndex">The index (starting from 1) of the first
        /// object to return.</param>
        /// <param name="count">The maximum number of objects to return.</param>
        /// <returns>
        /// The collection of <c>GigVO</c> objects.
        /// </returns>
        /// <exception cref="InternalErrorException"/>
        List<Gig> FindGigsByDate(DateTime startDate, DateTime endDate, int startIndex, int count);

        /// <summary>
        /// Returns the number of gigs made between two dates.
        /// </summary>        
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>the number of gigs</returns>
        /// <exception cref="InstanceNotFoundException"/>
        int GetNumberOfGigsByDate(DateTime startDate, DateTime endDate);
        
        /// <summary>
        /// Returns a collection of <c>MusicType</c> objects
        /// </summary>
        /// <returns></returns>
        List<MusicType> GetMusicTypes();

        /// <summary>
        /// Finds the music specified by <c>musicTypeIdentifier</c>
        /// </summary>
        /// <param name="musicTypeIdentifier"></param>
        /// <returns></returns>
        MusicType FindMusicType(byte musicTypeIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate">The older date of the gigs to be
        /// returned (including this date)</param>
        /// <param name="endDate">The newer date of the gigs to be
        /// returned (including this date).</param>
        /// <param name="startIndex">The index (starting from 1) of the first
        /// object to return.</param>
        /// <param name="count">The maximum number of objects to return.</param>
        /// <returns>
        /// The collection of <c>GigWithMusicType</c> objects.
        /// </returns>
        List<GigWithMusicType> GetGigsWithMusicType(DateTime startDate, DateTime endDate, int startIndex, int count);
        List<GigWithMusicType> GetGigsWithMusicType();
    }
}
