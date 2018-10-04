using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		product pr;
		public product MyProperty
		{
			get
			{
				return pr;
			}
		}
		public Form2(Form1 f, product p)
		{
			pr = p;
			InitializeComponent();
			textBox1.Text = p.Name;
			button1.DialogResult = DialogResult.OK;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			pr = new product { Name = textBox1.Text, Price = Convert.ToInt32(textBox2.Text) };

		}
	}
}
