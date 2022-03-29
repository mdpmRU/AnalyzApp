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
        IFileService fileService;
        IDialogService dialogService;

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

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var analysers = fileService.Open(dialogService.FilePath);
                              Analyzers.Clear();
                              foreach (var p in analysers)
                                  Analyzers.Add(p);
                              //dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        // команда сохранения файла

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Analyzers);
                              //dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
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
        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Analyzers = new ObservableCollection<Analyzer>();
        }

    }
}
