using System.Diagnostics;
using System.Windows.Forms;

namespace RoundButton
{
    public partial class Form1 : Form
    {
        private MyButton myButton1;
        public Form1()
        {
            InitializeComponent();
            this.myButton1 = new RoundButton.MyButton();
            this.myButton1.Size = new System.Drawing.Size(100, 100);
            this.myButton1.Location = new System.Drawing.Point((this.ClientRectangle.Width - this.myButton1.Width) / 2,
                (this.ClientRectangle.Height - this.myButton1.Height) / 2);
            this.myButton1.ArcRadious = 10;
            this.myButton1.Image = global::RoundButton.Properties.Resources.Image1;
            this.myButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Controls.Add(this.myButton1);
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if (null == this.myButton1) return;
            this.myButton1.Location = new System.Drawing.Point((this.ClientRectangle.Width -this.myButton1.Width)/2 ,
                (this.ClientRectangle.Height - this.myButton1.Height) / 2 );
        }
    }
}
