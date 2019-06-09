using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Strategy1
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

            var dGoodPrice = dUnitPrice * dQuantity;

            lbxList.Items.Add(string.Format("单价：{0} 数量：{1} 合计：{2}", dUnitPrice, dQuantity, dGoodPrice));

            _Total += dGoodPrice;
            lblTotal.Text = _Total.ToString();
        }
    }
}
