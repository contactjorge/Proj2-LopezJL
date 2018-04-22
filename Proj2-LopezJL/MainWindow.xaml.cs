using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //ensure that number is only passed using a regex expession.
        private static bool OnlyTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that checks for numeric text
            return !regex.IsMatch(text);
        }

        //use the preview text to ensure that text in principal is numeric value
        private void txtPincipalAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !OnlyTextAllowed(e.Text); //ensure only numeric value is entered
        }

        //Event for change in principal amount change in text.
        private void pincipalAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            _principalInput = true; //let wpf know principal has been entered
        }

        //Event for change in principal amount change in text.
        private void txtPincipalAmount_TextInput(object sender, TextCompositionEventArgs e)
        {
            _principalInput = true; //let wpf know principal has been entered
            
        }
        //Event for 15 year loan period radio button is checked
        private void rdoButton15_Checked(object sender, RoutedEventArgs e)
        {
           // txtOtherPeriod.IsEnabled = false; //disable field other
        }

        //Event for 15 year loan period radio button if checked
        private void rdoButton30_Checked(object sender, RoutedEventArgs e)
        {
            //txtOtherPeriod.IsEnabled = false; //disable field other
        }

        //Event for 15 year loan period radio button if checked
        private void rdoButtonOther_Checked(object sender, RoutedEventArgs e)
        {
            //txtOtherPeriod.IsEnabled = true; //ensure this field is enabled upon selection
        }

        //event for Manual loan period radio button if clicked
        private void rdoButtonOther_Click(object sender, RoutedEventArgs e)
        {
            txtOtherPeriod.IsEnabled = true; //ensure this field is enabled upon selection
        }

        //only allow numeric values in thie field
        private void txtOtherPeriod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !OnlyTextAllowed(e.Text); //verify that only numeric value is entered
        }

        //Event for interest rate change slider
        private void interestRateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _interestRateInput = true; //capture interest rate.
        }

        //Event for resetting form. Not implemented
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            //stub to clear values and start over.
        }

        double MonthlyPayment(double p, double rate, double period)
        {
            //value is locally scoped

            double pay; //variable for return of monthly payment
            const double c = 1200.00; // const 1200.00
            double denom = (1 + rate / c); //begin calculate the denominator
            period = -12 * period; //calculate the power
            denom = Math.Pow(denom, period); //denom to the power of -12 * y
            pay = (p * rate / c) / (1 - denom); //PEDMAS for payment

            return pay; //return payment
        }

        //Event for for submit button to calculate. Gathers all information and calculates
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            string catchPrincipalInput = ""; //catch the principal input into a string
            string catchOtherInput = ""; //catch the other loan period input into a string


            if (_principalInput == false) //verify principal is not null
            {
                
                if (_principalInput == false) //verify interest rate was not null
                {
                    MessageBox.Show("Please enter a principal amount");
                }
                
            } else if (_interestRateInput == false) //verfiy once again in case first value was true
            {
                MessageBox.Show("Please enter a interest rate amount");
            }
            else //if both are true then carry on
            {
                if (rdoButton15.IsChecked == true) //deterimine which radio button checked
                {
                    _loanPeriod = 15.0;
                }
                else if (rdoButton30.IsChecked == true) //deterimine which radio button checked
                {
                    _loanPeriod = 30.0;
                }
                else if (rdoButtonOther.IsChecked == true) //deterimine which radio button checked
                {
                    catchOtherInput = txtOtherPeriod.Text;
                    _loanPeriod = double.Parse(catchOtherInput);
                }
                
                //convert principal input to a double.
                catchPrincipalInput = txtPincipalAmount.Text;
                _principal = double.Parse(catchPrincipalInput);

                //convert interest rate input to a double.
                _interestRate = interestRateSlider.Value;
              

                //Calculate monthly payment
                _monthlyPayment = MonthlyPayment(_principal, _interestRate, _loanPeriod);
                string monthly =  String.Format("Your monthly payment is ${0:N2}", _monthlyPayment);
                txtDisplayMonthly.Text = monthly;

            }
            
        }

    }
}
