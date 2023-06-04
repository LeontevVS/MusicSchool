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

namespace MusicSchool
{
    public partial class PaymentWindow : Window
    {
        public Payment payment;
        MainWindow _mw;

        public PaymentWindow(MainWindow mw, Payment payment = null)
        {
            _mw = mw;
            if (payment is null)
                this.payment = new Payment() 
                {
                    Id = 0,
                    Date = DateTime.Now,
                };
            else
                this.payment = payment;

            DataContext = this.payment;
            InitializeComponent();
            dpPaidFor.SelectedDate = DateTime.Now;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) => Save();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Несохраненные изменения будут утеряны.\nЗакрыть окно?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Close();
        }

        private bool Save()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tbStudent.Text))
                errors.AppendLine("Укажите студента");
            if (string.IsNullOrWhiteSpace(tbSumm.Text) && !decimal.TryParse(tbSumm.Text, out decimal summ))
                errors.AppendLine("Укажите сумму");
            if (string.IsNullOrWhiteSpace(dpPaidFor.Text))
                errors.AppendLine("Укажите дату");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }

            if (payment.Id == 0)
                Context.GetContext().Payments.Add(payment);

            try
            {
                Context.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        private void BtnSaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
                Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mw.UpdatePaymentsList();
        }

        private void btnChoice_Click(object sender, RoutedEventArgs e)
        {
            StudentChoiceWindow window = new StudentChoiceWindow(this);
            window.Show();
        }
    }
}
