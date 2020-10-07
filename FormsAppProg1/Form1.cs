using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
        private TabControl _tabControl;
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
            _lbl.Size = new Size(100, 30);
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

            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));

            tn.Nodes.Add(new TreeNode("MessageBox"));
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
            else if (e.Node.Text == "Kaart-TabControl")
            {
                const int MAX_PAGE = 3;
                string selectTabInputBox = Interaction.InputBox("Sisesta mis leht tuleb avada?\nnt: 1, 2, 3", "Vali leht", "1");
                if (_tabControl == null)
                {
                    _tabControl = new TabControl();
                    _tabControl.Location = new Point(300, 150);
                    _tabControl.Size = new Size(200, 200);
                    string[] tabNames = new string[] {"Esimene", "Teine", "Kolmas"};
                    string[] tabImages = new string[] {"george.png", "peppa.png", "dad.png"};
                    
                    for (int i = 0; i < 3; i++)
                    {
                        _tabControl.TabPages.Add(new TabPage(tabNames[i]));
                        Bitmap bitmap = new Bitmap(tabImages[i]);
                        PictureBox picture = new PictureBox()
                        {
                            Image = bitmap,
                            Size = new Size(80,140),
                            SizeMode = PictureBoxSizeMode.Zoom
                        };
                        _tabControl.TabPages[i].Controls.Add(picture);
                    }
                    Controls.Add(_tabControl);
                }
                
                var pagesNumbers = Enumerable.Range(1, MAX_PAGE).Select(x => x.ToString()).ToArray(); // String values 1,2,3 using LINQ
                if (pagesNumbers.Contains(selectTabInputBox)) // Checks that user's input contains numbers 1, 2, 3
                {
                    int receivedTabIndex = Int32.Parse(selectTabInputBox) - 1 ; // User defines tab to open using ints 1, 2, 3
                    _tabControl.SelectedIndex = receivedTabIndex; // Opens tab, that defines user
                }
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("Hello, World!",
                    "MessageBox",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                var showInputBox =
                    MessageBox.Show("Tahad InputBox näha?", "Aken koos nupudega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (showInputBox == DialogResult.Yes)
                {
                    string textInputBox = Interaction.InputBox("Sisesta siia mingi text", "InputBox", "Mingi text");
                    if (!_lbl.Text.Contains(textInputBox) && textInputBox != "")
                    {
                        if (!Controls.Contains(_lbl))
                        {
                            Controls.Add(_lbl);
                        }
                        _lbl.Text += textInputBox + "\n";
                        _lbl.Height += 15;
                    }
                }
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