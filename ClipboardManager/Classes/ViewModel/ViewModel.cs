using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClipboardManager.Classes.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ClipboardItem> _clipboards;

        public ViewModel()
        {
            if (_clipboards == null)
            {
                _clipboards = new ObservableCollection<ClipboardItem>();
                _clipboards.CollectionChanged += _clipboards_CollectionChanged;
            }
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
    }
}
