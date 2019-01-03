using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ClipboardManager.Classes.ViewModel
{
    [XmlRoot("item")]
    public class ClipboardItem : INotifyPropertyChanged
    {
        private string _text { get; set; }
        
        private int _index { get; set; }
        private DateTime _time { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlElement("text")]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }

        public int Index
        {            
            get { return _index; }
            set
            {
                _index = value;
                NotifyPropertyChanged();
            }
        }

        [XmlElement("time")]
        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

