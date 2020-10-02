using System;

namespace Banking {
    class Program {
        static void Main(string[] args) 
            {

            var acct1 = new Account();
            var acct2 = new Account("My Checking");
            
            try {
                Account.Deposit(500, acct1);
                acct1.Print();
                acct2.Print();
                acct2.Deposit(1000);
                acct2.Print();
                acct2.Withdraw(50);
                acct2.Print();
                acct2.Deposit(-200);
                acct2.Print();
                acct2.Withdraw(-200);
                acct2.Print();
            } catch (DivideByZeroException ex) {
                Console.WriteLine("Attempted to divide by zero");
            } catch (Exception ex) {
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
