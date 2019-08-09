using System;
using System.Text;
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
        int totalRows = 4;
        TextBox[] qntLabelArr = new TextBox[4];
        TextBox[] priceLabelArr = new TextBox[4];
        TextBox[] totalPriceLabelArr = new TextBox[4];
        
        public MainWindow()
        {
            InitializeComponent();

            dateLabel.SelectedDateChanged += DateLabel_SelectedDateChanged;
            paymentDue.TextChanged += PaymentDue_TextChanged;
            invoiceNumberLabel_1.LostFocus += InvoiceNumberLabel_1_LostFocus;

            qntLabel_1.TextChanged += totalPriceChange;
            qntLabel_2.TextChanged += totalPriceChange;
            qntLabel_3.TextChanged += totalPriceChange;
            qntLabel_4.TextChanged += totalPriceChange;

            priceLabel_1.TextChanged += totalPriceChange;
            priceLabel_2.TextChanged += totalPriceChange;
            priceLabel_3.TextChanged += totalPriceChange;
            priceLabel_4.TextChanged += totalPriceChange;

            totalPriceLabel_1.TextChanged += grandTotalChange;
            totalPriceLabel_2.TextChanged += grandTotalChange;
            totalPriceLabel_3.TextChanged += grandTotalChange;
            totalPriceLabel_4.TextChanged += grandTotalChange;

            qntLabelArr = new TextBox [] { qntLabel_1, qntLabel_2, qntLabel_3, qntLabel_4 };
            priceLabelArr = new TextBox[] { priceLabel_1, priceLabel_2, priceLabel_3, priceLabel_4 };
            totalPriceLabelArr = new TextBox[] { totalPriceLabel_1, totalPriceLabel_2, totalPriceLabel_3, totalPriceLabel_4 };
        }

        private void InvoiceNumberLabel_1_LostFocus(object sender, RoutedEventArgs e)
        {
            invoiceNumberLabel_2.Content = invoiceNumberLabel_1.Text;
        }

        private void totalPriceChange(object sender, TextChangedEventArgs e)
        {

            for (int i = 0; i < totalRows; i++)
            {
                if ((sender == qntLabelArr[i]) || (sender == priceLabelArr[i]))
                {
                    if (qntLabelArr[i].Text.Contains(","))
                    {
                        int caretPos = qntLabelArr[i].CaretIndex;
                        string stringToModify = qntLabelArr[i].Text;
                        char[] ch = stringToModify.ToCharArray();
                        int index = Array.IndexOf(ch, ',');
                        StringBuilder sb = new StringBuilder(stringToModify);
                        sb[index] = '.';
                        qntLabelArr[i].Text = sb.ToString();
                        qntLabelArr[i].CaretIndex = caretPos;
                    }

                    if (priceLabelArr[i].Text.Contains(","))
                    {
                        int caretPos = priceLabelArr[i].CaretIndex;
                        string stringToModify = priceLabelArr[i].Text;
                        char[] ch = stringToModify.ToCharArray();
                        int index = Array.IndexOf(ch, ',');
                        StringBuilder sb = new StringBuilder(stringToModify);
                        sb[index] = '.';
                        priceLabelArr[i].Text = sb.ToString();
                        priceLabelArr[i].CaretIndex = caretPos;
                    }

                    if (qntLabelArr[i].Text != "" && priceLabelArr[i].Text != "")
                    {
                        
                        totalPriceLabelArr[i].Text = Convert.ToString(Convert.ToDouble(qntLabelArr[i].Text) * Convert.ToDouble(priceLabelArr[i].Text)) + "\u20AC";
                        break;
                    }
                    else
                    {
                        totalPriceLabelArr[i].Text = "0";
                        break;
                    }
                }

            }
        }

        private void grandTotalChange(object sender, TextChangedEventArgs e)
        {
            grandTotalLabel_1.Content = "0";
            foreach (TextBox element in totalPriceLabelArr)
            {
                string newElement = element.Text;
                if (element.Text != "0")
                {
                    newElement = element.Text.Remove(element.Text.Length - 1);
                }
                grandTotalLabel_1.Content = Convert.ToString(Convert.ToDouble(grandTotalLabel_1.Content) + Convert.ToDouble(newElement));
            }
            
            grandTotalLabel_1.Content += "\u20AC";
        }
        private void DateLabel_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
