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
        private bool isMouseHover = false;
        private int m_ArcRadious = 0;
        public int ArcRadious
        {
            get { return m_ArcRadious; }
            set { m_ArcRadious = value; }
        }

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

            GraphicsPath _path = new GraphicsPath();
            int _diameter = m_ArcRadious * 2;
            _path.AddArc(ClientRectangle.Left, ClientRectangle.Bottom - _diameter, _diameter, _diameter - 1, 90, 90);
            _path.AddArc(ClientRectangle.Left, ClientRectangle.Top, _diameter, _diameter, 180, 90);
            _path.AddArc(ClientRectangle.Right - _diameter, ClientRectangle.Top, _diameter - 1, _diameter, 270, 90);
            _path.AddArc(ClientRectangle.Right - _diameter, ClientRectangle.Bottom - _diameter, _diameter - 1, _diameter - 1, 0, 90);
            _path.CloseFigure();

            PaintCenter(pevent.Graphics, _path);
            PaintBorder(pevent.Graphics, _path);
            PaintText(pevent.Graphics);
        }


        private void PaintText(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(base.Text, this.Font, Brushes.Black, base.DisplayRectangle, sf);
        }

        private void PaintBorder(Graphics g, GraphicsPath p)
        {
            using (var pen = new Pen(Color.FromArgb(60, Color.Black), 1))
                g.DrawPath(pen, p);
        }

        private void PaintCenter(Graphics g, GraphicsPath p)
        {
            if (!isMouseHover)
            {
                var lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(128, 191, 191, 191), Color.FromArgb(128, 255, 255, 255),
                                                        LinearGradientMode.ForwardDiagonal);
                g.FillPath(lgb, p);
            }
            else
            {
                var lgb = new LinearGradientBrush(ClientRectangle, Color.Transparent, Color.Lime,
                                                      LinearGradientMode.ForwardDiagonal);
                g.FillPath(lgb, p);
            }
        }

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
            isMouseHover = ClientRectangle.Contains(e.Location);
            Invalidate();
        }
    }
}
