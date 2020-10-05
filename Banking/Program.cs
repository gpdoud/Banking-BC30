using Banking.Exceptions;

using System;

namespace Banking {
    class Program {
        static void Main(string[] args) {

            var sav1 = new Savings(0.12, "My Savings");
            sav1.Deposit(1000);
            sav1.Print();
            sav1.PayInterest(1);
            sav1.Print();

            var sav2 = new Savings2(0.12, "My Composite Savings");
            sav2.Deposit(1000);
            sav2.Print();
            sav2.PayInterest(1);
            sav2.Print();

            Savings2.Transfer(100, sav1, sav2);

            var acct1 = new Account();
            var acct2 = new Account("My Checking");

            Account.Deposit(500, acct1);
            acct1.Print();
            acct2.Print();
            acct2.Deposit(1000);
            acct2.Withdraw(2000);
            acct2.Print();

            try {
                acct2.Withdraw(5000);
                acct2.Print();
                acct2.Deposit(-200);
                acct2.Print();
                acct2.Withdraw(-200);
                acct2.Print();
            } catch (InsufficientFundsException ex) {
                Console.WriteLine($"Insufficient Funds: Acct: {ex.AccountId}, Amt: {ex.AmountToWithdraw}, Bal: {ex.Balance}");
            } catch(DivideByZeroException ex) {
                Console.WriteLine("Attempted to divide by zero");
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            var success = Account.Transfer(200, acct2, acct1);
            if(success) {
                Console.WriteLine("The transfer worked!");
            } else {
                Console.WriteLine("The transfer failed!");
            }
            acct2.Print();
            acct1.Print();
        }
    }
}
