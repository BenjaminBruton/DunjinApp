using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Dunjin.Persistence;

namespace Dunjin.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Dunjin.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
