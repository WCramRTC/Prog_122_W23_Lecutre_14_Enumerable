using Microsoft.Win32;
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

namespace Prog_122_W23_Lecutre_14_Enumerable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateAccountTypes();
            
        }

        public void PopulateAccountTypes()
        {
            cmbAccountTypes.Items.Add("Savings");
            cmbAccountTypes.Items.Add("Checking");
            cmbAccountTypes.Items.Add("Investment");

            cmbAccountTypes.SelectedIndex = 0;
        }

        // Inside my button, when clicked, creates a new instance of an account with the required information.
        // Adds it to the account list
        // Updates the account listbox display
        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtName.Name;
            decimal balance = decimal.Parse(txtBalance.Text);
            int accountType = cmbAccountTypes.SelectedIndex;
            Account.AccountType convertedType = (Account.AccountType)accountType;


            // What is casting?
            string filePath = txtFilePath.Text;

            // A new instance of _____ type
            // new Type()
            Account account = new Account(convertedType, fullName,balance, filePath);

            accounts.Add(account);

            DisplayAccounts();
        }

        public void DisplayAccounts()
        {
            lbAccounts.Items.Clear();

            foreach (Account a in accounts)
            {
                lbAccounts.Items.Add(a);
            }
        }

        private void btnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            // Open file diagloug
            OpenFileDialog op = new OpenFileDialog();   
            if (op.ShowDialog() == true)
            {
                txtFilePath.Text = op.FileName;
            }
        }
        int selectedIndex = 0;
        private void lbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbAccounts.SelectedIndex > -1)
            {
                selectedIndex = lbAccounts.SelectedIndex;
            }

            imgCustomer.Source = accounts[selectedIndex].CustomerPicture;

        }
    }

}
