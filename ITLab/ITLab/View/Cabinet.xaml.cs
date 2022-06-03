using ITLab.DB;
using ITLab.Logic;
using ITLab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Window
    {
        CPUs cpu;
        GPUs gpu;
        public ObservableCollection<OrderedPc> AllComputers { get; set; }
        public Cabinet()
        {
            try
            {
                InitializeComponent();
                cpu = new CPUs();
                gpu = new GPUs();
                FullnameBox.Text = StaticData.currentUser.FullName;
                EmailBox.Text = StaticData.currentUser.Email;
                AddressBox.Text = StaticData.currentUser.Address;
                AllComputers = new ObservableCollection<OrderedPc>();
                cpu.Series = "";
                gpu.Series = "";
                InitPcs();
                DataContext = this;
            }
            catch
            {
                MessageBox.Show("Ошибка инициализцаии страницы");
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //if (PasswordBoxRepeat.Password != "" || PasswordBox.Password != "" || PasswordOldBox.Password != "") { isPasswordChange = true; }
                using (var db = new ITLabDBEntities())
                {
                    var user = db.Users.FirstOrDefault(q => q.Email == StaticData.currentUser.Email);
                    if (HashPassword.VerifyHashedPassword(user.HashPassword, PasswordOldBox.Password) )
                    {
                        var passExp = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
                        if (!passExp.IsMatch(PasswordBox.Password)) { MessageBox.Show("В пароле должны быть: цифра, буквы нижнего и верхнего регистра, длина от 8 до 16 символов"); return; }
                        if (PasswordBox.Password != PasswordBoxRepeat.Password ) { MessageBox.Show("Пароли не совпадают"); return; }
                        user.Address = AddressBox.Text;
                       
                            user.HashPassword = HashPassword.Hash(PasswordBox.Password);
                        
                        user.FullName = FullnameBox.Text;
                        user.Email = EmailBox.Text;
                        db.SaveChanges();
                        StaticData.currentUser = user;
                        MessageBox.Show("Данные успешно изменены");
                    }
                    else
                    {
                        MessageBox.Show("Неверный старый пароль");
                        return;
                    }

                }
            }
            catch { MessageBox.Show("Ошибка сохранения данных в бд"); return; }
        }
        //выйти из аккаунта
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StaticData.currentUser = null;
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
        //очистка
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TypeCombo.Text = "";
            RamTypeCombo.Text = "";
            RamSizeCombo.Text = "";
            DiskSizeCombj.Text = "";
            DiskTypeCombo.Text = "";
            DateCombo.Text = "";
            cpu = new CPUs();
            gpu = new GPUs();
            cpu.Series = "";
            gpu.Series = "";
        }
        //cpu
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var cpuwnd = new CPUWindow(cpu);
            cpuwnd.ShowDialog();

        }
        //gpu
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var gpuwnd = new GPUWindow(gpu);
            gpuwnd.ShowDialog();
        }
        //Добавить
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeCombo.Text == "" || RamSizeCombo.Text == "" || RamTypeCombo.Text == "" || DiskSizeCombj.Text == "" || DiskTypeCombo.Text == "" || DateCombo.Text == "")
                {
                    MessageBox.Show("Все поля должны быть заполнены"); return;
                }
                if (cpu.Series == "" || gpu.Series == "") { MessageBox.Show("Не выбрана видеокарта или процессор"); return; }
                DateTime date = DateTime.Parse(DateCombo.Text);
                if (date < DateTime.Now)
                {
                    MessageBox.Show("Дата заказа не может быть раньше текущего времени");
                    return;
                }
                using (var db = new ITLabDBEntities())
                {
                    var newComputer = new Computers() { UserID = StaticData.currentUser.ID, TypeComputer = TypeCombo.Text, SizeRAM = RamSizeCombo.Text, TypeRAM = RamTypeCombo.Text,  SizeHardDisk = Convert.ToInt32(DiskSizeCombj.Text), TypeHardDisk = DiskTypeCombo.Text, TimeOfOrder = DateTime.Parse(DateCombo.Text) };
                    db.Computers.Add(newComputer);
                    db.SaveChanges();
                    var selComputer = db.Computers.FirstOrDefault(x => x.ID == newComputer.ID);
                    cpu.ComputerId = selComputer.ID;
                    gpu.ComputerId = selComputer.ID;
                    db.GPUs.Add(gpu);
                    db.CPUs.Add(cpu);
                    db.SaveChanges();
                    MessageBox.Show("Компьютер успешно заказан");

                }
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка"); return;
            }
        }

        void InitPcs()
        {
            AllComputers.Clear();
            using(var db = new ITLabDBEntities())
            {
                foreach(var x in db.Computers.Where(x=>x.UserID == StaticData.currentUser.ID)){
                    AllComputers.Add(new OrderedPc(x));
                }
            }
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InitPcs();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            using(var db = new ITLabDBEntities())
            {
                var admin = db.Users.FirstOrDefault(x => x.IsAdministrator == true);
                var dialogWindow = new DialogWindow(admin);
                dialogWindow.ShowDialog();
            }
        }
    }
}
