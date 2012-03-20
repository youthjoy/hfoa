using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;
using QX.DAL;
using CrystalDecisions.CrystalReports.Engine;
using System.Web;
using CrystalDecisions.Shared;
using QX.Comm;
namespace QX.BLL
{
    public class Bll_Rpt
    {

        /// <summary>
        /// 打印空白盘点单
        /// </summary>
        public void SendStockCheckPrint(WH_BanMain Model,List<WH_BanItem> List)
        {
            ReportDocument rptDocument = new ReportDocument();
            rptDocument.Load(HttpContext.Current.Server.MapPath("~/CrReport/Rpt_Stock_CheckNew.rpt"));            
            rptDocument.SetDataSource(List);
            rptDocument.PrintToPrinter(1, false, 0, 0); //开始打印所有页
        }


        /// <summary>
        /// 打印盘点单
        /// </summary>
        public void SendStockCheckPrint()
        {
            ReportDocument rptDocument = new ReportDocument();
            rptDocument.Load(HttpContext.Current.Server.MapPath("~/CrReport/Rpt_Stock_Check.rpt"));
            System.Data.DataTable dt = new System.Data.DataTable();
            QX.BLL.Bll_Comm comInstance = new QX.BLL.Bll_Comm();
            dt = comInstance.ListViewData("select * from VRpt_StockCheck");
            rptDocument.SetDataSource(dt);
            rptDocument.PrintToPrinter(1, false, 0, 0); //开始打印所有页
        }

        /// <summary>
        /// 打印领料单
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list"></param>
        public void SendIOPrint(WH_IOMain main, IEnumerable<WH_IOItem> list)
        {

            string path = HttpContext.Current.Server.MapPath("~/CrReport/Rpt_Ticket_Picking.rpt");
            AsyncCallback callback = delegate
            {
                ReportDocument rptDocument = new ReportDocument();
                rptDocument.Load(path);
                QX.BLL.Bll_Comm comInstance = new QX.BLL.Bll_Comm();



                //ParameterDiscreteValue crParameterDiscreteValue;
                //ParameterField crParameterField;
                //ParameterFields crParameterFields;


                //crParameterFields = new ParameterFields();

                ////工程名称
                //crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = main.WHIOM_Code;
                //crParameterField = new ParameterField();
                //crParameterField.ParameterFieldName = "WHIOM_Code";
                //crParameterField.CurrentValues.Add(crParameterDiscreteValue);
                //crParameterFields.Add(crParameterField);


                ////工程名称
                //crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = main.WHIOM_RDate;
                //crParameterField = new ParameterField();
                //crParameterField.ParameterFieldName = "WHIOM_RDate";
                //crParameterField.CurrentValues.Add(crParameterDiscreteValue);
                //crParameterFields.Add(crParameterField);

                ////工程名称
                //crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = main.WHIOM_Department;
                //crParameterField = new ParameterField();
                //crParameterField.ParameterFieldName = "WHIOM_Code";
                //crParameterField.CurrentValues.Add(crParameterDiscreteValue);
                //crParameterFields.Add(crParameterField);


                ////工程名称
                //crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = main.WHIOM_Owner;
                //crParameterField = new ParameterField();
                //crParameterField.ParameterFieldName = "WHIOM_Owner";
                //crParameterField.CurrentValues.Add(crParameterDiscreteValue);
                //crParameterFields.Add(crParameterField);


                //crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = main.WHIOM_BOwner;
                //crParameterField = new ParameterField();
                //crParameterField.ParameterFieldName = "WHIOM_BOwner";
                //crParameterField.CurrentValues.Add(crParameterDiscreteValue);
                //crParameterFields.Add(crParameterField);

                ////foreach (ParameterField p in crParameterFields)
                ////{
                ////    rptDocument.SetParameterValue(p.ParameterFieldName, p.CurrentValues[0]);
                ////}

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = comInstance.ListViewData(string.Format("select * from VRpt_IOItem where WHIOI_MainCode='{0}'", main.WHIOM_Code));
                rptDocument.SetDataSource(list);

                rptDocument.SetParameterValue("WHIOM_Department", main.WHIOM_Department);
                rptDocument.SetParameterValue("WHIOM_Code", main.WHIOM_Code);
                rptDocument.SetParameterValue("WHIOM_Owner", main.WHIOM_Owner);
                rptDocument.SetParameterValue("WHIOM_BOwner", main.WHIOM_BOwner);
                rptDocument.SetParameterValue("WHIOM_RDate", main.WHIOM_RDate);

                rptDocument.PrintToPrinter(1, false, 0, 0); //开始打印所有页
            };
            callback.BeginInvoke(null, null, null);
        }
    }
}
