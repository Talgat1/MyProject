using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

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

        }

        private void project_List(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new InformationProjectPage());
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage());
            //await App.GlobalNavigation.PushAsync(new AddProjectPage(), true);

        }
    }
}