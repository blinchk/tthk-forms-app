using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FormsAppProg1
{
    public partial class Form1 : Form
    {
        private TreeView tree;
        private Button btn;
        private Label lbl;
        private CheckBox box_lbl, box_btn;
        private RadioButton r1, r2;
        private TextBox textbox;
        public Form1()
        {
            Height = 500;
            Width = 600;
            Text = "Vorm elementidega";
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
            Controls.Add(tree);

            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));

            tn.Nodes.Add(new TreeNode("Tekstkast-Textbox"));
        }

        private void TreeOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                Controls.Add(box_btn);
                Controls.Add(box_lbl);
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "Nupp vasakule";
                r1.Location = new Point(320, 30);
                r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                r2 = new RadioButton();
                r2.Text = "Nupp paremale";
                r2.Location = new Point(320, 70);
                r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                Controls.Add(r1);
                Controls.Add(r2);
            }
            else if (e.Node.Text == "Tekstkast-Textbox")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch (FileNotFoundException exception)
                {
                    text = "Tekst puudub";
                }
                textbox = new TextBox();
                textbox.Multiline = true;
                textbox.Text = text;
                textbox.Location = new Point(300, 300);
                textbox.Width = 200;
                textbox.Height = 200;
                Controls.Add(textbox);
            }
        }

        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (r2.Checked)
            {
                btn.Location = new Point(350, 100);
            }
            else
            {
                btn.Location = new Point(200, 100);
            }
        }

        private void Box_lblOnCheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btnOnCheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
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