using System;
using System.Windows;
using System.Windows.Controls;

namespace wpf_excel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime _dueDate;
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
            if (qntLabel_1.Text != "" && priceLabel_1.Text != "")
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
            if (qntLabel_1.Text != "" && priceLabel_1.Text != "")
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
            if (dateLabel.Text != "" && paymentDue.Text != "")
            {
                //dueDateLabel.Content = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                if (dateLabel.SelectedDate != null)
                    _dueDate = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                dueDateLabel.Content = _dueDate.Date.ToString("dd/MM/yyy");
            }
            else
            {
                dueDateLabel.Content = "";
            }
        }

        private void PaymentDue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dateLabel.Text != "" && paymentDue.Text != "")
            {
                if (dateLabel.SelectedDate != null)
                    _dueDate = dateLabel.SelectedDate.Value.AddDays(Convert.ToDouble(paymentDue.Text));
                dueDateLabel.Content = _dueDate.Date.ToString("dd/MM/yyy");
            }
            else
            {
                dueDateLabel.Content = "";
            }
        }
    }
}
