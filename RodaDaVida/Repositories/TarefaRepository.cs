using RodaDaVidaShared.Contracts;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Repositories
{
    public class TarefaRepository
    {
        Database db = null;

        public TarefaRepository(SQLiteConnection conn)
        {
            db = new Database(conn);
        }

        public Tarefa GetTarefa(int id)
        {
            return db.GetTarefa(id);
        }

        public IEnumerable<Tarefa> GetTarefas(bool trazerConcluidas)
        {
            return db.GetTarefas(trazerConcluidas);
        }

        public int SaveTarefa(Tarefa tarefa)
        {
            return db.SaveTarefa(tarefa);
        }

        public int DeleteTarefa(int id)
        {
            return db.DeleteTarefa(id);
        }
    }
}
