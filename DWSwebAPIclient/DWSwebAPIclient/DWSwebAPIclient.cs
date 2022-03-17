using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWSwebAPIclient
{
    public class DWSwebAPIclient
    {
        public static void Main(string[] args)
        {
            bool bRunning = true;
            //Keep the program running so it does not have to be rerun every time the user wants to try the next option or give invalid inputs
            while (bRunning)
            {
                //Get the input from user to determine which method to apply to the file
                Console.WriteLine("");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Please select one of the below options: ");
                Console.WriteLine("1: Get Random number from web API");
                Console.WriteLine("2: get random word in text file from web api ");
                Console.WriteLine("3: get random file manipulation from web api");
                Console.WriteLine("*****************************************************");
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
                    Console.WriteLine("Invalid input! Please choose a number between 1 and 3");
                    continue; //Return to main menu
                }
                //Check if number is 1,2 or 3. Any other number is invalid and will return to the main menu
                if (nChoice < 1 || nChoice > 3)
                {
                    Console.WriteLine("Invalid choice! Must be number between 1 and 3");
                    continue;
                }

                Console.WriteLine("you have chosen option " + nChoice);
                DWSwebAPIHelper webAPI = new DWSwebAPIHelper();
                switch (nChoice)
                {
                    case 1:
                        //Answer to 2.1
                        try
                        {
                            webAPI.GetWebData("getRandomNumber");
                        }
                        catch
                        {
                            Console.WriteLine("Could not connect to web API!");
                        }
                        break;
                    case 2:
                        //Answer to 2.2
                        try
                        {
                            webAPI.GetWebData("getRandomString");
                        }
                        catch
                        {
                            Console.WriteLine("Could not connect to web API!");
                        }
                        break;
                    case 3:
                        //Answer to 2.3
                        try
                        {
                            webAPI.GetWebData("getRandomMethod");
                        }
                        catch
                        {
                            Console.WriteLine("Could not connect to web API!");
                        }
                        break;
                    default:
                        continue;
                }

            }
        }
    }
}