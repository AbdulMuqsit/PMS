using System.Linq;
using System.Windows;
using PMS.DataAccess;

namespace PMS.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoctorRepository repository = new DoctorRepository();


           lstBox.ItemsSource = repository.GetAll().ToList().Select(e=>e.name);
        }
    }
}
