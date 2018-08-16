using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;
/// <?xml version="1.0" ?>
namespace WindowsFormsApp3
{
    /// <summary>可重复的类-与用户界面一一对应</summary>
    public partial class Form1 : Form
    {
        /// <summary>这是构造函数</summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 这是继承的基类
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int tab = 0;
        /// <summary>记录指针</summary>
        int Precord = 0;
        /// <summary>记录数</summary>
        int RecordNum = 0;
        public String text = "";
        /// <summary>存储记录</summary>
        public String[] record = new String[10];
        /// <summary>存储表达式</summary>
        public String[] texts = new String[10000];
        /// <summary>加载js引擎</summary>
        Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();

        /// <summary>写入txt保存记录的函数
        /// <param name="p"></param>
        /// </summary>
        public void Save_result(string p)
        {           
            /// <remarks>根据所需写入txt的具体位置修改文件路径</remarks>
            FileStream fs = new FileStream(@"E:\软件作业\WindowsFormsApp3\memory.txt", FileMode.Append);
            byte[] data = new UTF8Encoding().GetBytes(p);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
        /// <summary>处理表达式，将输入的数据存储</summary>
        public void addComments(String s)
        { 
            this.text += s;
            this.texts[tab] = s;
            this.richTextBox1.Text = this.text;
            tab++;
        }
        /// <summary>1按钮的触发事件</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.addComments("1");
        }
        /// <summary>2按钮的触发事件</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.addComments("2");
        }
        /// <summary>3按钮的触发事件</summary>
        private void button3_Click(object sender, EventArgs e)
        {
            this.addComments("3");
        }
        /// <summary>4按钮的触发件事</summary>
        private void button4_Click(object sender, EventArgs e)
        {
            this.addComments("4");
        }
        /// <summary>5按钮的触发事件</summary>
        private void button5_Click(object sender, EventArgs e)
        {
            this.addComments("5");
        }
        /// <summary>6按钮的触发事件</summary>
        private void button6_Click(object sender, EventArgs e)
        {
            this.addComments("6");
        }
        /// <summary>7按钮的触发事件</summary>
        private void button7_Click(object sender, EventArgs e)
        {
            this.addComments("7");
        }
        /// <summary>8按钮的触发事件</summary>
        private void button8_Click(object sender, EventArgs e)
        {
            this.addComments("8");
        }
        /// <summary>9按钮的触发事件</summary>
        private void button9_Click(object sender, EventArgs e)
        {
            this.addComments("9");
        }
        /// <summary>0按钮的触发事件</summary>
        private void button10_Click(object sender, EventArgs e)
        {
            this.addComments("0");
        }
        /// <summary> .(小数点)按钮的触发事件</summary>
        private void button12_Click(object sender, EventArgs e)
        {
            this.addComments(".");
        }
        /// <summary> )按钮的触发事件</summary>
        private void button17_Click(object sender, EventArgs e)
        {
            this.addComments(")");
        }
        /// <summary> (按钮的触发事件</summary>
        private void button18_Click(object sender, EventArgs e)
        {
            this.addComments("(");
        }
        /// <summary> +按钮的触发事件</summary>
        private void button13_Click(object sender, EventArgs e)
        {
            this.addComments("+");
        }
        /// <summary> -按钮的触发事件</summary>
        private void button14_Click(object sender, EventArgs e)
        {
            this.addComments("-");
        }
        /// <summary> *按钮的触发事件</summary>
        private void button15_Click(object sender, EventArgs e)
        { 
            this.addComments("*");
        }
        /// <summary>/按钮的触发事件</summary>
        private void button16_Click(object sender, EventArgs e)
        {
            this.addComments("/");
        }
        /// <summary> =按钮的触发事件,最终计算结果并显示，且调用函数将计算结果存入txt文件中</summary>
        private void button11_Click(object sender, EventArgs e)
        {
            /// <remark>就是结果</remark>
            try
            { 
                String result = Microsoft.JScript.Eval.JScriptEvaluate(this.text, ve).ToString();
                Save_result(text);
                Save_result("=");
                Save_result(result);
                Save_result("\r\n");
                this.textBox1.Text = result;
                this.record[RecordNum] = this.text;
                this.text = result;
                this.RecordNum++;
                this.Precord = this.RecordNum;
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误！","提示");
                this.text = "";
                tab = 0;
            }
        }
        /// <summary>清零按钮的触发事件</summary>
        private void button20_Click(object sender, EventArgs e)
        {
            this.text = "";
            this.richTextBox1.Text = this.text;
            this.textBox1.Text = this.text;
        }
        /// <summary>退格按钮的触发事件</summary>
        private void button19_Click(object sender, EventArgs e)
        {
            if (tab > 0)
            {
                tab -= 1;
            }
            this.text = "";
            for (int i = 0; i < tab; i++)
            {
                this.text += this.texts[i];
            }

            this.richTextBox1.Text = this.text;
        }
        /// <summary> 后退按钮的触发事件</summary>
        private void button21_Click(object sender, EventArgs e)
        {
            Precord--;
            if (Precord < 0)
            {
                Precord = RecordNum;
            }
            /// <remarks>this.text = this.record[Precord];</remarks>
            this.richTextBox1.Text = this.record[Precord];
        }
        /// <summary>前进按钮的触发事件</summary>
        private void button22_Click(object sender, EventArgs e)
        {
            Precord++;
            if (Precord > RecordNum)
            {
                Precord = 0;
            }
            /// <remark>this.text = this.record[Precord];</remark>
            this.richTextBox1.Text = this.record[Precord];
        }
    }
}
