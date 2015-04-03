namespace Excel2Quicken
{
    using System;
    using System.Linq;
    using System.Xml;

    public class ExcelMapXmlReader
    {
        public ExcelMap LoadExcelMap(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var rootElement = xmlDoc.DocumentElement;
            return this.ParseRootForExcelMap(rootElement);
        }

        private ExcelMap ParseRootForExcelMap(XmlElement rootElement)
        {
            var excelMap = new ExcelMap();

            foreach (
                var xmlNode in
                    rootElement.ChildNodes.Cast<XmlNode>().Where(node => node.NodeType == XmlNodeType.Element))
            {
                switch (xmlNode.Name)
                {
                    case XmlConstants.Elements.Expenses:
                        excelMap.ExpenseMap = this.ParseForExcelExpenseMap((XmlElement)xmlNode);
                        break;

                    case XmlConstants.Elements.Revenues:
                        excelMap.RevenueMap = this.ParseForExcelRevenueMap((XmlElement)xmlNode);
                        break;
                }
            }

            return excelMap;
        }

        private ExcelMap.ExcelExpenseMap ParseForExcelExpenseMap(XmlElement element)
        {
            var expenseMap = new ExcelMap.ExcelExpenseMap();

            foreach (
                var xmlNode in element.ChildNodes.Cast<XmlNode>().Where(node => node.NodeType == XmlNodeType.Element))
            {
                switch (xmlNode.Name)
                {
                    case XmlConstants.Elements.SheetName:
                        expenseMap.SheetName = xmlNode.InnerText;
                        break;
                    
                    case XmlConstants.Elements.HeaderRow:
                        expenseMap.HeaderRow = Convert.ToInt32(xmlNode.InnerText);
                        break;

                    case XmlConstants.Elements.DateColumn:
                        expenseMap.DateColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.PayeeColumn:
                        expenseMap.PayeeColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.AmountColumn:
                        expenseMap.AmountColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.CategoryColumn:
                        expenseMap.CategoryColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.MemoColumn:
                        expenseMap.MemoColumn = xmlNode.InnerText;
                        break;
                }
            }

            return expenseMap;
        }

        private ExcelMap.ExcelRevenueMap ParseForExcelRevenueMap(XmlElement element)
        {
            var revenueMap = new ExcelMap.ExcelRevenueMap();

            foreach (
                var xmlNode in element.ChildNodes.Cast<XmlNode>().Where(node => node.NodeType == XmlNodeType.Element))
            {
                switch (xmlNode.Name)
                {
                    case XmlConstants.Elements.SheetName:
                        revenueMap.SheetName = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.ShiftNameColumn:
                        revenueMap.ShiftNameColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.DateColumn:
                        revenueMap.DateColumn = xmlNode.InnerText;
                        break;

                    case XmlConstants.Elements.CategoryColumns:
                        revenueMap.CategoryColumnStart = ((XmlElement)xmlNode).GetAttribute(XmlConstants.Attributes.Start);
                        revenueMap.CategoryColumnEnd = ((XmlElement)xmlNode).GetAttribute(XmlConstants.Attributes.End);
                        break;

                    case XmlConstants.Elements.CategoryRow:
                        revenueMap.CategoryRow = Convert.ToInt32(xmlNode.InnerText);
                        break;

                    case XmlConstants.Elements.ShiftRows:
                        revenueMap.ShiftRowsStart = Convert.ToInt32(((XmlElement)xmlNode).GetAttribute(XmlConstants.Attributes.Start));
                        revenueMap.ShiftRowsEnd = Convert.ToInt32(((XmlElement)xmlNode).GetAttribute(XmlConstants.Attributes.End));
                        break;
                }
            }

            return revenueMap;
        }
    }
}
