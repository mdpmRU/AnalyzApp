using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AnalyzApp.Models;

namespace AnalyzApp.Models
{
    public class Analyzer
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
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }
        public int MeasureInterval
        {
            get { return measureInterval; }
            set
            {
                measureInterval = value;
            }
        }

        public ObservableCollection<Channel> Channels
        {
            get { return channels; }
            set
            {
                channels = value;
            }
        }

        public Channel SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
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


    }
}
