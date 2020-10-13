using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FormsAppProg1
{
    public partial class Form1 : Form
    {
        private MainMenu _menu;
        private readonly TreeView _tree;
        private readonly Button _btn;
        private readonly Label _lbl;
        private readonly CheckBox _boxLbl;
        private readonly CheckBox _boxBtn;
        private RadioButton _r1, _r2;
        private TextBox _textbox;
        private PictureBox _pictureBox;
        private TabControl _tabControl;
        private ListBox _listbox;
        private DataGridView _dataGridView;
        private string[] listBoxItemNames;
        private Color[] listBoxItemColors;
        public Form1()
        {
            Height = 500;
            Width = 600;
            Text = "Vorm elementidega";
            _tree = new TreeView
            {
                Dock = DockStyle.Left
            };

            _tree.AfterSelect += TreeOnAfterSelect;
            
            TreeNode tn = new TreeNode("Elemendid");
            
            tn.Nodes.Add(new TreeNode("Nupp-Button"));

            _btn = new Button
            {
                Text = "Vajuta siia",
                Location = new Point(200, 100),
                Height = 40,
                Width = 120
            };
            _btn.Click += BtnOnClick;
            
            tn.Nodes.Add(new TreeNode("Silt-Label"));

            _lbl = new Label
            {
                Text = "Tarkvaraarendajad",
                Size = new Size(100, 30),
                Location = new Point(150, 200)
            };

            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));

            _boxBtn = new CheckBox
            {
                Text = "Näita nupp",
                Location = new Point(200, 30),
                Checked = true
            };
            _boxBtn.CheckedChanged += Box_btnOnCheckedChanged;

            _boxLbl = new CheckBox
            {
                Text = "Näita silt",
                Location = new Point(150, 70),
                Checked = true
            };
            _boxLbl.CheckedChanged += Box_lblOnCheckedChanged;
            _tree.Nodes.Add(tn);
            Controls.Add(_tree);

            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));

            tn.Nodes.Add(new TreeNode("Tekstkast-Textbox"));

            tn.Nodes.Add(new TreeNode("PictureBox"));

            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));

            tn.Nodes.Add(new TreeNode("MessageBox"));

            tn.Nodes.Add(new TreeNode("ListBox"));

            tn.Nodes.Add(new TreeNode("DataGridView"));

            tn.Nodes.Add(new TreeNode("Menu"));
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
                _r1 = new RadioButton
                {
                    Text = "Nupp vasakule",
                    Location = new Point(320, 30),
                    Checked = true
                };
                _r1.CheckedChanged += Radiobuttons_Changed;
                _r2 = new RadioButton
                {
                    Text = "Nupp paremale",
                    Location = new Point(320, 70)
                };
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
                _textbox = new TextBox
                {
                    Multiline = true,
                    Text = text,
                    Location = new Point(475, 400),
                    Width = 100,
                    Height = 100
                };
                Controls.Add(_textbox);
            }
            else if (e.Node.Text == "PictureBox")
            {
                _pictureBox = new PictureBox
                {
                    Image = new Bitmap("image.jpg"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(450, 50),
                    BorderStyle = BorderStyle.Fixed3D
                };
                Controls.Add(_pictureBox);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                const int MAX_PAGE = 3;
                string selectTabInputBox = Interaction.InputBox("Sisesta mis leht tuleb avada?\nnt: 1, 2, 3", "Vali leht", "1");
                if (_tabControl == null)
                {
                    _tabControl = new TabControl
                    {
                        Location = new Point(300, 150),
                        Size = new Size(200, 150)
                    };
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
                
                var pagesNumbers = Enumerable.Range(1, MAX_PAGE).Select(x => x.ToString()).ToArray(); // String values 1, 2, 3 using LINQ
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
            else if (e.Node.Text == "ListBox")
            {
                _listbox = new ListBox();
                listBoxItemNames = new string[] { "Sinine", "Kolllane", "Roheline", "Punane" };
                listBoxItemColors = new Color[] { Color.Blue, Color.Yellow, Color.Green, Color.Red };
                foreach (var listBoxItemName in listBoxItemNames)
                {
                    _listbox.Items.Add(listBoxItemName);
                }
                _listbox.Height = listBoxItemNames.Length * 15;
                _listbox.Width = listBoxItemNames.OrderByDescending(n => n.Length).First().Length * 10;
                _listbox.Location = new Point(500, 100);
                _listbox.SelectedIndexChanged += ListBoxSelectedItemChanged;
                Controls.Add(_listbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("..//..//files//example.xml");
                _dataGridView = new DataGridView
                {
                    DataSource = dataSet,
                    AutoGenerateColumns = true,
                    DataMember = "email",
                    Location = new Point(150, 300),
                    Height = 140,
                    Width = 250
                };
                Controls.Add(_dataGridView);
            }
            else if (e.Node.Text == "Menu")
            {
                _menu = new MainMenu();
                _menu.MenuItems.Add("File");
                _menu.MenuItems.Add("Edit");
                _menu.MenuItems[0].MenuItems.Add("Exit", new EventHandler(ExitClicked));
                _menu.MenuItems[1].MenuItems.Add("Clear All", new EventHandler(ClearAllClicked));
                _menu.MenuItems[1].MenuItems.Add("Change Background Color", new EventHandler(ChangeColorClicked));
                _menu.MenuItems[1].MenuItems.Add("Change Menu Position", new EventHandler(ChangeMenuOrder));
                Menu = _menu;
            }
        }

        private void ChangeColorClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }

        private void ClearAllClicked(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(_tree);
            BackColor = DefaultBackColor;
        }
        
        private void ChangeMenuOrder(object sender, EventArgs e)
        {
            if (_menu.RightToLeft == RightToLeft.No)
            {
                _menu.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                _menu.RightToLeft = RightToLeft.No;
            }
            Refresh();
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void ListBoxSelectedItemChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            lb.BackColor = listBoxItemColors[_listbox.SelectedIndex];
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