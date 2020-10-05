using System;
using System.Collections.Generic;
using System.Text;

using Banking.Exceptions;

namespace Banking {

    class Account {

        private  int NextId = 1;

        public int Id { get; private set; }
        public double Balance { get; private set; } = 0;
        public string Description { get; set; }

        public static bool Transfer(double amount, Account FromAccount, Account ToAccount) {
            if(amount <= 0) {
                return false;
            }
            if(FromAccount == null || ToAccount == null) {
                return false;
            }
            var BeforeBalance = FromAccount.Balance;
            var AfterBalance = FromAccount.Withdraw(amount);
            if(BeforeBalance != AfterBalance + amount) {
                return false;
            }
            ToAccount.Deposit(amount);
            return true;
        }

        private bool CheckAmountGreaterThanZero(double amount) {
            if(amount <= 0) {
                //Console.WriteLine("Amount must be GT zero");
                throw new Exception("Amount must be GT zero");
                //return false;
            }
            return true;
        }

        public static double Deposit(double amount, Account acct) {
            return acct.Deposit(amount);
        }
        public double Deposit(double amount) {
            if(!CheckAmountGreaterThanZero(amount)) {
                return Balance;
            }
            Balance = Balance + amount;
            return Balance;
        }

        public double Withdraw(double amount) {
            if(!CheckAmountGreaterThanZero(amount)) {
                return Balance;
            }
            if(Balance < amount) {
                var dbz = new DivideByZeroException("This is the innerException");
                var isfex = new InsufficientFundsException("Not sufficient funds", dbz);
                isfex.AccountId = this.Id;
                isfex.AmountToWithdraw = amount;
                isfex.Balance = this.Balance;
                throw isfex;
            }
            // Balance = Balance - amount
            Balance -= amount;
            return Balance;
        }

        public void Print() {
            Console.WriteLine($"Id[{Id}], Desc[{Description}], Bal[{Balance}]");
        }

        public Account(string description) {
            this.Id = NextId++;
            this.Description = description;
        }
        public Account() : this("New Account") {
            this.Description = "Default account";
        }

    }
}
