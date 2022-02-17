using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using MyProject.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class ProjectPage : ContentPage
    {
        public ProjectPage()
        {
            InitializeComponent();
            UpdateList();

        }
        private async void project_List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new InformationProjectPage((ProjectModel)e.Item));
        }

        protected override void OnAppearing()
        {
            UpdateList();
            base.OnAppearing();
        }

        public void UpdateList()
        {
            ProjectsLstview.ItemsSource = null;
            ProjectsLstview.ItemsSource = App.Db.GetProjects();
        }
        

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage());
            //await App.GlobalNavigation.PushAsync(new AddProjectPage(), true);

        }
    }
}