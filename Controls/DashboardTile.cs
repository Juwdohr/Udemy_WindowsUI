using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsUI
{
    public class DashboardTile : Panel
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        #region Enums
        public enum Direction
        {
            Any,
            Horizontal,
            Vertical
        }
        #endregion
        #region Propeties
        private string _runMethodName = "";
        private Direction _movementDirection = Direction.Any;
        public Direction MovementDirection
        {
            get { return _movementDirection; }
            set { _movementDirection = value; }
        }
        public string RunMethodName
        {
            get { return _runMethodName; }
            set { _runMethodName = value; }
        }
        #endregion
        #region Events
        public event EventHandler TileClicked;
        public event EventHandler TileRightClicked;
        public event EventHandler TileMoved;

        private void TileClickedFunction()
        {
            if (TileClicked != null)
            {
                TileClicked(this, new EventArgs());
            }
        }
        private void TileRightClickedFunction()
        {
            if (TileClicked != null)
            {
                TileRightClicked(this, new EventArgs());
            }
        }
        public void TileMovedFunction()
        {
            if (TileMoved != null)
            {
                TileMoved(this, new EventArgs());
            }
        }
        #endregion
        #region Windows Messages
        protected override void WndProc(ref Message m)
        {
            const int WM_NCPAINT = 133;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                Graphics g = Graphics.FromHdc(hdc);
                Rectangle rDraw = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                Pen pBottom = new Pen(Color.Gray, 3);
                Pen pTop = new Pen(Color.White, 3);
                g.DrawRectangle(pBottom, rDraw);
                Point[] pts = new Point[3];

                pts[0] = new Point(0, this.Height - 1);
                pts[1] = new Point(0, 0);
                pts[2] = new Point(this.Width - 1, 0);


                g.DrawLines(pTop, pts);
                ReleaseDC(this.Handle, hdc);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion
        #region init
        public DashboardTile()
        {
            // shadow part
            this.BorderStyle = BorderStyle.Fixed3D;
            // this.Paint += ParentPaint;

            this.Paint += delegate (object sender, PaintEventArgs e)
            {
                Graphics g = this.Parent.CreateGraphics();
                Matrix mx = new Matrix(1F, 0, 0, 1F, 4, 4);
                Rectangle rdraw = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                g.Transform = mx;
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), rdraw);
                g.Dispose();
            };

            // Moving Part
            bool Dragging = false;
            bool Dragged = false;
            Point DragStart = Point.Empty;
            this.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                Dragging = true;
                Dragged = false;
                DragStart = new Point(e.X, e.Y);
                this.Capture = true;
            };
            this.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                Dragging = false;
                this.Capture = false;
                if (!Dragged)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        TileRightClickedFunction();
                    }
                    else
                    {
                        TileClickedFunction();
                    }
                }
                else // Dragged
                {
                    TileMovedFunction();
                }
            };
            this.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (Dragging)
                {
                    Dragged = true;
                    if (MovementDirection != Direction.Vertical)
                        this.Left = Math.Max(0, e.X + this.Left - DragStart.X);
                    if (MovementDirection != Direction.Horizontal)
                        this.Top = Math.Max(0, e.Y + this.Top - DragStart.Y);
                }
            };
        }
        #endregion
    }
}