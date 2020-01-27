using System.Collections.ObjectModel;
using System.Windows;

namespace FlatStyle.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //int a = 0;
            //int b = 1 / a;
            Dataset dataset1 = new Dataset("Daryl", "MacDavitt", "dmacdavitt0@fema.gov", "Male", "165.132.34.62");
            Dataset dataset2 = new Dataset("Sherwood", "Conan", "sconan1@dell.com", "Male", "34.97.62.115");
            Dataset dataset3 = new Dataset("Brooke", "Cluatt", "bcluatt2@bigcartel.com", "Female", "49.208.237.237");
            Dataset dataset4 = new Dataset("Esdras", "McIlmurray", "emcilmurray3@apache.org", "Male", "5.231.15.194");
            Dataset dataset5 = new Dataset("Ebony", "Quin", "equin4@purevolume.com", "Female", "6.13.102.6");
            Dataset dataset6 = new Dataset("Ranice", "Rivlin", "rrivlin5@sun.com", "Female", "223.213.173.216");
            Dataset dataset7 = new Dataset("Vinnie", "Abbs", "vabbs6@ted.com", "Male", "0.1.251.52");
            Dataset dataset8 = new Dataset("Josh", "Fenne", "jfenne7@rediff.com", "Male", "188.236.64.38");
            Dataset dataset9 = new Dataset("Leeann", "Challicombe", "lchallicombe8@seattletimes.com", "Female", "5.146.64.20");
            Dataset dataset10 = new Dataset("Kalindi", "Righy", "krighy9@netvibes.com", "Female", "94.223.108.66");

            datagrid.ItemsSource = new ObservableCollection<Dataset>
            {
                dataset1,
                dataset2,
                dataset3 ,
                dataset4 ,
                dataset5 ,
                dataset6 ,
                dataset7 ,
                dataset8 ,
                dataset9 ,
                dataset10
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlatStyle.Style.ToggleNightMode();
            System.Windows.Controls.Primitives.ToggleButton button = ai;
        }
    }
}