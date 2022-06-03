using ITLab.DB;
using ITLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITLab.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Regex regEmail;
        Regex regName;
        Regex regPassword;
        public RegistrationWindow()
        {
            InitializeComponent();
            regEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            regName = new Regex(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}");
            regPassword = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!regName.IsMatch(NameBox.Text)) { MessageBox.Show("ФИО должно быть Имя Фамилия Отчество"); return; }
            if (!regEmail.IsMatch(EmailBox.Text)) { MessageBox.Show("Неверный формат почты"); return; }
            using (var db = new ITLabDBEntities())
            {
                if (db.Users.Count(x => x.Email == EmailBox.Text) > 0)
                {
                    MessageBox.Show("Пользователь с такой почтой зарегистрирован"); return;
                }
            }
            if (!regPassword.IsMatch(PasswordBox.Password))
            {
                MessageBox.Show("В пароле должны быть: цифра, буквы нижнего и \nверхнего регистра, длина от 8 до 16 символов ");
                return;
            }
            if (PasswordBox.Password != PasswordRepeatBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Users newUser = new Users() { Address = AddressBox.Text, FullName = NameBox.Text, Email = EmailBox.Text, IsAdministrator = false, HashPassword = HashPassword.Hash(PasswordBox.Password) };
            using (var db = new ITLabDBEntities())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            MessageBox.Show("Регистрация успешна!!");
            this.Close();
        }
    }
}
