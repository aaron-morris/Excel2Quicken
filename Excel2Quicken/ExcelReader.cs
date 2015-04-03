using System;
using System.Collections.Generic;

using Excel = Microsoft.Office.Interop.Excel;

namespace Excel2Quicken
{
    public class ExcelReader
    {
        public IEnumerable<Transaction> ReadTransactions(string filename, ExcelMap excelMap)
        {
            var application = new Excel.Application { DisplayAlerts = false };
            Excel.Workbook workbook = null;

            try
            {
                workbook = application.Workbooks.Open(filename, ReadOnly: true);
                var transactions = new List<Transaction>();

                transactions.AddRange(this.ReadExpenseTransactions(workbook, excelMap.ExpenseMap));
                transactions.AddRange(this.ReadRevenueTransactions(workbook, excelMap.RevenueMap));

                return transactions;
            }
            finally
            {
                try
                {
                    if (workbook != null)
                    {
                        workbook.Close(false);
                    }
                }
                catch (Exception)
                {
                    // Swallow
                }

                application.Quit();
            }
        }

        private IEnumerable<Transaction> ReadExpenseTransactions(Excel.Workbook workbook, ExcelMap.ExcelExpenseMap excelMap)
        {
            var expenseTransactions = new List<Transaction>();
            var worksheet = (Excel.Worksheet)workbook.Worksheets[excelMap.SheetName];
            var firstRowIndex = worksheet.UsedRange.Row;
            var lastRowIndex = firstRowIndex + worksheet.UsedRange.Rows.Count - 1;

            for (var index = firstRowIndex; index <= lastRowIndex; index++)
            {
                if (index == excelMap.HeaderRow)
                {
                    continue;
                }

                var transaction = new Transaction();

                transaction.Date = Convert.ToDateTime(worksheet.Range[excelMap.DateColumn + index].Value);
                transaction.Payee = worksheet.Range[excelMap.PayeeColumn + index].Value;
                transaction.Amount = -Convert.ToSingle(worksheet.Range[excelMap.AmountColumn + index].Value);
                transaction.Category = worksheet.Range[excelMap.CategoryColumn + index].Value;
                transaction.Memo = worksheet.Range[excelMap.MemoColumn + index].Value;

                expenseTransactions.Add(transaction);
            }

            return expenseTransactions;
        }

        private IEnumerable<Transaction> ReadRevenueTransactions(
            Excel.Workbook workbook,
            ExcelMap.ExcelRevenueMap excelMap)
        {
            var revenueTransactions = new List<Transaction>();
            var worksheet = (Excel.Worksheet)workbook.Worksheets[excelMap.SheetName];

            for (var index = excelMap.ShiftRowsStart; index <= excelMap.ShiftRowsEnd; index++)
            {
                var transaction = new Transaction();

                transaction.Date = Convert.ToDateTime(worksheet.Range[excelMap.DateColumn + index].Value);
                transaction.Payee = "Canteen Sales - " + worksheet.Range[excelMap.ShiftNameColumn + index].Value;
                transaction.TransactionSplits = this.GetTransactionSplits(worksheet, excelMap, index);

                var amount = 0.0f;
                var category = string.Empty;

                foreach (var split in transaction.TransactionSplits)
                {
                    if (string.IsNullOrEmpty(category))
                    {
                        category = split.Key;
                    }

                    amount += split.Value;
                }

                transaction.Category = category;
                transaction.Amount = amount;

                revenueTransactions.Add(transaction);
            }

            return revenueTransactions;
        }

        private IDictionary<string, float> GetTransactionSplits(
            Excel.Worksheet worksheet,
            ExcelMap.ExcelRevenueMap excelMap,
            int currentRow)
        {
            var transactionSplits = new Dictionary<string, float>();

            var startColumn = excelMap.CategoryColumnStart.ToCharArray()[0];
            var endColumn = excelMap.CategoryColumnEnd.ToCharArray()[0];

            for (var column = startColumn; column <= endColumn; column++)
            {
                var category = worksheet.Range[column.ToString() + excelMap.CategoryRow].Value;
                var amount = Convert.ToSingle(worksheet.Range[column.ToString() + currentRow].Value);

                if (transactionSplits.ContainsKey(category))
                {
                    transactionSplits[category] += amount;
                }
                else
                {
                    transactionSplits.Add(category, amount);
                }
            }

            return transactionSplits;
        }
    }
}
