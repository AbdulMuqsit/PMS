using System.Linq;
using System.Windows;
using PMS.DataAccess;
using PMS.DataAccess.Repositories;

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
            PMSRepository repository = new PMSRepository();

            lstBox.ItemsSource = repository.Doctors.GetAll().ToList().Select(e=>e.name);
        }
    }
}
