using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProject.db;
using System.IO;


[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "MaterialIconsFont")]

namespace MyProject
{
    public partial class App : Application
    {
        public const string DB_NAME = "Aplus.mdf";
        public static CRUDOperation db;
        //public const string DB_NAME = "Aplus.mdf";

        public static INavigation GlobalNavigation { get; private set; }
        public static INavigation GlobalNavigation2 { get; private set; }
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

            //MainPage = new NavigationPage(new MainPage());

            var rootPage = new NavigationPage(new MainPage());
            var rootPage2 = new NavigationPage(new ProjectPage());

            GlobalNavigation = rootPage.Navigation;
            GlobalNavigation2 = rootPage2.Navigation;

            MainPage = rootPage;
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
