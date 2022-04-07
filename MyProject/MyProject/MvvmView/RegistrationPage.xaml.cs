using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.MVVMmodel;  
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel { Navigation = this.Navigation };
        }
    }
}