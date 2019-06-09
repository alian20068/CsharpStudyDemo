using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Strategy2
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

            var dGoodPrice = 0.0d;
            switch (cbxType.SelectedIndex)
            {
                case 1:
                    dGoodPrice = dUnitPrice * dQuantity * 0.8;
                    break;
                case 2:
                    dGoodPrice = dUnitPrice * dQuantity * 0.7;
                    break;
                case 3:
                    dGoodPrice = dUnitPrice * dQuantity * 0.5;
                    break;
                default:
                    dGoodPrice = dUnitPrice * dQuantity;
                    break;
            }

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
            cbxType.Items.AddRange(new object[] { "正常收费", "打八折", "打七折", "打五折" });
            cbxType.SelectedIndex = 0;
        }
    }
}
