using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment1;
using System;

namespace assignment1Test
{
    [TestClass]
    public class UnitTests
    {

        /// <summary>
        /// Valid paramater command checks
        /// </summary>
        /// 
        /// These tests are checking for the correct output when a valid command is used.
        /// 
        /// They work by setting what the expected pen position is, as x and y integers.
        /// The command is then executed, and the actual position of the pen is set as two new x and y integers.
        /// The assert command is used to compare these with the expected position integers with the actual position integers.
        /// If they are the same, the test passes. An error message is shown if the test fails.

        //tests wether pen position is updated correctly when pen is moved
        [TestMethod]
        public void TestMoveToValid()
        {
            int expectedypos = 110; //what the yPos should be after executing the command
            int expectedxpos = 120; //what the xPos should be after executing the command

            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.moveTo("moveto 110 120"); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class

            Assert.AreEqual(expectedxpos, actualxpos, ("pen x coordinate position not set correctly")); //compare the expected and actual xPos positions.
            Assert.AreEqual(expectedypos, actualypos, ("pen y coordinate position not set correctly")); //compare the expected and actual yPos positions.

        }

        //tests wether pen position is updated correctly when line is drawn
        [TestMethod]
        public void TestDrawLineValid()
        {
            int expectedypos = 30; //what the yPos should be after executing the command
            int expectedxpos = 40; //what the xPos should be after executing the command

            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.DrawLine("line 40 30"); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class

            Assert.AreEqual(expectedxpos, actualxpos, ("pen x coordinate position not set correctly")); //compare the expected and actual xPos positions
            Assert.AreEqual(expectedypos, actualypos, ("pen y coordinate position not set correctly")); //compare the expected and actual yPos positions
        }

        //tests wether pen position is updated correctly when rectangle is drawn
        [TestMethod]
        public void TestDrawRectangleValid()
        {
            int expectedypos = 30; //what the yPos should be after executing the command
            int expectedxpos = 40; //what the xPos should be after executing the command

            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.DrawRectangle("rectangle 40 30"); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class


            Assert.AreEqual(expectedxpos, actualxpos, ("pen x coordinate position not set correctly")); //compare the expected and actual xPos positions
            Assert.AreEqual(expectedypos, actualypos, ("pen y coordinate position not set correctly")); //compare the expected and actual yPos positions
        }

        //tests wether pen position is updated correctly when triangle is drawn
        [TestMethod]
        public void TestDrawTriangleValid()
        {
            int expectedypos = 50; //what the yPos should be after executing the command
            int expectedxpos = 30; //what the xPos should be after executing the command

            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.DrawTriangle("triangle 40 30 50"); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class


            Assert.AreEqual(expectedxpos, actualxpos, ("pen x coordinate position not set correctly")); //compare the expected and actual xPos positions
            Assert.AreEqual(expectedypos, actualypos, ("pen y coordinate position not set correctly")); //compare the expected and actual yPos positions
        }

        //tests wether pen position is updated correctly when pen is reset
        [TestMethod]
        public void TestResetPen()
        {
            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.resetPen(); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class

            Assert.AreEqual(0, actualxpos, ("pen x coordinate position not reset correctly")); //compare the expected and actual xPos positions
            Assert.AreEqual(0, actualypos, ("pen y coordinate position not reset correctly")); //compare the expected and actual yPos positions
        }

        //tests wether pen position is reset correctly when draw area is cleared
        [TestMethod]
        public void TestClearDrawing()
        {
            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.clearDrawing(); //execute the method with the paramaters

            int actualxpos = drawclass.xPos; //get the current xPos from the drawing class
            int actualypos = drawclass.yPos; //get the current yPos from the drawing class

            Assert.AreEqual(0, actualxpos, ("pen x coordinate position not reset correctly")); //compare the expected and actual xPos positions
            Assert.AreEqual(0, actualypos, ("pen y coordinate position not reset correctly")); //compare the expected and actual yPos positions
        }

        //tests wether filled bool is changed to true correctly when changefill is used
        [TestMethod]
        public void TestChangeFillTrue()
        {
            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.changeFill(true); //execute the method with the bool

            bool expectedfill = drawclass.isfilled; // get isfilled condition from drawing class

            Assert.AreEqual(true, expectedfill, ("isfilled not set true correctly")); //compare the expected and actual bool conditions
        }

        //tests wether fill bool is changed to false correctly when changefill is used
        [TestMethod]
        public void TestChangeFillFalse()
        {
            var drawclass = new Drawing(); //create an object of the drawingclass

            drawclass.changeFill(false); //execute the method with the bool

            bool expectedfill = drawclass.isfilled;

            Assert.AreEqual(false, expectedfill, ("isfilled not set false correctly")); //compare the expected and actual xPos positions
        }




        /// <summary>
        /// Invalid paramater command checks
        /// </summary>
        /// 
        /// These tests are checking for the correct output when a command is used with invalid parameters.
        /// 
        /// They work by executing the method with wrong parameters.
        /// The assert function checks to see if the correct exception is thrown when this happens.
        /// If the correct exception is thrown, then the test passes.

