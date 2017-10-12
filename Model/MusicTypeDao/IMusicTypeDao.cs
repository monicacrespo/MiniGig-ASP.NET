using System.Collections.Generic;
using Util.Dao;

namespace Model.MusicTypeDao
{
    public interface IMusicTypeDao : IGenericDao<MusicType, byte>
    {
        List<MusicType> GetMusicTypes();
       
    }
}
