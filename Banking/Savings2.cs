using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Banking {

    class Savings2 {

        public  Account Account { get; private set; } = null;
        public double InterestRate { get; private set; } = 0.01;

        public static bool Transfer(double amount, Savings2 FromAccount, Account ToAccount) {
            return Account.Transfer(amount, FromAccount.Account, ToAccount);
        }
        public static bool Transfer(double amount, Account FromAccount, Savings2 ToAccount) {
            return Account.Transfer(amount, FromAccount, ToAccount.Account);
        }
        public static bool Transfer(double amount, Savings2 FromAccount, Savings2 ToAccount) {
            return Account.Transfer(amount, FromAccount.Account, ToAccount.Account);
        }

        public void Print() {
            Console.WriteLine($"IntRate: {InterestRate}, Desc: {Account.Description}, Bal: {Account.Balance}");
        }

        public double Deposit(double amount) {
            return this.Account.Deposit(amount);
        }
        public double Withdraw(double amount) {
            return this.Account.Withdraw(amount);
        }

        public double PayInterest(int months) {
            var interest = this.CalculateInterest(months);
            Account.Deposit(interest);
            return interest;
        }

        public double CalculateInterest(int months) {
            return this.Account.Balance * (this.InterestRate / 12) * months;
        }

        public Savings2(double IntRate, string Description) {
            this.Account = new Account(Description);
            this.InterestRate = IntRate;
        }
        public Savings2(string Description) {
            this.Account = new Account(Description);
        }
        public Savings2() {
            this.Account = new Account();
        }
    }
}
