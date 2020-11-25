using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace assignment1
{
    public class Drawing
    {
        Graphics g;// create new graphics object
        Brush myBrush = new SolidBrush(Color.Black); //paints a filled in shape
        Pen myPen; //paints an outlined shape
        public bool isfilled = false;
        bool testing;
        public int xPos, yPos; //pen position
        Parser parsecommands = new Parser();

        //holds int values for drawing shapes, set as each method is called.
        //to be moved into a shape method when inheritance is implimented for part 2
        int num1;
        int num2;
        int num3;


        public Drawing(Graphics g) //Allows form1 to understand how graphics is used
        {
            this.g = g;
            xPos = yPos = 0;
            myPen = new Pen(Color.Black);
        }

        public Drawing()
        {
            testing = true;
        }

        //draw line method
        public void DrawLine(string Action) //takes the full action that was in commandline as parameter
        {

                //split by spaces and store in array
                string[] Actions = Action.Split(' ');
                //parses array values as ints for num variables
                num1 = int.Parse(Actions[1]);
                num2 = int.Parse(Actions[2]);

                //draw the line with num values
                if (testing == false)
                {
                    g.DrawLine(myPen, xPos, yPos, num1, num2);
                }
                xPos = num1 + xPos;
                yPos = num2 + yPos;
            }

        //draw rectangle method
        public void DrawRectangle(string Action) //takes the full action that was in commandline as parameter
        {
            //split by spaces and store in array
            string[] Actions = Action.Split(' ');
            //parse array values as ints for num variables
            num1 = int.Parse(Actions[1]);
            num2 = int.Parse(Actions[2]);

            if (isfilled == true) // if isfilled bool is true, draw filled shape
            {
                if (testing == false)
                {
                    //draw filled rectangle using num values
                    g.FillRectangle(myBrush, xPos, yPos, num1, num2); //num1 = width, num2 = height
                }
                //update pen position
                xPos = xPos + num1;
                yPos = yPos + num2;
            }
            else
            {
                if (testing == false)
                {
                    //draw unfilled rectangle using num values
                    g.DrawRectangle(myPen, xPos, yPos, num1, num2); //num1 = width, num2 = height
                }
                //update pen position
                xPos = xPos + num1;
                yPos = yPos + num2;
            }
        }
    

        //draw circle method
        public void DrawCircle(string Action) //takes the full action that was in commandline as parameter
        {
            //split by spaces and store in array
            string[] Actions = Action.Split(' ');
            num1 = int.Parse(Actions[1]); //parse array value as int for num variable

            if (isfilled == true) // if isfilled bool is true, draw filled shape
            {
                if (testing == false)
                {
                    //draw filled circle using num value
                    g.FillEllipse(myBrush, xPos - num1, yPos - num1, num1 + num1, num1 + num1); //num1 = radius
                }
            }
            else
            {
                if (testing == false)
                {
                    //draw circle outline using num value
                    g.DrawEllipse(myPen, xPos - num1, yPos - num1, num1 + num1, num1 + num1); //num1 = radius
                }
            }
        }

        public void DrawTriangle(string Action) //takes the full action that was in commandline as parameter
        {
            //split by spaces and store in array
            string[] Actions = Action.Split(' ');
            
            //parse array value as ints for num variables
            num1 = int.Parse(Actions[1]);
            num2 = int.Parse(Actions[2]);
            num3 = int.Parse(Actions[3]);

            //create points array for triangle verticies

            //Vertices A and B are triangle base, vertice C is the third vertice
            Point[] points = { new Point(xPos, yPos), new Point(xPos + num1, yPos), new Point(xPos + num2, yPos + num3) }; //num1 = AB base length, num2 = vertice C x-axis, num3 = vertice C y-axis

            if (isfilled == true) // if isfilled = true, draw a filled shape
            {
                if (testing == false)
                {
                    g.FillPolygon(myBrush, points); //draw filled triangle using points array
                }
                xPos = xPos + num2; //update pen pos
                yPos = yPos + num3;
            }
            else
            {
                if (testing == false)
                {
                    g.DrawPolygon(myPen, points); //draw unfilled triangle using points array
                }
                xPos = xPos + num2; // update pen pos
                yPos = yPos + num3;
            }
        }

        //change pen colour method
        public Color ChangePenColour(string pencolour) //takes string as parameter
        {

            //if the string is equal to colour, change pen and brush colour
            if (pencolour == "red")
            {
                myPen.Color = Color.Red; //sets pen to red
                myBrush = new SolidBrush(Color.Red); //create new brush of colour red
            }
            else if (pencolour == "blue")
            {
                myPen.Color = Color.Blue; //sets pen to blue
                myBrush = new SolidBrush(Color.Blue); //create new brush of colour blue
            }
            else if (pencolour == "yellow")
            {
                myPen.Color = Color.Yellow; //sets pen to yellow
                myBrush = new SolidBrush(Color.Yellow); // Create new brush of colour yellow
            }
            else if (pencolour == "black")
            {
                myPen.Color = Color.Black; //sets pen to black
                myBrush = new SolidBrush(Color.Black); //create new brush of colour black
            }
            else throw new ArgumentException();
            {

            }

            return myPen.Color;

        }

        //turn fill on and off method
        public void changeFill(bool fill)
        {
            if (fill == true)
            {
                this.isfilled = true;
            }
            else if (fill == false)
            {
                this.isfilled = false;
            }
        }

        //move pen method
        public void moveTo(string Action)
        {
                //split string by space
                string[] Actions = Action.Split(' ');
                //parse array value as ints for num variables
                num1 = int.Parse(Actions[1]);
                num2 = int.Parse(Actions[2]);
                    //set pen position as num1, num2
                    yPos = num1;
                    xPos = num2;
        }

        // reset pen method
        public void resetPen()
        {
            //set pen position as 0,0
            yPos = 0;
            xPos = 0;
        }

        //clear draw area method
        public void clearDrawing()
        {
            if (testing == false)
            {
                g.Clear(Color.Transparent); //clears graphics and resets background to transparent
                ChangePenColour("black"); //sets the pen back to black
                changeFill(false); //sets fill as false
            }

            //resets the pen back to 0,0
            yPos = 0;
            xPos = 0;

            //reset pen and brush colour to black

        }

        public void runProgram(string program) //takes the whole program as parameter
        {
            //splits the string by newline and stores each line of the program as array item
            string[] Actions = program.Split('\n');

            foreach (string a in Actions) //loops through each item of array one at a time, a=array item
            {
                //checks if statements for each item of array

                if (a.Contains("line") == true) // check if 'a' contains string, if true then call method
                {
                    try
                    {
                        DrawLine(a); //sends the line to the method to be split and parsed correctly to draw shape
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                    }

                }
                else if (a.Contains("rectangle") == true)
                {
                    try
                    {
                        DrawRectangle(a);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("circle") == true)
                {
                    try
                    {
                        DrawCircle(a);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("triangle") == true)
                {
                    try
                    {
                        DrawTriangle(a);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("red") == true)
                {
                    try
                    {
                        ChangePenColour("red");
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("blue") == true)
                {
                    try
                    {
                        ChangePenColour("blue");
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("yellow") == true)
                {
                    try
                    {
                        ChangePenColour("yellow");
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("black") == true)
                {
                    try
                    {
                        ChangePenColour("black");
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("fillon") == true)
                {
                    try
                    {
                        changeFill(true);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("filloff") == true)
                {
                    try
                    {
                        changeFill(false);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("moveto") == true)
                {
                    try
                    {
                        moveTo(a);
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("reset") == true)
                {
                    try
                    {
                        resetPen();
                    }
                    catch (Exception)
                    {

                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else if (a.Contains("clear") == true)
                {
                    try
                    {
                        clearDrawing();
                    }
                    catch (Exception)
                    {
                        parsecommands.ProgramError("Incorrect parameter at line: " + a);
                        break;
                    }

                }
                else
                {
                    if (testing == false) {
                        parsecommands.ProgramError("Incorrect command at line: " + a);
                        break;
                    }
                    throw new ArgumentException();//thrown when no others == true
                    
                }

            }
        }
    }
}
