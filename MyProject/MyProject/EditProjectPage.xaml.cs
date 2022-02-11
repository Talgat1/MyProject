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
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Удаление", "Вы точно хотите удалить проект?", "OK", "Отмена");
        }

        private void Edit_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Изменение", "Вы точно хотите изменить проект?", "OK", "Отмена");
        }
    }
}