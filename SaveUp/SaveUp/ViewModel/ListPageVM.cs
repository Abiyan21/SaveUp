using Newtonsoft.Json;
using SaveUp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using SaveUp.View;
using System.Reflection;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SaveUp.ViewModel
{
    public class ListPageVM : INotifyPropertyChanged
    {

        private ObservableCollection<MainModel> data;
        public ObservableCollection<MainModel> Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(); }
        }
        public ListPageVM()
        {
            var assembly = typeof(ListPageVM).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SaveUp.eintraege.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
                data = new ObservableCollection<MainModel>(dataList);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
