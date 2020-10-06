using System.Drawing;
using System.Windows.Forms;

namespace FormsAppProg1
{
    public partial class Form1 : Form
    {
        private TreeView tree;
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
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void TreeOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                Button btn = new Button();
                btn.Text = "Vajuta siia";
                btn.Location = new Point(50, 10);
                btn.Height = 10;
                btn.Width = 40;
                this.Controls.Add(btn);
            }
        }
    }
}