using RodaDaVidaShared.Contracts;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Repositories
{
    public class AreaRepository
    {
        Database db = null;

        public AreaRepository(SQLiteConnection conn)
        {
            db = new Database(conn);
        }

        public Area GetArea(int id)
        {
            return db.GetArea(id);
        }

        public IEnumerable<Area> GetAreas()
        {
            return db.GetAreas();
        }

        public int SaveArea(Area area)
        {
            return db.SaveArea(area);
        }

        public int DeleteArea(int id)
        {
            return db.DeleteArea(id);
        }
    }
}
