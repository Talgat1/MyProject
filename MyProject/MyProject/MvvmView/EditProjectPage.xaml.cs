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
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectViewModel ViewModel { get; private set; }

        public EditProjectPage(EditProjectViewModel proj)
        {
            InitializeComponent();
            ViewModel = proj;
            this.BindingContext = proj;
        }
    }
}