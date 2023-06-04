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
    public partial class StudentChoiceWindow : Window
    {
        PaymentWindow _pw;

        public StudentChoiceWindow(PaymentWindow pw)
        {
            _pw = pw;
            InitializeComponent();
            UpdatePaymentsList();
        }

        public void UpdatePaymentsList() => DGridStudents.ItemsSource = Context.GetContext().Students.ToList();

        private void SetSelectedStudent()
        {
            Student stud = DGridStudents.SelectedItem as Student;
            _pw.payment.Student = stud;
            _pw.payment.StudentId = stud.Id;
            _pw.tbStudent.Text = stud.Name;
            Close();
        }

        private void btnChoice_Click(object sender, RoutedEventArgs e)
        {
            if (!(DGridStudents.SelectedItem is null))
                SetSelectedStudent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetSelectedStudent();
        }
    }
}
