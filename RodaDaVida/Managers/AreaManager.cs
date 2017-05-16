using RodaDaVidaShared.Repositories;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Managers
{
    public class AreaManager
    {
        AreaRepository repository = null;

        public AreaManager(SQLiteConnection conn)
        {
            repository = new AreaRepository(conn);
        }

        public Area GetArea(int id)
        {
            return repository.GetArea(id);
        }

        public IEnumerable<Area> GetAreas()
        {
            return repository.GetAreas();
        }

        public int saveArea(Area area)
        {
            return repository.SaveArea(area);
        }

        public int deleteArea(int id)
        {
            return repository.DeleteArea(id);
        }
    }
}
