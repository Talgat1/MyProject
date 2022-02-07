using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Reg(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        async void Vhod(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ProjectPage());
            await App.GlobalNavigation.PushAsync(new ProjectPage(), true);
        }
    }
}
