// Copyright (c) 2014 Takashi Yoshizawa

using System.Drawing;
using System.Windows.Forms;

namespace SeleniumExcelAddIn
{
    public class CustomProfessionalColorTable : ProfessionalColorTable
    {
        public CustomProfessionalColorTable(Color theColor)
            : base()
        {
            this.color = theColor;
        }

        private Color color;

        public override Color ToolStripBorder
        {
            get
            {
                return this.color;
            }
        }

        public override Color ToolStripGradientBegin
        {
            get
            {
                return this.color;
            }
        }

        public override Color ToolStripGradientMiddle
        {
            get
            {
                return this.color;
            }
        }

        public override Color ToolStripPanelGradientEnd
        {
            get
            {
                return this.color;
            }
        }
    }
}
