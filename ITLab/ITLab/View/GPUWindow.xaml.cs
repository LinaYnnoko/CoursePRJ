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
    /// Логика взаимодействия для GPUWindow.xaml
    /// </summary>
    public partial class GPUWindow : Window
    {
        GPUs gpu;
        public GPUWindow(GPUs gpu)
        {
            this.gpu = gpu;
            InitializeComponent();
            SerialBox.Text = gpu.Series;
            ModelBox.Text = gpu.Model;
            FrequencyBox.Text = gpu.Frequency;
            RAMSize.Text = gpu.Memory.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SerialBox.Text == "" || ModelBox.Text == "" || FrequencyBox.Text == "" || RAMSize.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены"); return;
            }

            gpu.Series = SerialBox.Text;
            gpu.Model = ModelBox.Text;
            gpu.Frequency = FrequencyBox.Text;
            gpu.Memory = Convert.ToInt32(RAMSize.Text);
            MessageBox.Show("Видеокарта успешно добавлена");
            this.Close();
        }
    }
}
