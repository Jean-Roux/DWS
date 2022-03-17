using Microsoft.AspNetCore.Mvc;
using DWSQ1NS;
namespace DWSwebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DWSwebAPIController: Controller
    {
        [HttpGet("getRandomNumber")]
        public int getRandomNumber() // Answer to Question 2.1
        {
            int nRandomNumber = 0;
            Random r = new Random();
            nRandomNumber = r.Next(1, 38); //Get random number between 1 and 37

            return nRandomNumber;
        }

        [HttpGet("getRandomString")]
        public string getRandomString() // Answer to Question 2.2
        {
            //Reading static IN file
            String[] sFileContentsIn = System.IO.File.ReadAllLines("inFile.txt");
            //Make a list as we do not know the size of the array at this point
            var listWords = new List<string>();
            Random random = new Random();
            foreach (String line in sFileContentsIn) //Loop though each line in fiile
            {
                string[] split = line.Split(" "); // Split each line into words
                foreach(String word in split)
                {
                    listWords.Add(word); // Add each word to word list
                }
            }
            String[] sWords = listWords.ToArray();// Converst to String[] array
            //Get a random word from abbove aray
            string randomString = sWords[random.Next(0, sWords.Length)];
            //Return the random word
            return randomString;
        }

        [HttpGet("getRandomMethod")]
        public string[] getRandomMethod() // Answer to Question 2.3
        {
            //Create new fileProsser object usin class from Question 1
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            //Maske the out array the same size as the IN array
            String[] sFileContentsOut = fileControll.getFileInMemory();
            int nRandomNumber = 0;
            Random r = new Random();
            nRandomNumber = r.Next(1, 5); //Get random number between 1 and 4 (There are 4 different methods in the class.

            //Use the random number to determine which method to execute
            switch(nRandomNumber)
            {
                case 1:
                    fileControll.sortLines();
                    sFileContentsOut = fileControll.getFileOutMemory(); //Get our file memory array
                    break;
                case 2:
                    fileControll.reverseLines();
                    sFileContentsOut = fileControll.getFileOutMemory();//Get our file memory array
                    break;
                case 3:
                    fileControll.basicEncryptFile();
                    sFileContentsOut = fileControll.getFileOutMemory();//Get our file memory array
                    break;
                case 4:
                    fileControll.showLineLenghts();
                    sFileContentsOut = fileControll.getFileOutMemory();//Get our file memory array
                    break;
                    //default:
                    //Should never hit this, just for testing to make sure the random number does not go above 4
                    //sFileContentsOut = new string[1];
                    //sFileContentsOut[0] = "Invalid option: "+ nRandomNumber;
                    //break;
            }
            //Return the results from the random function
            return sFileContentsOut;
        }
    }
}
