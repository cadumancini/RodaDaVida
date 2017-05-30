using SQLite;
using System;

namespace RodaDaVidaShared.Tabelas
{
    public class Usuario
    {
        public Usuario()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }

        public string Nome { get; set; }
    }
}
