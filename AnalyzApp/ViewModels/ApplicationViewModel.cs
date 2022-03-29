using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AnalyzApp.Models;
using System.Linq;
using System;

namespace AnalyzApp.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
    

        Analyzer selectedAnalyzer;

        public ObservableCollection<Analyzer> Analyzers { get; set; }
        public Analyzer SelectedAnalyzer
        {
            get { return selectedAnalyzer; }
            set
            {
                selectedAnalyzer = value;
                OnPropertyChanged("SelectedAnalyzer");
            }
        }


        //Кнопки для Analyzer 
        private RelayCommand addAnalyzer;
        public RelayCommand AddAnalyzer
        {
            get
            {
                return addAnalyzer ??
                  (addAnalyzer = new RelayCommand(obj =>
                  {
                      Analyzer analyzer = new Analyzer();
                      analyzer.Channels = new ObservableCollection<Channel>();
                      Analyzers.Insert(0, analyzer);
                      SelectedAnalyzer = analyzer;
                  }));
            }
        }
        private RelayCommand removeAnalyzer;
        public RelayCommand RemoveAnalyzer
        {
            get
            {
                return removeAnalyzer ??
                  (removeAnalyzer = new RelayCommand(obj =>
                  {
                      Analyzer analyzer = obj as Analyzer;
                      if (analyzer != null)
                      {
                          Analyzers.Remove(analyzer);
                      }
                  },
                 (obj) => Analyzers.Count > 0));
            }
        }
        
        //////////////////////////////////////////////////////////
        public ApplicationViewModel()
        {
            Analyzers = new ObservableCollection<Analyzer>();
        }
        public void ClearAnalyzers()
        {
            Analyzers.Clear();
        }
        public void AddAnalyzers(Analyzer analyzer)
        {
            Analyzers.Add(analyzer);
        }

    }
}
