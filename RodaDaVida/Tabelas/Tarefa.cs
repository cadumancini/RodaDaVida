using SQLite;
using System;

namespace RodaDaVidaShared.Tabelas
{
    public class Tarefa
    {
        public Tarefa()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }

        [Indexed]
        public int UsuarioAreaID { get; set; }

        public string NomeCurto { get; set; }
        public string Descricao { get; set; }
        public string Onde { get; set; }
        public DateTime Quando { get; set; }
        public string Como { get; set; }
        public bool Concluida { get; set; }
        public double PontosGanhos { get; set; }
    }
}
