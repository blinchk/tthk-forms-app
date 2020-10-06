using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsAppProg1
{
    public partial class Form1 : Form
    {
        private TreeView tree;
        private Button btn;
        private Label lbl;
        private CheckBox box_lbl, box_btn;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += TreeOnAfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += BtnOnClick;
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Tarkvaraarendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            box_btn = new CheckBox();
            box_btn.Text = "Näita nupp";
            box_btn.Location = new Point(200, 30);
            box_btn.CheckedChanged += Box_btnOnCheckedChanged;
            box_lbl = new CheckBox();
            box_lbl.Text = "Näita silt";
            box_lbl.Location = new Point(150, 70);
            box_lbl.CheckedChanged += Box_lblOnCheckedChanged;
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void TreeOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                this.Controls.Add(box_btn);
                this.Controls.Add(box_lbl);
                
            }
        }

        private void Box_lblOnCheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                lbl.Visible = true;
            }
            else
            {
                lbl.Visible = false;
            }
        }

        private void Box_btnOnCheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                btn.Visible = true;
            }
            else
            {
                btn.Visible = false;
            }
        }

        private void BtnOnClick(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.Orange;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.ForeColor = Color.Green;
                lbl.BackColor = Color.Orange;
            }
        }
    }
}