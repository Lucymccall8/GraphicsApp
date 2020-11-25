using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace assignment1
{
    public partial class Form1 : Form
    {

        //defining the variables for the size of the bitmap, so they can easily be changed
        public static int xscreensize = 570;
        public static int yscreensize = 340;
        public Bitmap myBitmap = new Bitmap(xscreensize, yscreensize);

        //creating a new instance of drawingclass, so its methods can be accessed.
        Drawing DrawingClass;

        String Action; //where contents of commandline are stored
        String Program; //where contents of program textbox are stored

        public Form1()
        {
            InitializeComponent();
            DrawingClass = new Drawing(Graphics.FromImage(myBitmap)); //Tells graphics object where to draw from drawing class
        }

        private void tbCMD_KeyDown(object sender, KeyEventArgs e)
        {
          
            // activated on enter keypress of commandline textbox
            if (e.KeyCode == Keys.Enter)
            {
                // gets the text from textboxes, trims white space and makes all lowercase
                this.Program = tbProgram.Text.Trim().ToLower();
                this.Action = tbCMD.Text.Trim().ToLower();


                // basic shapes
                if (Action.Contains("line") == true)
                {
                    try
                    {
                        DrawingClass.DrawLine(Action); //passes the full action into the class to be handled and parsed within method.
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect Parameter for line");
                        Console.WriteLine(error);
                    }
                     
                }
                else if (Action.Contains("rectangle") == true)
                {
                    try
                    {
                        DrawingClass.DrawRectangle(Action);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect Parameter for rectangle");
                        Console.WriteLine(error);
                    }
                }
                else if (Action.Contains("circle") == true)
                {
                    try
                    {
                        DrawingClass.DrawCircle(Action);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect Parameter for circle");
                        Console.WriteLine(error);
                    }
                }
                else if (Action.Contains("triangle") == true)
                {
                    try
                    {
                        DrawingClass.DrawTriangle(Action);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect Parameter for triangle");
                        Console.WriteLine(error);
                    }
                }

                // pen colours
                else if (Action.Contains("red") == true)
                {
                    DrawingClass.ChangePenColour("red"); // send colour into colour change method.
                }
                else if (Action.Contains("yellow") == true)
                {
                    DrawingClass.ChangePenColour("yellow"); // send colour into colour change method.
                }
                else if (Action.Contains("black") == true)
                {
                    DrawingClass.ChangePenColour("black"); // send colour into colour change method.
                }
                else if (Action.Contains("blue") == true)
                {
                    DrawingClass.ChangePenColour("blue"); // send colour into colour change method.
                }


                //program controls
                else if (Action.Contains("run") == true)
                {
                    try
                    {
                        DrawingClass.runProgram(Program); //send the full contents of program textbox into its method if true
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect commands in program, please recheck.");
                        Console.WriteLine(error.Message);
                    }

                }
                else if (Action.Contains("save") == true)
                {
                    File.WriteAllText("program.txt", tbProgram.Text); //write program textbox contents to txt file and save to filesystem as 'program.txt'
                    tbProgram.Clear(); // clear the program textbox after saving

                    //can be extracted into seperate method for part 2
                }
                else if (Action.Contains("load") == true)
                {
                    //attemps to load the file and handles any errors
                    try
                    {
                        if (File.Exists("program.txt")) // check if filename exists in filesystem
                        {
                            tbProgram.Text = File.ReadAllText("program.txt"); //set program textbox as file contents
                        }
                    }

                    catch (Exception error) // allows program to continue running on error
                    {
                        //Message shows to user on screen and in console
                        MessageBox.Show("The file could not be read");
                        Console.WriteLine(error.Message);
                    }
                }

                // fill controls
                else if (Action.Contains("fillon") == true)
                {
                    DrawingClass.changeFill(true); //send bool through to method if true, to change wether fill is on or off
                }
                else if (Action.Contains("filloff") == true)
                {
                    DrawingClass.changeFill(false);
                }

                //pen controls
                else if (Action.Contains("moveto") == true)
                {
                    try
                    {
                        DrawingClass.moveTo(Action);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Incorrect parameter for moveto");
                        Console.WriteLine(error.Message);
                    }
                }
                else if (Action.Contains("reset") == true)
                {
                    DrawingClass.resetPen(); //reset pen to 0,0 if true
                }
                else if (Action.Contains("clear") == true)
                {
                    DrawingClass.clearDrawing(); // clear drawing area if true
                }
                else // invalid command, show error message
                {
                    MessageBox.Show("Invalid command: " + Action);
                }
                tbCMD.Clear(); // clear commandline after every command
                Refresh(); //redraw the form on each keypress, to show graphics
            }

            
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // set graphics object as painteventargs
            g.DrawImageUnscaled(myBitmap, 0, 0); // draw bitmap onto picturebox
        }

        public void ProgramError(String errormessage)
        {
            MessageBox.Show(errormessage);
        }
    }

}
