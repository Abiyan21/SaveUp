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

namespace SaveUp.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private ObservableCollection<MainModel> _mainModels = new ObservableCollection<MainModel>();
        public ObservableCollection<MainModel> MainModels
        {
            get { return _mainModels; }
            set { _mainModels = value; OnPropertyChanged(); }
        }
        public float Geld { get; set; }
        public string Detail { get; set; }
        public string Datum { get; set; }
        public string message {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public Command Einfügen
        {
            get
            {
                return new Command(() =>
                {
                    // Data ins Json
                    

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
