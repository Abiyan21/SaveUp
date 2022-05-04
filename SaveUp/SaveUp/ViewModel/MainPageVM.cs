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
    public class MainPageVM : ViewModelBase
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
                    AddToList();
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

        void AddToList()
        {
            _mainModels.Clear();
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            var json = File.ReadAllText(file);
            List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
            var data = new ObservableCollection<MainModel>(dataList);
            _mainModels = data;

            Datum = DateTime.Now.ToString("dd.MM.yyyy");
            _mainModels.Add(DModel);

            string input = JsonConvert.SerializeObject(_mainModels);
            File.WriteAllText(file, input);

            //var assembly = typeof(ListPageVM).GetTypeInfo().Assembly;
            //FileStream stream = new FileStream("SaveUp.Resources.eintraege.json", FileMode.OpenOrCreate, FileAccess.Write);
            //Stream stream = assembly.GetManifestResourceStream("SaveUp.Resources.eintraege.json");
        }
    }
}