        //tests wether exceptions are thrown when moveto is attempted with invalid parameters
        [TestMethod]
        public void TestMoveToInvalid()
        {
            var drawclass = new Drawing(); //creates an object of the drawing class

            //tests if an exception is thrown when it calls the method with incorrect parameters
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { drawclass.moveTo("moveto 1"); }); //Throws this exception when not enough parameters
            Assert.ThrowsException<FormatException>(delegate () { drawclass.DrawLine("moveto x"); }); //throws this exception if something other then an int is provided as a paremeter
        }

        //tests wether exceptions are thrown when line is attempted with invalid parameters
        [TestMethod]
        public void TestDrawLineInvalid()
        {
            var drawclass = new Drawing(); //creates an object of the drawing class

            //tests if an exception is thrown when it calls the method with incorrect parameters
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { drawclass.DrawLine("line 10"); }); //Throws this exception when not enough parameters
            Assert.ThrowsException<FormatException>(delegate () { drawclass.DrawLine("line x"); }); //throws this exception if something other then an int is provided as a paremeter
        }

        //tests wether exceptions are thrown when a pen colour change is attempted with invalid parameter
        [TestMethod]
        public void TestPenColourInvalid()
        {
            var drawclass = new Drawing(); //creates an object of the drawing class

            //tests if an exception is thrown when it calls the method with the wrong colour
            Assert.ThrowsException<ArgumentException>(delegate () { drawclass.ChangePenColour("purple"); });
        }

        //tests wether exceptions are thrown when rectangle is attempted with invalid parameters
        [TestMethod]
        public void TestDrawRectangleInvalid()
        {
            var drawclass = new Drawing(); //creates an object of the drawing class

            //tests if an exception is thrown when it calls the method with wrong parameters
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { drawclass.DrawRectangle("rectangle 10"); }); //Throws this exception when not enough parameters
            Assert.ThrowsException<FormatException>(delegate () { drawclass.DrawRectangle("rectangle x"); }); //throws this exception if something other then an int is provided as a paremeter

        }

        //tests wether exceptions are thrown when circle is attempted with invalid parameters
        [TestMethod]
        public void TestDrawCircleInvalid()
        {
            var drawclass = new Drawing();

            //tests if an exception is thrown when it calls the method with wrong parameters
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { drawclass.DrawCircle("circle"); }); //Throws this exception when not enough parameters
            Assert.ThrowsException<FormatException>(delegate () { drawclass.DrawCircle("circle x"); }); //throws this exception if something other then an int is provided as a paremeter

        }

        //tests wether exceptions are thrown when triangle is attempted with invalid parameters
        [TestMethod]
        public void TestDrawTriangleInvalid()
        {
            var drawclass = new Drawing();

            //tests if an exception is thrown when it calls the method with wrong parameters
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { drawclass.DrawTriangle("triangle 20 20"); }); //Throws this exception when not enough parameters
            Assert.ThrowsException<FormatException>(delegate () { drawclass.DrawTriangle("triangle x"); }); //throws this exception if something other then an int is provided as a paremeter
        }

        //tests wether exception is thrown when an invalid command is used in program
        [TestMethod]
        public void TestRunProgramInvalid()
        {
            var drawclass = new Drawing();

            Assert.ThrowsException<ArgumentException>(delegate () { drawclass.runProgram("draw"); }); //Throws this exception when incorrect command is used
        }


        /// <summary>
        /// Part 2 Unit Tests
        /// </summary>
        /// 
        /// These tests will fail due to the code not being implimented.
        
        //tests wether exceptions are thrown when parseaction method is called with invalid input
        [TestMethod]
        public void TestParseActionInvalid()
        {
            var parserclass = new Parser(); // create object of parser class

            //Throws this exception when incorrect command is used.
            Assert.ThrowsException<ArgumentException>(delegate () { parserclass.ParseAction("moveto"); });
            //Throws this exception when not enough parameters are used.
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { parserclass.ParseAction("line 10"); });
            //Throws this exception when incorrect parameterformat is used.
            Assert.ThrowsException<FormatException>(delegate () { parserclass.ParseAction("rectangle 10 x"); });

        }

        //tests varcommand method with valid input
        [TestMethod]
        public void TestVarCommandValid()
        {
            int expectedvar = 20; //what the expected outcome of variable is
            var commands = new ProgrammingCommands(); // create object of parser class

            commands.VarCommand("var test = 20");

            int actualvar = commands.value; //the actual outcome of variable

            //compares the expected and actual variables
            Assert.AreEqual(expectedvar, actualvar, ("variable value sat incorrectly")); //compares the expected and actual variables
        }

        //tests wether exceptions are thrown when varcommand method is called with invalid input
        [TestMethod]
        public void TestVarCommandInvalid()
        {
            var commands = new ProgrammingCommands(); // create object of programming commands class

            //Throws this exception when no parameter is given
            Assert.ThrowsException<IndexOutOfRangeException>(delegate () { commands.VarCommand("var test ="); });

            //Throws this exception when wrong parameter format is used
            Assert.ThrowsException<FormatException>(delegate () { commands.VarCommand("var test = x"); });

        }

    }
}
