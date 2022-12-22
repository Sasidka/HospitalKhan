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
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

       

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();

            newUser.Name = nameTxb.Text;
            newUser.Surname = surnameTxb.Text;
            newUser.Patronymic = patronymicTxb.Text;
            newUser.Age = ageTb.Text;
            newUser.Login = LoginTb.Text;
            newUser.Password = PasswordTb.Text;

            Class1.db.User.Add(newUser);
            Class1.db.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались!", "авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
