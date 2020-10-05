using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Exceptions {
    class InsufficientFundsException : Exception {

        public int AccountId { get; set; }
        public double AmountToWithdraw { get; set; }
        public double Balance { get; set; }

        public InsufficientFundsException() : base() { }

        public InsufficientFundsException(string message) : base(message) { }

        public InsufficientFundsException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
