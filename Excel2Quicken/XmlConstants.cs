using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel2Quicken
{
    public static class XmlConstants
    {
        public static class Elements
        {
            public const string Root = "excel_map";

            public const string Expenses = "expense_map";

            public const string SheetName = "sheet";

            public const string HeaderRow = "header_row";

            public const string DateColumn = "date_column";

            public const string PayeeColumn = "payee_column";

            public const string AmountColumn = "amount_column";

            public const string CategoryColumn = "category_column";

            public const string MemoColumn = "memo_column";

            public const string Revenues = "revenue_map";

            public const string CategoryColumns = "category_columns";

            public const string CategoryRow = "category_row";

            public const string ShiftNameColumn = "shift_name_column";

            public const string ShiftRows = "shift_rows";
        }

        public static class Attributes
        {
            public const string Start = "start";

            public const string End = "end";
        }
    }
}
