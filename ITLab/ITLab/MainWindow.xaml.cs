using ITLab.DB;
using ITLab.Model;
using ITLab.View;
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

namespace ITLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //регистрация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new RegistrationWindow();
            wnd.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new ITLabDBEntities())
            {
                int linq = db.Users.Count(q => q.Email == EmailBox.Text);
                if (linq == 0)
                {
                    MessageBox.Show("Зарегистрированного пользователя с такой почтой нет");
                    return;
                }
                var user = db.Users.FirstOrDefault(q => q.Email == EmailBox.Text);
                if (HashPassword.VerifyHashedPassword(user.HashPassword, PasswordBox.Password))
                {

                    StaticData.currentUser = user;
                    if (StaticData.currentUser.IsAdministrator == true)
                    {
                        App.Current.MainWindow.Hide();
                        App.Current.MainWindow = new AdminPage();
                        App.Current.MainWindow.Show();
                    }
                    else
                    {
                        App.Current.MainWindow.Hide();
                        App.Current.MainWindow = new Cabinet();
                        App.Current.MainWindow.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    return;
                }
            }
        }
    }
}
