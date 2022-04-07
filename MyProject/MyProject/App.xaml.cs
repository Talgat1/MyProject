using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProject.db;
using System.IO;
using MyProject;
using MyProject.MvvmView;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "MaterialIconsFont")]

namespace MyProject
{
    public partial class App : Application
    {
        public const string DB_NAME = "project.db";
        public static CRUDOperation db;
        public static CRUDOperation Db
        {
            get
            {
                if (db == null)
                {
                    db = new CRUDOperation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
