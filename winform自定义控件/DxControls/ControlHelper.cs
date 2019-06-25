using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DxControls.DxAddOrUpdate;

namespace DxControls
{
    public class ControlHelper<T> where T : class
    {
        public ControlHelper()
        {
            ValueDic = new Dictionary<string, List<string>>();
        }
        public Dictionary<string,List<string>> ValueDic { get; set; }
        public List<Control> CreateControls(OperateType operate, DataRow dr=null) 
        {
            var lst = new List<Control>();
            foreach (var item in typeof(T).GetProperties())
            {
                var description = (DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute));
                var ct = (ControlTypeAttribute)Attribute.GetCustomAttribute(item, typeof(ControlTypeAttribute));
                if (ct == null)
                {
                    var dxt = new DxTextBox();
                    dxt.Title = description.Description;
                    dxt.ColumnName = new string[] { item.Name };
                    dxt.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                    lst.Add(dxt);
                }
                else
                {
                    switch (ct.ControlType)
                    {
                        case ControlType.Id:
                            var dtb = new DxTextBox();
                            dtb.Title = description.Description;
                            dtb.MTextBox.ReadOnly = true;
                            dtb.ColumnName = new string[] { item.Name };
                            dtb.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dtb);
                            break;
                        case ControlType.Number:
                            var dtbnum = new DxTextBox();
                            dtbnum.Title = description.Description;
                            dtbnum.ColumnName = new string[] { item.Name };
                            dtbnum.MTextBox.ReadOnly = ct.NoChange;
                            dtbnum.OnlyNum = true;
                            dtbnum.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dtbnum);
                            break;
                        case ControlType.Date:
                            var dd = new DxDateBox();
                            dd.Title = description.Description;
                            dd.DType = DxDateBox.DateType.H_Line1;
                            dd.ShowTimeBox = false;
                            dd.MTextBox.ReadOnly = true;
                            dd.NeedPopup = !ct.NoChange;
                            dd.ColumnName = new string[] { item.Name };
                            dd.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dd);
                            break;
                        case ControlType.DateTime:
                            var ddb = new DxDateBox();
                            ddb.Title = description.Description;
                            ddb.DType = DxDateBox.DateType.H_Line1;
                            ddb.ShowTimeBox = true;
                            ddb.MTextBox.ReadOnly = true;
                            ddb.NeedPopup = !ct.NoChange;
                            ddb.ColumnName = new string[] { item.Name };
                            ddb.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(ddb);
                            break;
                        case ControlType.Single:
                            var dtv = new DxTreeView();
                            dtv.Title = description.Description;
                            dtv.ColumnName = new string[] { item.Name };
                            dtv.CheckedSwitch = false;
                            dtv.MTextBox.ReadOnly = ct.NoChange;
                            dtv.NeedPopup = !ct.NoChange;
                            dtv.CbSource = ValueDic[ct.ValueKey];
                            dtv.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dtv);
                            break;
                        case ControlType.Multiple:
                            var dtvm = new DxTreeView();
                            dtvm.Title = description.Description;
                            dtvm.ColumnName = new string[] { item.Name };
                            dtvm.CheckedSwitch = true;
                            dtvm.MTextBox.ReadOnly = ct.NoChange;
                            dtvm.NeedPopup = !ct.NoChange;
                            dtvm.CbSource = ValueDic[ct.ValueKey];
                            dtvm.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dtvm);
                            break;
                        case ControlType.ReMarks:
                            var dxt = new DxTextBox();
                            dxt.Size = new Size(440, 38);
                            dxt.Title = description.Description;
                            dxt.ColumnName = new string[] { item.Name };
                            dxt.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dxt);
                            break;
                        default:
                            var dtbdefault = new DxTextBox();
                            dtbdefault.Title = description.Description;
                            dtbdefault.ColumnName = new string[] { item.Name };
                            dtbdefault.TxtValue = operate == OperateType.Update ? dr?[description.Description].ToString() : "";
                            lst.Add(dtbdefault);
                            break;
                    }
                }
            }
            return lst;
        }
    }
}
