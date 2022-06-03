using ITLab.DB;
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
using System.Windows.Shapes;

namespace ITLab.View
{
    /// <summary>
    /// Логика взаимодействия для CPUWindow.xaml
    /// </summary>
    public partial class CPUWindow : Window
    {
        CPUs cpu;
        public CPUWindow(CPUs cpu)
        {
            this.cpu = cpu;
            InitializeComponent();
            SerialBox.Text = cpu.Series;
            ModelBox.Text = cpu.Model;
            FrequencyBox.Text = cpu.Frequency;
            CoresBox.Text = cpu.NumberOfCores.ToString();
            CacheSizeBox.Text = cpu.CacheSize.ToString();
        }
        //добавить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SerialBox.Text == "" || ModelBox.Text == "" || FrequencyBox.Text == "" || CoresBox.Text == "" || CacheSizeBox.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");return;
            }
            cpu.Series = SerialBox.Text;
            cpu.Model = ModelBox.Text;
            cpu.Frequency = FrequencyBox.Text;
            cpu.NumberOfCores = Convert.ToInt32(CoresBox.Text);
            cpu.CacheSize = Convert.ToInt32(CacheSizeBox.Text);
            MessageBox.Show("Процессор успешно добавлен");
            this.Close();
        }
    }
}
