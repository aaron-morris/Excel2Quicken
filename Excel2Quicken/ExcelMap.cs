using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel2Quicken
{
    public class ExcelMap
    {
        public ExcelExpenseMap ExpenseMap { get; set; }

        public ExcelRevenueMap RevenueMap { get; set; }

        public class ExcelExpenseMap
        {
            public string SheetName { get; set; }

            public int HeaderRow { get; set; }

            public string DateColumn { get; set; }

            public string PayeeColumn { get; set; }

            public string AmountColumn { get; set; }

            public string CategoryColumn { get; set; }

            public string MemoColumn { get; set; }
        }

        public class ExcelRevenueMap
        {
            public string SheetName { get; set; }

            public string ShiftNameColumn { get; set; }

            public string DateColumn { get; set; }

            public string CategoryColumnStart { get; set; }

            public string CategoryColumnEnd { get; set; }

            public int CategoryRow { get; set; }

            public int ShiftRowsStart { get; set; }

            public int ShiftRowsEnd { get; set; }
        }
    }
}
