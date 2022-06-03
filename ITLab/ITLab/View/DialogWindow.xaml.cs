using ITLab.DB;
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
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public ObservableCollection<MessageModel> MessagesList { get; set; }
        Users user;
        public DialogWindow(Users user)
        {
            this.user = user;
            InitializeComponent();
            MessagesList = new ObservableCollection<MessageModel>();
            DataContext = this;
            InitMessages();
        }
        void InitMessages()
        {
            using(var db = new ITLabDBEntities())
            {
                foreach(var x in db.Messages.Where(x=>x.UserID1 == StaticData.currentUser.ID && x.UserID2 == user.ID || x.UserID2 == StaticData.currentUser.ID && x.UserID1 == user.ID))
                {
                    MessagesList.Add(new MessageModel(x));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxMessage.Text == null || TextBoxMessage.Text == "") { return; }
            Messages message = new Messages()
            {
                UserID1 = StaticData.currentUser.ID,
                SendTime = DateTime.Now,
                Text = TextBoxMessage.Text,
                UserID2 = user.ID,

            };
            using (var db = new ITLabDBEntities())
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
            TextBoxMessage.Text = "";
            MessagesList.Add(new MessageModel(message));
        }
    }
}
