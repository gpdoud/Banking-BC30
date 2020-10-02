using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking {

    class Savings : Account {

        public double InterestRate { get; protected set; } = 0.01;

        public double PayInterest(int months) {
            var interest = this.CalculateInterest(months);
            Deposit(interest);
            return interest;
        }
        public double CalculateInterest(int months) {
            return this.Balance * (this.InterestRate / 12) * months;
        }

        public Savings(double intRate, string description) : base(description) {
            this.InterestRate = intRate;
        }
        public Savings(string description) : base(description) {

        }
        public Savings() : base() { }
    }
}
