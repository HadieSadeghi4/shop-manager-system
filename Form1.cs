using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myshop1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myshopDataSet.Customeres' table. You can move, or remove it, as needed.
            this.customeresTableAdapter.Fill(this.myshopDataSet.Customeres);
            // TODO: This line of code loads data into the 'myshopDataSet1.RegisterFactor' table. You can move, or remove it, as needed.
            this.registerFactorTableAdapter.Fill(this.myshopDataSet1.RegisterFactor);
            // TODO: This line of code loads data into the 'myshopDataSet1.Factor' table. You can move, or remove it, as needed.
            this.factorTableAdapter.Fill(this.myshopDataSet1.Factor);
            // TODO: This line of code loads data into the 'myshopDataSet2.Goods' table. You can move, or remove it, as needed.
            this.goodsTableAdapter1.Fill(this.myshopDataSet2.Goods);
            // TODO: This line of code loads data into the 'myshopDataSet.Goods' table. You can move, or remove it, as needed.
            this.goodsTableAdapter.Fill(this.myshopDataSet.Goods);
            
            // TODO: This line of code loads data into the 'myshopDataSet.RegisterFactor' table. You can move, or remove it, as needed.
            this.registerFactorTableAdapter.Fill(this.myshopDataSet.RegisterFactor);
            
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveNext();
        }

        private void btsLast_Click(object sender, EventArgs e)
        {
            goodsBindingSource.MoveLast();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = goodsDataGridVie.CurrentCell.RowIndex;
            txtGoodsCode.Text = goodsDataGridVie.Rows[index].Cells[0].Value.ToString();
            txtGoodsName.Text= goodsDataGridVie.Rows[index].Cells[1].Value.ToString();
            txtUnitPrice.Text = goodsDataGridVie.Rows[index].Cells[2].Value.ToString();
            txtStock.Text = goodsDataGridVie.Rows[index].Cells[3].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtGoodsCode.TextLength > 0 && txtGoodsName.TextLength > 0 && txtStock.TextLength > 0 && txtUnitPrice.TextLength > 0)
            {
                try
                {
                    goodsTableAdapter.InsertQuery1(int.Parse(txtGoodsCode.Text), txtGoodsName.Text, int.Parse(txtUnitPrice.Text), txtStock.Text);
                    goodsTableAdapter.Fill(myshopDataSet.Goods);
                    MessageBox.Show("کالا با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGoodsCode.Clear();
                    txtGoodsName.Clear();
                    txtStock.Clear();
                    txtUnitPrice.Clear();
                }
                catch
                {
                    MessageBox.Show(" خطا در ثبت کالا", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtGoodsCode.TextLength > 0)
            {
                goodsTableAdapter.DeleteQuery(int.Parse(txtGoodsCode.Text));
                goodsTableAdapter.Fill(myshopDataSet.Goods);
                MessageBox.Show("با موفقیت حذف شد","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtGoodsCode.TextLength > 0 && txtGoodsName.TextLength > 0 && txtUnitPrice.TextLength > 0&&txtStock.TextLength>0)
            {
                goodsTableAdapter.UpdateQuery(int.Parse(txtGoodsCode.Text),txtGoodsName.Text,int.Parse(txtUnitPrice.Text), txtStock.Text, int.Parse(txtGoodsCode.Text));
                goodsTableAdapter.Fill(myshopDataSet.Goods);
                MessageBox.Show("با موفقیت ویرایش شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtFGoodsCode_KeyDown(object sender, KeyEventArgs e)
        {
            lblPrice.Text = "";
            lblGoodsName.Text = "";
            if (e.KeyCode == Keys.Enter)
                if(txtFGoodsCode.TextLength>0)
                {
                    goodsTableAdapter.FillByGoodsCode(myshopDataSet.Goods, int.Parse(txtFGoodsCode.Text));
                    if (myshopDataSet.Goods.Rows.Count > 0)
                    {
                        lblGoodsName.Text = myshopDataSet.Goods.Rows[0]["GoodsName"].ToString();
                        lblPrice.Text = myshopDataSet.Goods.Rows[0]["UnitPrice"].ToString();
                        lblStock.Text = myshopDataSet.Goods.Rows[0]["stock"].ToString();
                    }
                }
        }

        private void txtFGoodsCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGoodsTab(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            listBox2.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            txtGoodsCode.Clear();
            txtGoodsName.Clear();
            txtUnitPrice.Clear();
            txtStock.Clear();
        }

        private void btnInsertGoodsFactor_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            txtFGoodsCode.Text = txtGoodsCode.Text;
            lblGoodsName.Text = txtGoodsName.Text;
            lblPrice.Text = txtUnitPrice.Text;
            lblStock.Text = txtStock.Text;
            txtGoodsCode.Focus();
        }

        private void btnCustomerTab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Customercode.Focus();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void treeView6_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnInsertGoods_Click(object sender, EventArgs e)
        {
            
            int n = FactorDataGridView.Rows.Count - 1;
            FactorDataGridView.Rows.Add();
            FactorDataGridView.Rows[n].Cells[0].Value = txtFGoodsCode.Text;
            FactorDataGridView.Rows[n].Cells[1].Value = lblGoodsName.Text;
            FactorDataGridView.Rows[n].Cells[2].Value = txtFAmount.Text;
            FactorDataGridView.Rows[n].Cells[3].Value = lblPrice.Text;
            FactorDataGridView.Rows[n].Cells[4].Value = int.Parse(txtFAmount.Text) * int.Parse(lblPrice.Text);
            int sum = 0;
            for (int i = 0; i < n+1; i++)
            {
                int price = (int)FactorDataGridView.Rows[i].Cells[4].Value;
                sum += price;
            }
            lblAllCost.Text = sum.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Customercode.TextLength>0 && txtCustomerName.TextLength>0 && txtCustomerFamily.TextLength>0  && txtCustomeMobile.TextLength>0)
            {
                try
                {
                    customeresTableAdapter.CustomerInsertQuery(int.Parse( Customercode.Text), txtCustomerName.Text, txtCustomerFamily.Text, txtCustomeMobile.Text);
                    customeresTableAdapter.Fill(myshopDataSet.Customeres);
                    MessageBox.Show("مشتری با موفقیت ثبت شد", "ثیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Customercode.Clear();
                    txtCustomerName.Clear();
                    txtCustomerFamily.Clear();
                    txtCustomeMobile.Clear();
                }
                catch
                {
                    MessageBox.Show(" خطا در ثبت مشتری", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bynSaveFactor_Click(object sender, EventArgs e)
        {
            
                    int h = RFactordataGridView.RowCount - 1;
                    RFactordataGridView.Rows.Add();
                    RFactordataGridView.Rows[h].Cells[0].Value = txtFGoodsCode.Text;
                    RFactordataGridView.Rows[h].Cells[1].Value = lblGoodsName.Text;
                    RFactordataGridView.Rows[h].Cells[2].Value = txtFAmount.Text;
                    RFactordataGridView.Rows[h].Cells[3].Value = lblPrice.Text;
                    RFactordataGridView.Rows[h].Cells[4].Value = int.Parse(lblPrice.Text) * int.Parse(txtFAmount.Text);
                    Fdone.Text = (int.Parse(Fdone.Text) + int.Parse(txtFAmount.Text) * int.Parse(lblPrice.Text)).ToString();
                    txtFGoodsCode.Text = "1";
                    lblGoodsName.Text = "شکلات";
                    txtFGoodsCode.Text = "1";
                    lblGoodsName.Text = "0";
                    MessageBox.Show("فاکتور با موفقیت ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
   
            FactorDataGridView.Rows.Clear();
            txtCcode.Clear();
            txtFGoodsCode.Clear();
            txtFAmount.Clear();
            lblGoodsName.Text = "شکلات";
            lblPrice.Text = "0";
            lblStock.Text = "0";
            lblAllCost.Text = "0";
            CustomerFamily.Text = "مشتری مهمان";
            Mobile.Text = "0";
            MessageBox.Show("با موفقیت پاک شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = (int)RFactordataGridView.Rows[e.RowIndex].Cells[4].Value;
            if (RFactordataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                RFactordataGridView.Rows.RemoveAt(e.RowIndex);
            Fdone.Text = (int.Parse(Fdone.Text) - p).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RFactordataGridView.Rows.Clear();
            Fdone.Text = "0";
            tabControl1.SelectedTab = tabPage1;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtFAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void CustomerdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = CustomerdataGridView.CurrentCell.RowIndex;
            Customercode.Text = CustomerdataGridView.Rows[index].Cells[0].Value.ToString();
            txtCustomerName.Text= CustomerdataGridView.Rows[index].Cells[1].Value.ToString();
            txtCustomerFamily.Text= CustomerdataGridView.Rows[index].Cells[2].Value.ToString();
            txtCustomeMobile.Text = CustomerdataGridView.Rows[index].Cells[3].Value.ToString();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Customercode.TextLength > 0)
            {
                try
                {
                    customeresTableAdapter.CustomerDeleteQuery(int.Parse(Customercode.Text));
                    customeresTableAdapter.Fill(myshopDataSet.Customeres);
                    MessageBox.Show("با موفقیت حذف شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("خطا در حذف", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Customercode.TextLength > 0 && txtCustomerName.TextLength > 0 && txtCustomerFamily.TextLength > 0 && txtCustomeMobile.TextLength > 0)
            {
                try
                {
                    customeresTableAdapter.UpdateQueryCusromer(int.Parse(Customercode.Text), txtCustomerName.Text, txtCustomerFamily.Text, txtCustomeMobile.Text, int.Parse(Customercode.Text));
                    customeresTableAdapter.Fill(myshopDataSet.Customeres);
                    MessageBox.Show("با موفقیت ویرایش شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("خطا در ویرایش مشتری", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Customercode.Clear();
            txtCustomerName.Clear();
            txtCustomerFamily.Clear();
            txtCustomeMobile.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void lblAllCost_Click(object sender, EventArgs e)
        {

        }

        private void txtCcode_KeyDown(object sender, KeyEventArgs e)
        {
            CustomerFamily.Text = "";
            Mobile.Text = "";
            if(e.KeyCode==Keys.Enter)
                if (txtCcode.TextLength > 0)
                {
                    customeresTableAdapter.FillByCustomerCode(myshopDataSet.Customeres, int.Parse(txtCcode.Text));
                    if (myshopDataSet.Customeres.Rows.Count > 0)
                    {
                        CustomerFamily.Text = myshopDataSet.Customeres.Rows[0]["CustomerFamily"].ToString();
                        Mobile.Text = myshopDataSet.Customeres.Rows[0]["Mobile"].ToString();
                    }
                }
        }

        private void Cnumber_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCfamily_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Fdone_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }
    }
}
