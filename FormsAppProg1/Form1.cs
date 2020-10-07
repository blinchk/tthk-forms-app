using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FormsAppProg1
{
    public partial class Form1 : Form
    {
        private TreeView _tree;
        private Button _btn;
        private Label _lbl;
        private CheckBox _boxLbl, _boxBtn;
        private RadioButton _r1, _r2;
        private TextBox _textbox;
        private PictureBox _pictureBox;
        public Form1()
        {
            Height = 500;
            Width = 600;
            Text = "Vorm elementidega";
            _tree = new TreeView();
            _tree.Dock = DockStyle.Left;
            
            _tree.AfterSelect += TreeOnAfterSelect;
            
            TreeNode tn = new TreeNode("Elemendid");
            
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            
            _btn = new Button();
            _btn.Text = "Vajuta siia";
            _btn.Location = new Point(200, 100);
            _btn.Height = 40;
            _btn.Width = 120;
            _btn.Click += BtnOnClick;
            
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            
            _lbl = new Label();
            _lbl.Text = "Tarkvaraarendajad";
            _lbl.Size = new Size(150, 30);
            _lbl.Location = new Point(150, 200);
            
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            
            _boxBtn = new CheckBox();
            _boxBtn.Text = "Näita nupp";
            _boxBtn.Location = new Point(200, 30);
            _boxBtn.CheckedChanged += Box_btnOnCheckedChanged;
            
            _boxLbl = new CheckBox();
            _boxLbl.Text = "Näita silt";
            _boxLbl.Location = new Point(150, 70);
            _boxLbl.CheckedChanged += Box_lblOnCheckedChanged;
            _tree.Nodes.Add(tn);
            Controls.Add(_tree);

            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));

            tn.Nodes.Add(new TreeNode("Tekstkast-Textbox"));

            tn.Nodes.Add(new TreeNode("PictureBox"));
        }

        private void TreeOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                Controls.Add(_btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                Controls.Add(_lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                Controls.Add(_boxBtn);
                Controls.Add(_boxLbl);
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                _r1 = new RadioButton();
                _r1.Text = "Nupp vasakule";
                _r1.Location = new Point(320, 30);
                _r1.CheckedChanged += Radiobuttons_Changed;
                _r2 = new RadioButton();
                _r2.Text = "Nupp paremale";
                _r2.Location = new Point(320, 70);
                _r2.CheckedChanged += Radiobuttons_Changed;
                Controls.Add(_r1);
                Controls.Add(_r2);
            }
            else if (e.Node.Text == "Tekstkast-Textbox")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch
                {
                    text = "Tekst puudub";
                }
                _textbox = new TextBox();
                _textbox.Multiline = true;
                _textbox.Text = text;
                _textbox.Location = new Point(300, 300);
                _textbox.Width = 200;
                _textbox.Height = 200;
                Controls.Add(_textbox);
            }
            else if (e.Node.Text == "PictureBox")
            {
                _pictureBox = new PictureBox();
                _pictureBox.Image = new Bitmap("image.jpg");
                _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                _pictureBox.Location = new Point(450, 50);
                _pictureBox.BorderStyle = BorderStyle.Fixed3D;
                Controls.Add(_pictureBox);
            }
        }

        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (_r2.Checked)
            {
                _btn.Location = new Point(350, 100);
            }
            else
            {
                _btn.Location = new Point(200, 100);
            }
        }

        private void Box_lblOnCheckedChanged(object sender, EventArgs e)
        {
            if (_boxLbl.Checked)
            {
                Controls.Add(_lbl);
            }
            else
            {
                Controls.Remove(_lbl);
            }
        }

        private void Box_btnOnCheckedChanged(object sender, EventArgs e)
        {
            if (_boxBtn.Checked)
            {
                Controls.Add(_btn);
            }
            else
            {
                Controls.Remove(_btn);
            }
        }

        private void BtnOnClick(object sender, EventArgs e)
        {
            if (_btn.BackColor == Color.Blue)
            {
                _btn.BackColor = Color.Red;
                _lbl.BackColor = Color.Green;
                _lbl.ForeColor = Color.Orange;
            }
            else
            {
                _btn.BackColor = Color.Blue;
                _lbl.ForeColor = Color.Green;
                _lbl.BackColor = Color.Orange;
            }
        }
    }
}