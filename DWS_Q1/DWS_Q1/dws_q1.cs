
using System;
using System.Text;


namespace DWSQ1NS
{
    public class fileProcesser
    {
        //Declare private variables to be used in the fileProcesser class only
        private string g_sFileIn = "";
        private string g_sFileOut = "";
        private string[] g_sFileContentsIn;
        private string[] g_sFileContentsOut;
        //Class Contructor that recieves the input/output files and stores them in memory
        public fileProcesser(string inFile, string outFile)
        {

            g_sFileIn = inFile;
            g_sFileOut = outFile;
            //Read the contents of the in file to memory
            this.readFileContents(true);
            //Make the out file the same size as the in file
            g_sFileContentsOut = new string[g_sFileContentsIn.Length];
        }

        public string[] getFileInMemory()
        {
            return g_sFileContentsIn;
        }

        public string[] getFileOutMemory()
        {
            return g_sFileContentsOut;
        }

        public void setFileInMemory(string[] inMem)
        {
            g_sFileContentsIn = new string[inMem.Length];
            inMem.CopyTo(g_sFileContentsIn, 0);
        }

        public void setFileOutMemory(string[] outMem)
        {
            g_sFileContentsOut = new string[outMem.Length];
            outMem.CopyTo(g_sFileContentsOut, 0);
        }

        //Function to read file contents. This can only be called from the fileProcessor calss
        //If true, the IN file is read into memory.
        //If false, the OUT file is read into memory
        public void readFileContents(bool bInFile)
        {
            try
            {
                if (bInFile)
                    g_sFileContentsIn = System.IO.File.ReadAllLines(g_sFileIn, System.Text.Encoding.GetEncoding("iso-8859-1"));
                else
                    g_sFileContentsOut = System.IO.File.ReadAllLines(g_sFileOut, System.Text.Encoding.GetEncoding("iso-8859-1"));
            }
            catch (Exception)
            {
                throw new Exception("failed to read the file");
            }
        }

        //Private Funtion to write OUT file memory to the out file. This can only be called from the fileProcessor calss
        public void writeFileContents()
        {
            //Get full path and display to user so they can find the OUT file
            string destPath = AppDomain.CurrentDomain.BaseDirectory + g_sFileOut;
            Console.WriteLine("Writing to file " + destPath);
            System.IO.File.WriteAllLines(destPath, g_sFileContentsOut, System.Text.Encoding.GetEncoding("iso-8859-1"));
        }

        //Function to display the ciontents of a file to the user. The file will first be read into memory and then displayed.
        //If parameter is True, the IN file is read and displayed.
        //If parameter is False, the OUT file is rtead and displayed.
        public void displayFileContents(bool bInFile)
        {
            Console.OutputEncoding = System.Text.Encoding.Latin1;
            if (bInFile)
            {
                this.readFileContents(true);//True = read IN file
                Console.WriteLine("");
                Console.WriteLine("Current file contents of inFile.txt: ");
                Console.WriteLine("");
                foreach (String line in g_sFileContentsIn)
                {
                    Console.WriteLine(line.ToString());
                }
            }
            else
            {
                this.readFileContents(false);//Flase = Read OUT file
                Console.WriteLine("");
                Console.WriteLine("Current file contents of outFile.txt: ");
                Console.WriteLine("");
                foreach (String line in g_sFileContentsOut)
                {

                    Console.WriteLine(line.ToString());
                }
            }
        }

        //Public Function to sort lines in IN file alphabetically and write to OUT file
        public void sortLines()
        {
            //Copy memory of In file to memory of OUT file
            g_sFileContentsIn.CopyTo(g_sFileContentsOut, 0);
            //Sort the contents of OUT file alphabetically
            Array.Sort(g_sFileContentsOut);
            if (g_sFileContentsOut.Length <= 0)
            {
                throw new Exception("out file is empty");
            }
            //Write memory of OUT file to phiysical OUT file
            this.writeFileContents();
        }

