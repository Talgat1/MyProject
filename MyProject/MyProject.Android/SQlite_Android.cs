using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyProject.db;
using System.IO;

namespace MyProject.Droid
{
    public class SQlite_Android : ISqlite
    {
        public SQlite_Android() { }
        public string GetDatabasePath(string filename)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, filename);
            return path;
        }
    }
}