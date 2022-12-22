using Books.Baza;
using Books.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Books.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public  Service service { get; set; }
        public AddPage(Service cService)
        {
            InitializeComponent();
            service = cService;
            this.DataContext = this;

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (service.ID == 0)
            {
                Class1.db.Service.Add(service);
                Class1.db.SaveChanges();
                MessageBox.Show("Данные были успешно добавлены!");
                NavigationService.GoBack();
            }
            else if (service.ID != 0)
            {
                Class1.db.SaveChanges();
                MessageBox.Show("Данные были успешно изменены!");
                NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
