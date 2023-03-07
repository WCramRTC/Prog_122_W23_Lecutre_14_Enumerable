using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_122_W23_Lecutre_14_Enumerable.Notes
{
    internal class Account
    {
        public enum Type { Savings, Checking }
        string _name;
        string _accountNumber;
        decimal _balance;
        Type _type;

        public Account(string name,  decimal balance, Type type)
        {
            Random rand = new Random();
            _name = name;
            _accountNumber = rand.Next(100000000, 1000000000).ToString();
            _balance = balance;
            _type = type;
        }

        public string Name { get => _name; set => _name = value; }
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public decimal Balance { get => _balance; }
        internal Type AccountType { get => _type; }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public override string ToString()
        {
            if(_type == Type.Savings)
            {
                return $"Savings Account - {_accountNumber}: Name - {_name} - Balance{_balance}";
            }
            else
            {
                return $"Checking Account - {_accountNumber}: Name - {_name} - Balance{_balance}";
            }
        }

    }
}
