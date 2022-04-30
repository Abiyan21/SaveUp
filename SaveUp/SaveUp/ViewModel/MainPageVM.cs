using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using SaveUp.Model;
using System.Collections.ObjectModel;
using Android.Content.Res;
using SaveUp.View;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace SaveUp.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private MainModel DModel;
        private ObservableCollection<MainModel> _mainModels = new ObservableCollection<MainModel>();
        public ObservableCollection<MainModel> MainModels
        {
            get { return _mainModels; }
            set { _mainModels = value; OnPropertyChanged(); }
        }
        public MainPageVM()
        {
            DModel = new MainModel();
        }
        public float Geld
        {
            get { return DModel.Geld; }
            set
            {
                DModel.Geld = value; OnPropertyChanged(); 
            }
        }
        public string Detail
        {
            get { return DModel.Detail; }
            set
            {
                DModel.Detail = value; OnPropertyChanged();
            }
        }
        public string Datum
        {
            get { return DModel.Datum; }
            set
            {
                DModel.Datum = value; OnPropertyChanged();
            }
        }

        public Command Einfügen
        {
            get
            {
                return new Command(() =>
                {
                    //var assembly = typeof(ListPageVM).GetTypeInfo().Assembly;
                    //FileStream stream = new FileStream("SaveUp.Resources.eintraege.json", FileMode.OpenOrCreate, FileAccess.Write);
                    //Stream stream = assembly.GetManifestResourceStream("SaveUp.Resources.eintraege.json");
                 
                    Datum = DateTime.Now.ToString("dd/mm/yyyy");
                    _mainModels.Add(DModel);

                    var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
                    if (!File.Exists(file))
                    {
                        File.Create(file);
                    }
                        string data = JsonConvert.SerializeObject(_mainModels);
                        File.WriteAllText(file,data);
                });
            }
        }
       
        public Command Einträge
        {
            get
            {
                return new Command( () =>
                {
                    OpenListPage();
                });
            }
        }
        
        async void OpenListPage()
        {
            ListPageVM lpvm = new ListPageVM();
            await Application.Current.MainPage.Navigation.PushAsync(new ListPage());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
