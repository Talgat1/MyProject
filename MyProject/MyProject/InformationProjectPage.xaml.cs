using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class InformationProjectPage : TabbedPage
    {
        public InformationProjectPage()
        {

            InitializeComponent();
        }

        private async void Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProjectPage());
        }
    }
}