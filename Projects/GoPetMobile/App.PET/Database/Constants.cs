using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.PET.Database
{
    public class Constants
    {
        public const string dbName = "GoPetDB.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, dbName);
            }
        }

    }
}