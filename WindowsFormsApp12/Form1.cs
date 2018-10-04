using Microsoft.EntityFrameworkCore;
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
	public partial class Form1 : Form
	{
		product p = new product { Name="test"};
		public Form1()
		{
			InitializeComponent();
			using (ApplicationContext db = new ApplicationContext())
			{
				foreach (product u in db.Users.ToList())
				{
					listBox1.Items.Add($"{u.Id}.{u.Name} - {u.Price}");
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Form2 myForm = new Form2(this, p);

			if (myForm.ShowDialog(this) == DialogResult.OK)
			{
				listBox1.Items.Clear();
				p = myForm.MyProperty;
				MessageBox.Show(p.Name);
				using (ApplicationContext db = new ApplicationContext())
				{
					db.Users.Add(p);

					db.SaveChanges();

					var products = db.Users.ToList();
					foreach (product u in products)
					{
						listBox1.Items.Add($"{u.Id}.{u.Name} - {u.Price}");
					}
				}
			}
			myForm.Dispose();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Database.EnsureDeleted();
				db.SaveChanges();
				listBox1.Items.Clear();
			}
		}
	}
}