        //Public function to reverse the order of lines iin the file
        public void reverseLines()
        {
            //Copy memory of In file to memory of OUT file
            g_sFileContentsIn.CopyTo(g_sFileContentsOut, 0);
            //Reverse the contents of OUT file 
            Array.Reverse(g_sFileContentsOut);
            //Write memory of OUT file to phiysical OUT file
            this.writeFileContents();
        }

        //Public function to to basic encryption and write to OUT file
        public void basicEncryptFile()
        {
            int nCount = 0;
            //Loop through each line in IN file
            foreach (String line in g_sFileContentsIn)
            {
                String sNewLine = "";
                // Loop through each character in line
                for (int i = 0; i < line.Length; ++i)
                {
                    // get the ASCII value o the current character
                    int SAsciiVal = (int)line[i];
                    char chNewChar = (char)(SAsciiVal + 20);
                    //chNewChar = Strings.ChrW(chNewChar);
                    //Add the modified character into a new line
                    sNewLine += chNewChar;
                }
                //Add the new line to the OUT file memory
                g_sFileContentsOut[nCount] = sNewLine;
                nCount++;
            }
            //Write memory of OUT file to phiysical OUT file
            this.writeFileContents();
        }

        //Public function to show the lenght of each line and write to OUT file
        public void showLineLenghts()
        {
            int nCount = 0;
            //Loop through each line in IN file
            foreach (String line in g_sFileContentsIn)
            {
                //Get the lenght of the current line
                int nLenght = line.Length;
                //Add the lenghts of the line to a new line string
                String sNewLine = "(Line Lenght: " + nLenght + ") ";
                //Add the contents of the line to the new line string
                sNewLine += line;
                //Add the new line to the OUT file memory
                g_sFileContentsOut[nCount] = sNewLine;
                nCount++;
            }
            //Write memory of OUT file to phiysical OUT file
            this.writeFileContents();
        }
    }
    public static class DWS_Q1
    {

        public static void Main()
        {
            
            //create new fileProcesser object and refer to the input file.
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            bool bRunning = true;
            //Keep the program running so it does not have to be rerun every time the user wants to try the next option or give invalid inputs
            while (bRunning)
            {

                //Display the current file contents to the user
                fileControll.displayFileContents(true);
                //Get the input from user to determine which method to apply to the file
                Console.WriteLine("");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("Please select one of the below options: ");
                Console.WriteLine("1: Sort the lines in a text file alphabetically ");
                Console.WriteLine("2: Reverse the order of the lines in a text file ");
                Console.WriteLine("3: Basic encryption of file ");
                Console.WriteLine("4: Show length of each line ");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("");
                string sChoice = "";
                //Get the input from user
                sChoice = Console.ReadLine();
                int nChoice = 0;
                //Try to parse to int. If the user tries to enter a String or empty value, the custom exception will be called within catch
                try
                {
                    nChoice = Int32.Parse(sChoice); // Parse from string to int32
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please choose a number between 1 and 4");
                    continue; //Return to main menu
                }
                //Check if number is 1,2 or 3. Any other number is invalid and will return to the main menu
                if (nChoice < 1 || nChoice > 4)
                {
                    Console.WriteLine("Invalid choice! Must be number between 1 and 4");
                    continue;
                }

                Console.WriteLine("you have chosen option " + nChoice);

                switch (nChoice)
                {
                    case 1:
                        fileControll.sortLines(); //Answer to 1.1
                        break;
                    case 2:
                        fileControll.reverseLines(); //Answer to 1.2
                        break;
                    case 3:
                        fileControll.basicEncryptFile(); //Answer to 1.3
                        break;
                    case 4:
                        fileControll.showLineLenghts(); //Answer to 1.4
                        break;
                    default:
                        continue;
                }
                fileControll.displayFileContents(false);
                Console.WriteLine("");
                

            }

        }
    }
}