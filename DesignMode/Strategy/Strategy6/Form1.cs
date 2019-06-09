using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Strategy6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double _Total = 0.0d;

        /// <summary>
        /// 客户端程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            double.TryParse(txtUnitPrice.Text, out var dUnitPrice);
            double.TryParse(txtQuantity.Text, out var dQuantity);

            CashContext cc = null;
            switch (cbxType.SelectedItem.ToString())
            {
                case "正常收费":
                    cc = new CashContext(new CashNormal());
                    break;
                case "满300返80":
                    cc = new CashContext(new CashReturn("300", "80"));
                    break;
                case "打八折":
                    cc = new CashContext(new CashRebate("0.8"));
                    break;
            }

            var dGoodPrice = cc.GetResult(dUnitPrice * dQuantity);

            lbxList.Items.Add(string.Format(
                "单价：{0} 数量：{1} {3} 合计：{2}",
                dUnitPrice, dQuantity, dGoodPrice, cbxType.SelectedItem
                )
            );

            _Total += dGoodPrice;
            lblTotal.Text = _Total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxType.Items.AddRange(new object[] { "正常收费", "打八折", "满300返80" });
            cbxType.SelectedIndex = 0;
        }
    }
}
