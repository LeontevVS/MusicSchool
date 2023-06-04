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

namespace MusicSchool
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
            AuthorisationWindow authorization = new AuthorisationWindow(this);
            authorization.Show();
            UpdatePaymentsList();
        }

        public void UpdatePaymentsList() => DGridServices.ItemsSource = Context.GetContext().Payments.ToList();

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            PaymentWindow wind = new PaymentWindow(this);
            wind.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PaymentWindow wind = new PaymentWindow(this, DGridServices.SelectedItem as Payment);
            wind.Show();
        }
    }
}
