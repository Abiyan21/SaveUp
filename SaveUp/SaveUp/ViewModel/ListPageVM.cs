using Newtonsoft.Json;
using SaveUp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using SaveUp.View;
using System.Reflection;
using System.Text;

namespace SaveUp.ViewModel
{
    public class ListPageVM
    {
        private ObservableCollection<MainModel> data;
        public ListPageVM()
        {
            var assembly = typeof(ListPageVM).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SaveUp.eintraege.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
                data = new ObservableCollection<MainModel>(dataList);
                LW.ItemsSource = data;
            }
        }
    }
}
