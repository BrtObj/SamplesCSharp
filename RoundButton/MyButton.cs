using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RoundButton
{
    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            base.OnPaintBackground(pevent);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //pevent.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            PaintCenter(pevent.Graphics);
            PaintBorder(pevent.Graphics);
            PaintText(pevent.Graphics);
        }


        private void PaintText(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(base.Text, this.Font, Brushes.Black, base.DisplayRectangle, sf);
        }
        private void PaintBorder(Graphics g)
        {
            using (var pen = new Pen(Color.FromArgb(60, Color.Black), 1))
                g.DrawEllipse(pen, getCenterRect());
        }

        private void PaintCenter(Graphics g)
        {
            if (!isMouseHover)
            {
                // Color.FromArgb(128 ,是透明度
                var lgb = new LinearGradientBrush(getCenterRect(), Color.FromArgb(128, 191, 191, 191), Color.FromArgb(128, 255, 255, 255),
                                                        LinearGradientMode.ForwardDiagonal);

                g.FillEllipse(lgb, getCenterRect());
            }
            else
            {
                var lgb = new LinearGradientBrush(getCenterRect(), Color.Transparent, Color.Lime,
                                                      LinearGradientMode.ForwardDiagonal);
                g.FillEllipse(lgb, getCenterRect());
            }

        }

        private Rectangle getCenterRect()
        {
            Rectangle rect = new Rectangle(4, 4, this.Width - 8, this.Height - 8);
            return rect;
        }

        private bool isMouseHover = false;
        private void MyButton_MouseHover(object sender, EventArgs e)
        {
            isMouseHover = true;
            Invalidate();
        }

        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            isMouseHover = false;
            Invalidate();
        }

        private void MyButton_MouseMove(object sender, MouseEventArgs e)
        {
            isMouseHover = getCenterRect().Contains(e.Location);
            Invalidate();
        }
    }
}
