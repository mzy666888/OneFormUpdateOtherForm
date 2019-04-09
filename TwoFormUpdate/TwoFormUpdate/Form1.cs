using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace TwoFormUpdate
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isRun = true;
        private Form2 form2;
        /// <summary>
        /// 开始按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //rm2.Show();
            isRun = true;

            Random rd = new Random();
            Task.Run(
                () =>
                    {
                        while (isRun)
                        {
                            form2.Invoke(new Action<int>(
                                (args) => { form2.label1.Text = $"当前值：{args}"; }), rd.Next());
                            Thread.Sleep(10);
                        }
                    });
        }

        /// <summary>
        /// 显示窗体点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

        /// <summary>
        /// 结束按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            isRun = false;
        }
    }
}
