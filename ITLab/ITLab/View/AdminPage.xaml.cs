using ITLab.DB;
using ITLab.Logic;
using ITLab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ITLab.View
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public ObservableCollection<Users> UsersList { get; set; }
        public ObservableCollection<OrderedPc> ComputersList { get; set;}
        public OrderedPc SelectedPC { get; set; }
        public Users SelectedUser { get; set; }
        public AdminPage()
        {

            InitializeComponent();
            UsersList = new ObservableCollection<Users>(); 
            ComputersList = new ObservableCollection<OrderedPc>();
            InitListst();
            DataContext = this;
        }
        void InitListst()
        {
            ComputersList.Clear();
            UsersList.Clear();
            using(var db = new ITLabDBEntities())
            {
                foreach(var x in db.Users)
                {
                    if(x.ID== StaticData.currentUser.ID) { continue; }
                    UsersList.Add(x);
                }
                foreach(var x in db.Computers)
                {
                    ComputersList.Add(new OrderedPc(x));
                }
            }
        }
        //открыть окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedUser == null) { MessageBox.Show("Пользователь не выбран"); return; }

            var dialog = new DialogWindow(SelectedUser);
            dialog.ShowDialog();    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StaticData.currentUser = null;
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
        //Удаление заказа
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedPC == null) { MessageBox.Show("Заказ не выбран"); return; }
                using (var db = new ITLabDBEntities())
                {
                    var CPU = db.CPUs.FirstOrDefault(x => x.ComputerId == SelectedPC.pc.ID);
                    db.CPUs.Remove(CPU);
                    var GPU = db.GPUs.FirstOrDefault(x => x.ComputerId == SelectedPC.pc.ID);
                    db.GPUs.Remove(GPU);
                    db.Computers.Remove(db.Computers.FirstOrDefault(x => x.ID == SelectedPC.pc.ID));
                    db.SaveChanges();
                    InitListst();
                    MessageBox.Show("Заказ успешно удалён");
                }
            }
            catch { MessageBox.Show("Критическая ошибка при удалении"); return; }
        }
    }
}
