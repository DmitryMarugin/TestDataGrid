using System;
using System.Collections.Generic;
using System.Data;
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

namespace TestDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataWorker data = new DataWorker();
            DataGrid1.ItemsSource = data.dt.DefaultView;
            data.DataChanged += OnDataChanged;
            data.RunThread();
        }

        private void OnDataChanged(object obj, EventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                DataGrid1.Items.Refresh();
            }));
        }
    }
}
