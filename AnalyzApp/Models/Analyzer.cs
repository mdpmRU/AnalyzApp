using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AnalyzApp.Models;

namespace AnalyzApp.Models
{
    public class Analyzer: INotifyPropertyChanged
    {
        private string name;
        private string type;
        private int measureInterval;
        private ObservableCollection <Channel> channels;
        Channel selectedChannel;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public int MeasureInterval
        {
            get { return measureInterval; }
            set
            {
                measureInterval = value;
                OnPropertyChanged("MeasureInterval");
            }
        }

        public ObservableCollection<Channel> Channels
        {
            get { return channels; }
            set
            {
                channels = value;
                OnPropertyChanged("Channels");
            }
        }

        public Channel SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
                OnPropertyChanged("SelectedChannel");
            }
        }

        //Кнопки для Channel 
        private RelayCommand addChannel;
        public RelayCommand AddChannel
        {
            get
            {
                return addChannel ??
                  (addChannel = new RelayCommand(obj =>
                  {
                      //Channel channel = obj as Channel;
                      //if (channel != null)
                      //{
                      //    SelectedAnalyzer.Channels.Insert(0, channel);
                      //}
                      Channel channel = new Channel();
                      Channels.Insert(0, channel);
                  }
                  ));
            }
        }

        private RelayCommand removeChannel;

        public RelayCommand RemoveChannel
        {
            get
            {
                return removeChannel ??
                  (removeChannel = new RelayCommand(obj =>
                  {
                      Channel channel = obj as Channel;
                      if (channel != null)
                      {
                          Channels.Remove(channel);
                      }
                  },
                 (obj) => Channels.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
