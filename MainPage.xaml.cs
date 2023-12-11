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
                new Mountain { Name = "Nagy-Hárs-hegy", Height = 454, Megmaszva = true },
                new Mountain { Name = "Hármashatár-hegy", Height = 495, Megmaszva = false }
            };
            InitializeComponent();
            BindingContext = this;                     
        }

        //Listview-ból kiválasztott elem adatainak megjelenítése
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

        //Megmaszva állapot változtatása
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(Mountains is not null)
            {
                var selectedMountain = Mountains.FirstOrDefault(m => m.Name == nev);
                if (selectedMountain is not null)
                {
                    selectedMountain.Megmaszva = e.Value;
                }
            }
        }

        //minden megmászás törlése
        private void Button_Clicked(object sender, EventArgs e)
        {
            foreach (Mountain mountain in Mountains)
            {
                megmaszva = mountain.Megmaszva;
                if (megmaszva)
                {
                    mountain.Megmaszva = false;
                    OnPropertyChanged(nameof(megmaszva));
                }              
            }
        }
    }
}
