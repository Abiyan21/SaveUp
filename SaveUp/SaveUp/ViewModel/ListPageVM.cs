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
using Newtonsoft.Json.Linq;

namespace SaveUp.ViewModel
{
    public class ListPageVM : ViewModelBase
    {

        private ObservableCollection<MainModel> data;
        public ObservableCollection<MainModel> Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(); }
        }
        public ListPageVM()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            var json = File.ReadAllText(file);

            List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
            data = new ObservableCollection<MainModel>(dataList);
            


            /*
            var assembly = typeof(ListPageVM).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SaveUp.Resources.eintraege.json"));

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
                data = new ObservableCollection<MainModel>(dataList);
            }
            */
        }
    }
}
