using System;
using System.Collections.Generic;
using Util.Dao;
using Model.GigMusicTypeVo;
namespace Model.GigMusicTypeDao
{
    public interface IGigWithMusicTypeDao : IGenericDao<Gig, Int32>
    {
        List<GigWithMusicType> GetGigsWithMusicType(DateTime startDate, DateTime endDate,
          int startIndex, int count);
        List<GigWithMusicType> GetGigsWithMusicType();

    }
}
