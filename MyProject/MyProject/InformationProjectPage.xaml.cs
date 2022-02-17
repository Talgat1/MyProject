using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class InformationProjectPage 
    {
        readonly ProjectModel project;
        public static string NameTitle;
        public InformationProjectPage(ProjectModel project)
        {
            this.project = project;
            NameTitle = project.Name;
            InitializeComponent();
            InfoProj();
        }

        protected override void OnAppearing()
        {
            InfoProj();
            base.OnAppearing();
        }

        public void InfoProj()
        {
            ProjectDes.Text = project.Description;
            Addres.Text = project.Adress;
            Email.Text = project.Email;
            Telephone.Text = project.PhoneNum;
            img.Source = project.Image;
        }
        private async void Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProjectPage(project));
        }
    }
}