using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnalyzApp.Models
{
    public class Channel: INotifyPropertyChanged
    {
        public string name;
        public bool isHot;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public bool IsHot
        {
            get { return isHot; }
            set
            {
                isHot = value;
                OnPropertyChanged("IsHot");
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
