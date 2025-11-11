using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class Form1 : Form
    {
        // Create an object of the Graphics class, so we can use the commands for drawing lines and shapes
        Graphics graphics;

        // Create an object of the Pen class, so we can have something to draw with
        Pen pen; 

        // The randomly generated diameter of the user-drawn circles, and coordinates useful for the freestyle drawing feature will be stored in these 3 variables, respectively
        int circle_diameter, coordinate_x, coordinate_y; 

        // If this variable is set to "true", the user can freely draw on the form
        bool freestyle_drawing_active;

        // Create and initialize an object of the ColorDialog class, so we can can open the Color Dialog box to choose the pen color
        ColorDialog colorDialog1 = new ColorDialog();

        // Create and initialize an object of the Random class, so we can randomize the locations and dimensions of the user-drawn lines and shapes 
        Random random = new Random(); 

        // The current step number of the house drawing process will be stored in the "step" variable. It is also assigned an initial value (0) as well
        byte step = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (freestyle_drawing_active)
            {
                // We draw a tiny "line", in which the coordinates of its beginning are very close to the coordinates of its end
                // While the user is dragging the mouse with the left mouse button pressed down, more of these tiny "lines" are generated in the cursor's path
                // Eventually, a chain of tiny lines is created, which gives the illusion of a big, continuous line

                // We draw a line from the previous coordinates (coordinate_x, coordinate_y) to the current mouse position (e.X, e.Y)
                graphics.DrawLine(pen, coordinate_x, coordinate_y, e.X, e.Y);

                // Then, we update the stored coordinates so that they are ready for the next mouse movement.
                coordinate_x = e.X;
                coordinate_y = e.Y;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the object of the Graphics class
            graphics = this.CreateGraphics();

            // Initialize the object of the Pen class and set its initial properties: color = black, line thickness = 4
            pen = new Pen(Color.Black, 4);

            // This line configures the shape of the ends and joins of lines drawn using the pen
            // LineCap.Round: Makes the line ends rounded (instead of flat or square). This gives smoother, more natural-looking stroke ends — like brush or marker lines
            // DashCap.Round: If the pen uses a dashed line style, this makes each dash have rounded ends
            // With this setup, when we're drawing freehand: Every line segment starts and ends with a rounded tip. If we use dashed lines later, the dashes will look like small round strokes, not sharp rectangles
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the "no shape" option is selected, so that the user won't be able to freestyle draw and draw lines/shapes simultaneously
            if (noShapeToolStripMenuItem.Checked == true) 
            { 
                // Enable the freestyle drawing mode, so that the user will be able to freely draw on the form by left clicking on the form and dragging the mouse
                freestyle_drawing_active = true;

                // Initialize the coordinates of the starting point of the line, so that the user can start freestyle drawing
                coordinate_x = e.X;
                coordinate_y = e.Y;
            }
            
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 1
            pen.Width = 1;

            // Tick the first option, untick the rest
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 2
            pen.Width = 2;

            // Tick the second option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 3
            pen.Width = 3;

            // Tick the third option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 4
            pen.Width = 4;

            // Tick the fourth option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 5
            pen.Width = 5;

            // Tick the fifth option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 6
            pen.Width = 6;

            // Tick the sixth option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = true;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // Set the pen thickness to 7
            pen.Width = 7;

            // Tick the seventh option, untick the rest
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = true;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tick the line, untick the rest
            lineToolStripMenuItem.Checked = true;
            ovalToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            noShapeToolStripMenuItem.Checked = false;
        }

        private void ovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tick the oval, untick the rest
            lineToolStripMenuItem.Checked = false;
            ovalToolStripMenuItem.Checked = true;
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            noShapeToolStripMenuItem.Checked = false;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tick the circle, untick the rest
            lineToolStripMenuItem.Checked = false;
            ovalToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            noShapeToolStripMenuItem.Checked = false;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tick the rectangle, untick the rest
            lineToolStripMenuItem.Checked = false;
            ovalToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = true;
            noShapeToolStripMenuItem.Checked = false;
        }

        private void noShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tick "no shape", untick the rest
            lineToolStripMenuItem.Checked = false;
            ovalToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            noShapeToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // If "line" is selected, draw a randomly placed line of random length on the form when the user clicks on the form
            if (lineToolStripMenuItem.Checked == true) 
            {
                graphics.DrawLine(pen, random.Next(10, 1240), random.Next(10, 631), random.Next(10, 1240), random.Next(10, 631));
            }
            // If "oval" is selected, draw a randomly placed oval of random dimensions on the form when the user clicks on the form
            else if (ovalToolStripMenuItem.Checked == true)
            {
                graphics.DrawEllipse(pen, random.Next(10, 1100), random.Next(10, 600), random.Next(10, 301), random.Next(10, 301));
            }
            // If "circle" is selected, draw a randomly placed circle of random dimensions on the form when the user clicks on the form
            else if (circleToolStripMenuItem.Checked == true)
            {
                circle_diameter = random.Next(10, 600);
                graphics.DrawEllipse(pen, random.Next(10, 1000), random.Next(10, 450), circle_diameter, circle_diameter);
            }
            // If "rectangle" is selected, draw a randomly placed rectangle of random dimensions on the form when the user clicks on the form
            else if (rectangleToolStripMenuItem.Checked == true) 
            {
                graphics.DrawRectangle(pen, random.Next(10, 1100), random.Next(10, 600), random.Next(10, 301), random.Next(10, 301));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Once the user releases the left mouse button, the freestyle drawing mode gets deactivated, so the user won't be able to freestyle draw by just dragging the mouse
            freestyle_drawing_active = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // The goal is to automatically draw a house line by line once the button gets clicked
            // When we click the button, a timer starts ticking
            // For each tick of the timer, a line of the house gets drawn
            // The process continues until the house is fully drawn. Then, the timer automatically stops ticking
            timer1.Enabled = true;

            // Disable the button so that the user can't interrupt the automatic drawing process
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Increase the step number by one so that the drawing process moves to the next step
            step++; 

            // Draw the house line by line. For each step number, draw the corresponding line
            if (step == 1){ graphics.DrawLine(pen, 559, 457, 559, 277); }
            else if (step == 2) { graphics.DrawLine(pen, 559, 277, 689, 277); }
            else if (step == 3) { graphics.DrawLine(pen, 689, 277, 689, 457); }
            else if (step == 4) { graphics.DrawLine(pen, 689, 457, 559, 457); }
            else if (step == 5) { graphics.DrawLine(pen, 559, 277, 624, 187); }
            else if (step == 6) { graphics.DrawLine(pen, 624, 187, 689, 277); }
            else if (step == 7) { graphics.DrawLine(pen, 605, 456, 605, 406); }
            else if (step == 8) { graphics.DrawLine(pen, 605, 406, 635, 406); }
            else if (step == 9) { graphics.DrawLine(pen, 635, 406, 635, 456); }
            else if (step == 10) { graphics.DrawLine(pen, 579, 297, 599, 297); }
            else if (step == 11) { graphics.DrawLine(pen, 599, 297, 599, 317); }
            else if (step == 12) { graphics.DrawLine(pen, 599, 317, 579, 317); }
            else if (step == 13) { graphics.DrawLine(pen, 579, 317, 579, 297); }
            else if (step == 14) { graphics.DrawLine(pen, 579, 307, 599, 307); }
            else if (step == 15) { graphics.DrawLine(pen, 589, 317, 589, 297); }
            else if (step == 16) { graphics.DrawLine(pen, 649, 297, 669, 297); }
            else if (step == 17) { graphics.DrawLine(pen, 669, 297, 669, 317); }
            else if (step == 18) { graphics.DrawLine(pen, 669, 317, 649, 317); }
            else if (step == 19) { graphics.DrawLine(pen, 649, 317, 649, 297); }
            else if (step == 20) { graphics.DrawLine(pen, 649, 307, 669, 307); }
            else if (step == 21) { graphics.DrawLine(pen, 659, 317, 659, 297);

                // Disable the timer, as it has no reason to run anymore since the drawing process is completed
                timer1.Enabled = false;

                // Reset the step number to 0 so that the process can be repeated without problems
                step = 0;

                // Enable the button that starts the drawing process so it can be clicked again
                button1.Enabled = true;
            }
        }

            public Form1()
        {
            InitializeComponent();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the color selector, in which the user will be able to change the pen color
            if (colorDialog1.ShowDialog() == DialogResult.OK)

                // If the user clicks "OK" in the color selector, change the pen color to the selected color
                pen.Color = colorDialog1.Color;
        }
    }
}
