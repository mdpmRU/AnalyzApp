using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnalyzApp.Models
{
    public class Channel
    {
        public string name;
        public bool isHot;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;

            }
        }
        public bool IsHot
        {
            get { return isHot; }
            set
            {
                isHot = value;

            }
        }

    }
}
