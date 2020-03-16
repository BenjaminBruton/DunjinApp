using System;
using Dunjin.Persistence;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Dunjin.Droid.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Dunjin.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string dbName = "DunjinDB.sqlite";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(documentsPath, dbName);

            return new SQLiteAsyncConnection(path);
        }
        
    }
}
