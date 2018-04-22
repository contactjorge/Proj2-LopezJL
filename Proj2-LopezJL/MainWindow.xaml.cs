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

namespace Proj2_LopezJL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        //Getter and Setter for principal amount change in text.
        private double _principal, _loanPeriod, _interestRate, _monthlyPayment;
        private bool _interestRateInput, _principalInput;

        private void txtPincipalAmount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Event for change in principal amount change in text.
        private void pincipalAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            _principalInput = true;
        }

        private void txtPincipalAmount_TextInput(object sender, TextCompositionEventArgs e)
        {
            _principalInput = true;
            
        }
        //Event for 15 year loan period radio button is checked
        private void rdoButton15_Checked(object sender, RoutedEventArgs e)
        {

        }

        //Event for 15 year loan period radio button if checked
        private void rdoButton30_Checked(object sender, RoutedEventArgs e)
        {

        }

        //Event for 15 year loan period radio button if checked
        private void rdoButtonOther_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        //event for Manual loan period radio button if clicked
        private void rdoButtonOther_Click(object sender, RoutedEventArgs e)
        {
            txtOtherPeriod.IsEnabled = true;
        }

        //Event for interest rate change slider
        private void interestRateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _interestRateInput = true;
        }

        //Event for resetting form.
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        //Event for for submit button to calculate. Gathers all information and calculates
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            string catchPrincipalInput = "";
            string catchLoanInput = "";
            string catchInterestInput = "";

            if (_principalInput == false)
            {
                MessageBox.Show("Please enter a principal amount");
                if (_interestRateInput == false)
                {
                    MessageBox.Show("Please enter a interest rate amount");
                }
            } else if (_interestRateInput == false)
            {
                MessageBox.Show("Please enter a interest rate amount");
            }
            else
            {
                if (rdoButton15.IsChecked == true)
                {
                    MessageBox.Show("You selected 15 years");
                    _loanPeriod = 15.0;
                }
                else if (rdoButton30.IsChecked == true)
                {
                    MessageBox.Show("You selected 30 years");
                }
                else if (rdoButtonOther.IsChecked == true)
                    _loanPeriod = 30.0;
                {
                    MessageBox.Show("You selected 30 years");
                    catchLoanInput = txtOtherPeriod.Text;
                }
                catchPrincipalInput = txtPincipalAmount.Text;
                MessageBox.Show("You entered Principal" + catchPrincipalInput);
                _interestRate = interestRateSlider.Value;
                MessageBox.Show("You entered an interest rate of: " + interestRateSlider);
            }
            

        }

    }
}
