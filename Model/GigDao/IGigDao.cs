using System;
using System.Collections.Generic;
using Util.Dao;

namespace Model.GigDao
{
    public interface IGigDao : IGenericDao<Gig, Int32>
    {
        
        List<Gig> FindByDate(DateTime startDate, DateTime endDate,
            int startIndex, int count);

       
        int GetNumberOfGigs(DateTime startDate, DateTime endDate);
    }
}
