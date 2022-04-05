using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.MVVMmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ListProjectViewModel { Navigation = this.Navigation };
        }
    }
}
