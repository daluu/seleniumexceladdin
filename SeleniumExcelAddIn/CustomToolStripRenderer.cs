// Copyright (c) 2014 Takashi Yoshizawa

using System.Drawing;
using System.Windows.Forms;

namespace SeleniumExcelAddIn
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer(Color color)
            : base(new CustomProfessionalColorTable(color))
        {
            this.RoundedEdges = false;
        }
    }
}
