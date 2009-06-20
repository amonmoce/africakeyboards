using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Kasahorow.KeyboardInstaller
{
    public partial class LineControl : UserControl
    {
        private bool isHorizontal = true;

        public bool IsHorizontal
        {
            get { return isHorizontal; }
            set { isHorizontal = value; }
        }
	
	
        public LineControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            if (IsHorizontal)
            {
                e.Graphics.DrawLines(new Pen(Color.DimGray, 1),
                    new Point[] { 
								new Point(1, 1), 
								new Point(Width-2, 1)
							}
                    );

                e.Graphics.DrawLines(new Pen(Color.White, 1),
                    new Point[] { 
								new Point(1, 2), 
								new Point(Width-2, 2)
							}
                    );
            }
            else
            {
                e.Graphics.DrawLines(new Pen(Color.DimGray, 1),
                    new Point[] { 
								new Point(1, 1), 
								new Point(1, Height-1)
							}
                    );

                e.Graphics.DrawLines(new Pen(Color.White, 1),
                    new Point[] { 
								new Point(2, 1), 
								new Point(2, Height-1)
							}
                    );
            }
        }
    }
}
