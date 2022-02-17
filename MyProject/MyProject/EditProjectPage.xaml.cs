using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyProject.db;
using Xamarin.Essentials;
using System.IO;
using System.Diagnostics;


namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        string impath;
        readonly ProjectModel project;
        public EditProjectPage(ProjectModel project)
        {
            this.project = project;
            InitializeComponent();
            FillFields();
        }


        public void FillFields()
        {
            ProjectNameTxt.Text = project.Name;
            ProjectDescriptionTxt.Text = project.Description;
            TelNumber1Txt.Text = project.PhoneNum;
            EmailTxt.Text = project.Email;
            AddressTxt.Text = project.Adress;
            img.Source = project.Image;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Изменение", $"Вы точно хотите удалить {project.Name}?", "УДАЛИТЬ", "ОТМЕНА");
            if (result == true)
            {
                try
                {
                    App.db.DelProj(project.Id);
                }
                catch
                {
                    await DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
                }
                await Navigation.PopAsync();
            }
        }
        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void EditBtn_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Изменение", $"Вы точно хотите изменить {project.Name}?", "ИЗМЕНИТЬ", "ОТМЕНА");

            if (result)
            {
                project.Name = ProjectNameTxt.Text;
                project.Description = ProjectDescriptionTxt.Text;
                project.PhoneNum = TelNumber1Txt.Text;
                project.Email = EmailTxt.Text;
                project.Adress = AddressTxt.Text;
                project.Image = impath;

                try
                {
                    App.db.SaveItem(project);
                }
                catch
                {
                    await DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
                }

                await Navigation.PopAsync();
            }
        }
        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                impath = photo.FullPath;
                img.Source = impath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");
                impath = photo.FullPath;
                img.Source = impath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}