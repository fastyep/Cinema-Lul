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

namespace ClientCinema
{
    /// <summary>
    /// Логика взаимодействия для Buy.xaml
    /// </summary>
    public partial class Buy : Window
    {
        private Show show;
        public Buy(Show show)
        {
            this.show = show;
            InitializeComponent();
            name.Content = show.name;
            time.Content = show.time;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SimpleGet.Get($"http://localhost:8070/api/client/buy?id={show.Id}&count={count.Text}");
                Close();
            }
            catch { err.Content = "Ошибка"; }
        }
    }
}
