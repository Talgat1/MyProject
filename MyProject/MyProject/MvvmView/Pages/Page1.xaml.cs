using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Models;
using MyProject.MVVMmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject.MvvmView.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1(Project project)
        {
            InitializeComponent();

        }
    }
}