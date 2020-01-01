using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class ArrangeForm : Form
    {
        public int Arrange_x;
        public int Arrange_y;
        public int Arrange_m;
        public bool ok;
        public ArrangeForm()
        {
            InitializeComponent();
            button2.DialogResult = DialogResult.No;
            numericUpDown2.ValueChanged += numericUpDown1_ValueChanged;
            numericUpDown1.Value = 8;
            numericUpDown2.Value = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arrange_x = (int)numericUpDown1.Value;
            Arrange_y = (int)numericUpDown2.Value;
            Arrange_m = (int)numericUpDown3.Value;
            ok = true;
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = numericUpDown1.Value * numericUpDown2.Value - 1;
        }
    }
}
