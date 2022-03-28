using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzApp.Models;

namespace AnalyzApp
{
    public interface IFileService
    {
        ObservableCollection<Analyzer> Open(string filename);
        void Save(string filename, ObservableCollection<Analyzer> analyzersList);
    }
}
