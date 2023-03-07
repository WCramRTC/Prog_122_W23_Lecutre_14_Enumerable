using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Prog_122_W23_Lecutre_14_Enumerable
{
    internal class Account
    {

        // To declare a enuemrable
        // enum
        public enum AccountType { Savings, Checking, Investment }

        string _accountNumber;
        AccountType _typeOfAccount;
        string _name;
        decimal _balance;
        BitmapImage _customerPicture;

        decimal _withdrawFee = 200;


        // Difference between savings and checking accounts
        // Required Min Balance
        // Interest Rate
        // Withdraw Fee

        public Account(AccountType typeOfAccount, string name, decimal balance, string filePath)
        {
            Random rand = new Random();
            // Create a "fake" unique number
            _accountNumber = rand.Next(100000000, 1000000000).ToString();
            _typeOfAccount = typeOfAccount;
            _name = name;
            _customerPicture = ConvertCustomerImage(filePath);

        } // Account()

        public BitmapImage CustomerPicture { get => _customerPicture; set => _customerPicture = value; }


        public void Withdraw(decimal amount)
        {
            if(amount < _balance)
            {
                _balance -= _withdrawFee;
            }
            else
            {
                if(_typeOfAccount == AccountType.Checking)
                {
                    _balance -= _withdrawFee;
                }
            }

        }

        private BitmapImage ConvertCustomerImage(string filePath)
        {
            Uri uri = new Uri(filePath);
            // Pass URI into BitMapImage
            BitmapImage bitmap = new BitmapImage(uri);
            return bitmap;
        }

        public override string ToString()
        {
            return $"{_accountNumber} - {_typeOfAccount} - {_balance}";
        }

    }
}
