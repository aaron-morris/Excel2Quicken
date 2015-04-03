using System;
using System.Collections.Generic;
using System.Text;

namespace Excel2Quicken
{
    using System.IO;

    public class QuickenWriter
    {
        public void WriteTransaction(IEnumerable<Transaction> transactions, string filename)
        {
            var text = new StringBuilder(this.GetHeader());

            foreach (var transaction in transactions)
            {
                text.Append(this.ConvertToQifString(transaction));
            }

            File.WriteAllText(filename, text.ToString());
        }

        private string GetHeader()
        {
            return "!Type:Cash" + Environment.NewLine;
        }

        private string ConvertToQifString(Transaction transaction)
        {
            var qifBuilder = new StringBuilder();

            qifBuilder.AppendLine("D" + transaction.Date.ToShortDateString());
            qifBuilder.AppendLine("U" + transaction.Amount);
            qifBuilder.AppendLine("T" + transaction.Amount);
            qifBuilder.AppendLine("P" + transaction.Payee);
            qifBuilder.AppendLine("L" + transaction.Category);

            foreach (var split in transaction.TransactionSplits)
            {
                qifBuilder.AppendLine("S" + split.Key);
                qifBuilder.AppendLine("$" + split.Value);
            }

            qifBuilder.AppendLine("M" + transaction.Memo);
            qifBuilder.AppendLine("^");

            return qifBuilder.ToString();
        }
    }
}
