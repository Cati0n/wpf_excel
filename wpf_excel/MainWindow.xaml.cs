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

namespace wpf_excel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dueDate;
        public MainWindow()
        {
            InitializeComponent();
            dateLabel.SelectedDateChanged += DateLabel_SelectedDateChanged;
            paymentDue.TextChanged += PaymentDue_TextChanged;
            qntLabel_1.TextChanged += QntLabel_1_TextChanged;
            priceLabel_1.TextChanged += PriceLabel_1_TextChanged;
            
        }

        private void PriceLabel_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((qntLabel_1.Text != "") && (priceLabel_1.Text != ""))
            {
                totalPriceLabel_1.Content = Convert.ToInt32(qntLabel_1.Text) * Convert.ToInt32(priceLabel_1.Text);
            }
            else
            {
                totalPriceLabel_1.Content = "";
            }
        }

        private void QntLabel_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((qntLabel_1.Text != "") && (priceLabel_1.Text != ""))
            {
                totalPriceLabel_1.Content = Convert.ToInt32(qntLabel_1.Text) * Convert.ToInt32(priceLabel_1.Text);
            }
            else
            {
                totalPriceLabel_1.Content = "";
            }
        }

        private void DateLabel_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((dateLabel.Text != "") && (paymentDue.Text != ""))
            {
                //dueDateLabel.Content = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                dueDate = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                dueDateLabel.Content = dueDate.Date.ToString("dd/MM/yyy");
            }
            else
            {
                dueDateLabel.Content = "";
            }
        }

        private void PaymentDue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((dateLabel.Text != "") && (paymentDue.Text != ""))
            {
                dueDate = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                dueDateLabel.Content = dueDate.Date.ToString("dd/MM/yyy");


            }
            else
            {
                dueDateLabel.Content = "";
            }
        }
    }
}
