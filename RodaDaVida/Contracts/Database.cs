using RodaDaVidaShared.Tabelas;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaDaVidaShared.Contracts
{
    public class Database
    {
        static object locker = new object();
        public SQLiteConnection database;
        public string path;

        public Database(SQLiteConnection conn)
        {
            database = conn;
            database.CreateTable<Usuario>();
            database.CreateTable<Area>();
            database.CreateTable<UsuarioArea>();
            database.CreateTable<Tarefa>();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            lock (locker)
            {
                return (from i in database.Table<Usuario>() select i).ToList();
            }
        }

        public IEnumerable<Area> GetAreas()
        {
            lock (locker)
            {
                return (from i in database.Table<Area>() select i).ToList();
            }
        }

        public IEnumerable<UsuarioArea> GetUsuariosAreas()
        {
            lock (locker)
            {
                //return (from i in database.Table<UsuarioArea>() select i).ToList();
                return database.Query<UsuarioArea>("SELECT USUARIOAREA.* " + 
                                                     "FROM USUARIOAREA, AREA " +
                                                    "WHERE USUARIOAREA.AREAID = AREA.ID " +
                                                    "ORDER BY AREA.CODIGO");
            }
        }

        public IEnumerable<UsuarioArea> GetUsuariosAreasADefinir()
        {
            lock (locker)
            {
                //return (from i in database.Table<UsuarioArea>() select i).ToList();
                return database.Query<UsuarioArea>("SELECT * " +
                                                     "FROM USUARIOAREA " +
                                                    "WHERE NOTA = 0 " +
                                                    "ORDER BY CODIGOAREA");
            }
        }

        public IEnumerable<UsuarioArea> GetUsuariosAreasByCodigo(int codigo)
        {
            lock (locker)
            {
                //return (from i in database.Table<UsuarioArea>() select i).ToList();
                return database.Query<UsuarioArea>("SELECT USUARIOAREA.* " +
                                                     "FROM USUARIOAREA, AREA " +
                                                    "WHERE USUARIOAREA.AREAID = AREA.ID " +
                                                      "AND AREA.CODIGO = " + codigo.ToString() + " " +
                                                    "ORDER BY AREA.CODIGO");
            }
        }

        public IEnumerable<Tarefa> GetTarefas()
        {
            lock (locker)
            {
                return (from i in database.Table<Tarefa>() select i).ToList();
            }
        }

        public Usuario GetUsuario(int id)
        {
            lock (locker)
            {
                return database.Table<Usuario>().FirstOrDefault(x => x.ID == id);
            }
        }

        public Area GetArea(int id)
        {
            lock (locker)
            {
                return database.Table<Area>().FirstOrDefault(x => x.ID == id);
            }
        }

        public UsuarioArea GetUsuarioArea(int id)
        {
            lock (locker)
            {
                return database.Table<UsuarioArea>().FirstOrDefault(x => x.ID == id);
            }
        }

        public Tarefa GetTarefa(int id)
        {
            lock (locker)
            {
                return database.Table<Tarefa>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveUsuario(Usuario usuario)
        {
            lock (locker)
            {
                if (usuario.ID != 0)
                {
                    database.Update(usuario);
                    return usuario.ID;
                }
                else
                    return database.Insert(usuario);
            }
        }

        public int SaveArea(Area area)
        {
            lock (locker)
            {
                if (area.ID != 0)
                {
                    database.Update(area);
                    return area.ID;
                }
                else
                    return database.Insert(area);
            }
        }

        public int SaveUsuarioArea(UsuarioArea usuarioArea)
        {
            lock (locker)
            {
                if (usuarioArea.ID != 0)
                {
                    database.Update(usuarioArea);
                    return usuarioArea.ID;
                }
                else
                    return database.Insert(usuarioArea);
            }
        }

        public int SaveTarefa(Tarefa tarefa)
        {
            lock (locker)
            {
                if (tarefa.ID != 0)
                {
                    database.Update(tarefa);
                    return tarefa.ID;
                }
                else
                    return database.Insert(tarefa);
            }
        }

        public int DeleteUsuario(int id)
        {
            lock(locker)
            {
                return database.Delete<Usuario>(id);
            }
        }

        public int DeleteArea(int id)
        {
            lock (locker)
            {
                return database.Delete<Area>(id);
            }
        }

        public int DeleteUsuarioArea(int id)
        {
            lock (locker)
            {
                return database.Delete<UsuarioArea>(id);
            }
        }

        public int DeleteTarefa(int id)
        {
            lock (locker)
            {
                return database.Delete<Tarefa>(id);
            }
        }
    }
}
