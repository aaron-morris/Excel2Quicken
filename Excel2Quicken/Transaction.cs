using System;

namespace Excel2Quicken
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class Transaction
    {
        public Transaction()
        {
            this.TransactionSplits = new Dictionary<string, float>();
        }

        public DateTime Date { get; set; }

        public string Payee { get; set; }

        public float Amount { get; set; }

        public string Category { get; set; }

        public IDictionary<string, float> TransactionSplits { get; set; } 

        public string Memo { get; set; }
    }
}
