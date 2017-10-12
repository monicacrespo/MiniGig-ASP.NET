using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Util.Dao;
using System.Data.Objects;
namespace Model.GigMusicTypeVo
{
    /// <summary>
    /// This class is a new object encapsulating the two classes Gig and MusicType into one.
    /// It is used to display the gig data and the music type description (not id) of the gig.
    /// </summary>
    public class GigWithMusicType
       
    {
        public string MusicType { get; set; }
        public Gig Gig { get; set; }

        #region Gig Properties Region
        //Add properties  to access the properties in Gig
        public Int32 gigId
        {
            get { return Gig.gigId; }
        }

        public string GigName
        {
            get { return Gig.name; }
        }

        public DateTime GigDate
        {
            get { return Gig.date; }
        }
      
        #endregion
              
    }
}
