using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;

namespace ClipboardManager.Classes.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _dataFileName = @"ClipData.xml";
        DataTable _clipDataTable = new DataTable();
        private ObservableCollection<ClipboardItem> _clipboards;

        public ViewModel()
        {
            if (_clipboards == null)
            {
                _clipboards = new ObservableCollection<ClipboardItem>();
                _clipboards.CollectionChanged += _clipboards_CollectionChanged;
            }

            InitDataTable();
            ReadDataFile();
        }

        private void _clipboards_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < _clipboards.Count; i++)
                _clipboards[i].Index = i + 1;
        }

        public ObservableCollection<ClipboardItem> Clipboards
        {
            get { return _clipboards; }
            set
            {
                _clipboards = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initialize Data Table considering you have only 1 column data.
        /// If you have more then you need to create more columns
        /// </summary>
        private void InitDataTable()
        {
            _clipDataTable = new DataTable();
            _clipDataTable.Columns.Add("ClipHeader");
            _clipDataTable.AcceptChanges();
        }

        //the clipboard Data is saved in xml file.
        private void WriteDataFile()
        {
            DataSet ClipDataSet = new DataSet();
            ClipDataSet.Tables.Add(_clipDataTable);
            ClipDataSet.WriteXml(_dataFileName);
        }

        /// <summary>
        /// Tf file exits then read the xml file and add it
        /// to the Collection, which will be reflected in UI. 
        /// </summary>
        private void ReadDataFile()
        {
            DataSet ClipDataSet = new DataSet();
            if (File.Exists(_dataFileName))
            {
                ClipDataSet.ReadXml(_dataFileName);

                int t = ClipDataSet.Tables.Count;
                if (t > 0)
                {
                    foreach (DataRow item in ClipDataSet.Tables[0].Rows)
                    {
                        Clipboards.Add(new ClipboardItem { Text = Convert.ToString(item["ClipHeader"]) });
                    }
                }
            }
        }

        private void WindowCloseCommadn(object o)
        {
            foreach (var item in Clipboards)
            {
                DataRow dataRow = _clipDataTable.NewRow();
                dataRow["ClipHeader"] = item.Text;
                _clipDataTable.Rows.Add(dataRow);
            }

            WriteDataFile();
        }
    }
}
