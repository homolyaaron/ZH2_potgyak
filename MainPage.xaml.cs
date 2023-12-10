using System.Collections.ObjectModel;

namespace ZH2_elbasztadgyoker
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Mountain> Mountains { get; set; }
        public string nev { get; set; }
        public int magassag { get; set; }
        public bool megmaszva { get; set; }

        public MainPage()
        {
            Mountains = new ObservableCollection<Mountain>()
            {
                new Mountain { Name = "János-hegy", Height = 527, Megmaszva = true },
                new Mountain { Name = "Kis-Hárs-hegy", Height = 362, Megmaszva = false },
                new Mountain { Name = "Nagy-Hárs-hegy", Height = 454, Megmaszva = false },
                new Mountain { Name = "Hármashatár-hegy", Height = 495, Megmaszva = false }
            };
            InitializeComponent();
            BindingContext = this;                     
        }

        private void Selected_hegy(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Mountain mountain)
            {
                magassag = mountain.Height;
                OnPropertyChanged(nameof(magassag));
                nev = mountain.Name;
                OnPropertyChanged(nameof(nev));
                megmaszva = mountain.Megmaszva;
                OnPropertyChanged(nameof(megmaszva));
                ((ListView)sender).SelectedItem = null;
            }       
        }
    }
}
