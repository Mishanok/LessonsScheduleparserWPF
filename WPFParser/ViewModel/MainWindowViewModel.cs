using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPFParser.Model;
using WPFParser.Model.Habra;
using WPFParser.Model.NuLP;

namespace WPFParser.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region NumericUpDown
        int numValueStart;
        int numValueEnd;

        public int NumValueStart
        {
            get { return numValueStart; }
            set {
                if(value >= 0)
                numValueStart = value;
                else { numValueStart = 0; }
                OnPropertyChanged("NumValueStart");
            }
        }
        public int NumValueEnd
        {
            get { return numValueEnd; }
            set
            {
                if (value >= 0)
                    numValueEnd = value;
                else { numValueEnd = 0; }
                OnPropertyChanged("NumValueEnd");
            }
        }

        public ICommand NumUpStartCommand { get; private set; }
        public ICommand NumDownStartCommand { get; private set; }
        public ICommand NumUpEndCommand { get; private set; }
        public ICommand NumDownEndCommand { get; private set; }

        void UpClickStart(object obj) { NumValueStart++; }
        void DownClickStart(object obj) { NumValueStart--; }
        void UpClickEnd(object obj) { NumValueEnd++; }
        void DownClickEnd(object obj) { NumValueEnd--; }
        #endregion

        public ObservableCollection<string> Titles { get; set; }

        public ICommand StartParseCommand { get; private set; }
        public ICommand EndParseCommand { get; private set; }

        ParserWorker<string[]> parser;

        public MainWindowViewModel()
        {
            NumValueStart = 0;
            NumUpStartCommand = new DelegateCommand(UpClickStart);
            NumDownStartCommand = new DelegateCommand(DownClickStart);
            NumUpEndCommand = new DelegateCommand(UpClickEnd);
            NumDownEndCommand = new DelegateCommand(DownClickEnd);
            StartParseCommand = new DelegateCommand(StartParse);
            EndParseCommand = new DelegateCommand(EndParse);
            Titles = new ObservableCollection<string>();
            parser = new ParserWorker<string[]>(new ScheduleParser());
            parser.OnNewData += Parser_OnNewData;
            parser.OnComplete += Parser_OnComplete;
        }

        private void Parser_OnComplete(object obj)
        {
            MessageBox.Show("All work done!");
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach(var a in arg2) { Titles.Add(a); }
        }

        private void StartParse(object obj)
        {
            Titles.Clear();
            parser.ParserSettings = new ScheduleParserSettings();
            parser.Start();
        }

        private void EndParse(object obj)
        {
            parser.Abort();
        }

    }
}
