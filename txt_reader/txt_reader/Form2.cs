using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//=================================================
//        created by JohnWes7
//        https://github.com/JohnWes7
//=================================================

namespace txt_reader
{
    public partial class Form2 : Form
    {
        private static string[] DropItem { get => TXTData.DropItem; }

        public Form2()
        {
            InitializeComponent();

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(DropItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(comboBox1.SelectedItem + "  " + comboBox1.SelectedIndex);
        }
    }
}
