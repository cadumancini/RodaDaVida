using System;
using System.IO;
using Android.App;
using RodaDaVidaShared.Contracts;
using SQLite;

namespace RodaDaVidaAndroid
{
    [Application]
    public class RodaDaVida : Application
    {
        public static RodaDaVida Current { get; private set; }
        public DatabaseManager dataBaseManager { get; set; }
        SQLiteConnection conn;
        public int idUsuarioGeral;

        public RodaDaVida(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            idUsuarioGeral = 0;
            var sqliteFilename = "RodaDaVidaDB.db3";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            conn = new SQLiteConnection(path);

            dataBaseManager = new DatabaseManager(conn);
        }
    }
}