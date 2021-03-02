using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chassis_Editor
{
    // a BatchEditLine consists of a label and a button. 
    // The label displays the text of a change to be made to a batch of files
    // If the button is clicked, the BatchEditLine is deleted

    public class BatchEditLine
    {
        public int x;
        public int y;
        int horizontalSpacing = 10;
        Label label = new Label();
        int labelWidth = 200;
        int labelHeight = 22;
        Button button = new Button();

        MainWindow mainWindow;

        // When creating a BatchEditLine, you have to provide it a location to begin from. The label's top left corner will be there
        public BatchEditLine(int inX, int inY, EventHandler handler, MainWindow mainWindowIn)
        {
            x = inX;
            y = inY;
            mainWindow = mainWindowIn;

            label.Location = new Point(x, y);
            label.AutoSize = false;
            label.Size = new Size(labelWidth, labelHeight);
            label.ForeColor = Color.FromKnownColor(KnownColor.ButtonFace);
            label.BackColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
            button.Location = new Point(x + label.Size.Width + horizontalSpacing, y);
            button.Text = "X";
            button.AutoSize = true;
            button.ForeColor = Color.FromKnownColor(KnownColor.ButtonFace);
            button.BackColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
            button.Click += handler;

            mainWindow.Controls.Add(label);
            mainWindow.Controls.Add(button);
        }

        public BatchEditLine()
        {
            // don't do anything, this is just a dummy to prevent "unassigned" variable errors
        }
        public void Show()
        {
            label.Show();
            button.Show();
        }

        public void Hide()
        {
            label.Hide();
            button.Hide();
        }

        public void SetLabel(string text)
        {
            label.Text = text;
        }

        public string GetLabel()
        {
            return label.Text;
        }

        public int GetLabelHeight()
        {
            return label.Size.Height;
        }

        public void RemoveControls()
        {
            mainWindow.Controls.Remove(label);
            mainWindow.Controls.Remove(button);
        }

        public bool MyButton(Button b)
        {
            return (button == b);
        }
    }
}
