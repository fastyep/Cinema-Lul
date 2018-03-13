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
using System.Threading;

namespace ClientCinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task t = new Task(() =>
            {
                Ping();
            });
            t.Start();
        }

        public bool Compare(List<Show> list, ItemCollection items)
        {
            if (list.Count() != items.Count)
                return false;
            foreach (Show s1 in list)
            {
                int index = list.IndexOf(s1);
                Show s2 = items[index] as Show;
                if (s1.Id != s2.Id)
                    return false;
                if (s1.name != s2.name)
                    return false;
                if (s1.time != s2.time)
                    return false;

            }
            return true;
        }

        public void Ping()
        {
            Show[] sh = null;
            try
            {
                sh = SimpleGet.GetJsonObject<Show[]>("http://localhost:8070/api/client/view");
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(ex.Message);
                    Close();
                });
                return;
            }
            Dispatcher.Invoke(() =>
            {
                if (!Compare(sh.ToList(), shows.Items))
                {
                    shows.ItemsSource = sh;
                    shows.Items.Refresh();
                }
            });
            Thread.Sleep(10000);
            Ping();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (Show show in shows.SelectedItems)
            {
                new Buy(show).Show();
            }
        }

    }
}
