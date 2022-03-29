using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzApp.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace AnalyzApp
{

    public class XMLFileService : IFileService
    {
        public List<Analyzer> Open(string filename)
        {
            List<Analyzer> analyzers = new List<Analyzer>();//объявление коллекций
            XDocument doc = XDocument.Load(filename);//Загружаем
            XElement root = doc.Element("Analyzers");
            foreach (XElement analyzer in root.Elements("Analyzer"))
            { 
                XAttribute AName = analyzer.Attribute("Name");
                XAttribute Type = analyzer.Attribute("Type");
                XAttribute MeasureInterval = analyzer.Attribute("MeasureInterval");
                ObservableCollection<Channel> channels = new ObservableCollection<Channel>();
                foreach (XElement channel in analyzer.Elements("Channel"))
                {
                    XAttribute CName = channel.Attribute("Name");
                    XAttribute IsHot = channel.Attribute("IsHot");
                    channels.Add(new Channel { Name = CName.Value, IsHot = (bool)IsHot });
                }
                analyzers.Add(new Analyzer { Name = AName.Value, Type = Type.Value, MeasureInterval = Int32.Parse(MeasureInterval.Value), Channels = channels });
            }


            return analyzers;
        }

        public void Save(string filename, List<Analyzer> analyzers)
        {
            XDocument xdoc = new XDocument();//объявили, что [xml документ
            XElement root = new XElement("Analyzers");//
            foreach (Analyzer item in analyzers)
            {
                XElement analyzerEL = new XElement("Analyzer");
                analyzerEL.Add(new XAttribute("Name", item.Name));
                analyzerEL.Add(new XAttribute("Type", item.Type));
                analyzerEL.Add(new XAttribute("MeasureInterval", item.MeasureInterval));
                foreach (Channel itemCh in item.Channels)
                {
                    XElement channelEL = new XElement("Channel");
                    channelEL.Add(new XAttribute("Name", itemCh.Name));
                    channelEL.Add(new XAttribute("IsHot", itemCh.IsHot));
                    analyzerEL.Add(channelEL);
                }
                root.Add(analyzerEL);
            }
            xdoc.Add(root);
            xdoc.Save(filename);
        }
    }
}
