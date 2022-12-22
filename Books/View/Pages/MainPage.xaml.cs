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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            filtrCmb.ItemsSource = Class1.db.Service.Select(item => item.Doctor).ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(new Service()));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listVieww.SelectedItem != null)
                {
                    NavigationService.Navigate(new AddPage(listVieww.SelectedItem as Service));
                }
                else
                {
                    throw new Exception("Выберите элемент для редактирования!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteCheck = (Service)listVieww.SelectedItem;
                if (MessageBox.Show("Вы действительно хотите удалить выбранный элемент? Данные будут удалены навсегда", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (deleteCheck != null)
                    {
                        Class1.db.Service.Remove(deleteCheck);
                        Class1.db.SaveChanges();
                        Page_Loaded(null, null);
                    }
                    else
                    {
                        throw new Exception("Для удаления выберите элемент из спика");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void filtrCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listVieww.ItemsSource = Class1.db.Service.Where(item => item.Doctor == filtrCmb.SelectedItem).ToList(); 
        }

        private void searchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            listVieww.ItemsSource = Class1.db.Service.Where(item => item.Doctor.Contains(searchTxb.Text) || item.PriceOfService.Contains(searchTxb.Text) 
            || item.CountOfService.Contains(searchTxb.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listVieww.ItemsSource = Class1.db.Service.ToList(); 
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }
    }
}
