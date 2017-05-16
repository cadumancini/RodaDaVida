using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace RodaDaVidaShared.Tabelas
{
    public class UsuarioArea
    {
        public UsuarioArea()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Usuario))]
        public int UsuarioID { get; set; }

        [ForeignKey(typeof(Area))]
        public int AreaID { get; set; }

        public double Nota { get; set; }
        public DateTime DataUltTarefa { get; set; }
    }
}
