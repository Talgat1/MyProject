using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyProject.db;
using Xamarin.Essentials;
using System.Diagnostics;
using System.IO;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProjectPage : ContentPage
    {
        public AddProjectPage()
        {
            InitializeComponent();
        }

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string impath;
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

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.db.SaveItem(new ProjectModel(ProjectNameTxt.Text, ProjectDescriptionTxt.Text, TelNumber1Txt.Text, EmailTxt.Text, AddressTxt.Text, impath));
                DisplayAlert("", "Проект успешно добавлен", "Ok");
            }
            catch
            {
                DisplayAlert("", "Не удалось добавить проект", "Ok");
            }

            Navigation.PopAsync();

        }
    }
}