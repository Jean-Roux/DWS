using Microsoft.VisualStudio.TestTools.UnitTesting;
using DWSQ1NS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWSQ1NS.Tests
{
    [TestClass()]
    public class fileProcesserTests
    {
        [TestMethod()]
        public void sortLinesTest()
        {
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            String[] testInData = { "d", "c", "b", "a" };
            String[] expectedResult = { "a", "b", "c", "d" };

            fileControll.setFileInMemory(testInData);
            fileControll.setFileOutMemory(testInData);

            fileControll.sortLines();

            String[] result = fileControll.getFileOutMemory();
            CollectionAssert.AreEqual(expectedResult, result);

        }

        [TestMethod()]
        public void reverseLinesTest()
        {
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            String[] testInData = { "4", "3", "2", "1" };
            String[] expectedResult = { "1", "2", "3", "4" };

            fileControll.setFileInMemory(testInData);
            fileControll.setFileOutMemory(testInData);

            fileControll.reverseLines();

            String[] result = fileControll.getFileOutMemory();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void basicEncryptFileTest()
        {
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            String[] testInData = { "a", "b", "c", "d" };
            String[] expectedResult = { "u", "v", "w", "x" };

            fileControll.setFileInMemory(testInData);
            fileControll.setFileOutMemory(testInData);

            fileControll.basicEncryptFile();

            String[] result = fileControll.getFileOutMemory();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void showLineLenghtsTest()
        {
            fileProcesser fileControll = new fileProcesser("inFile.txt", "outFile.txt");
            String[] testInData = { "123", "12", "1234", "321" };
            String[] expectedResult = {"(Line Lenght: 3) 123", "(Line Lenght: 2) 12", "(Line Lenght: 4) 1234", "(Line Lenght: 3) 321" };

            fileControll.setFileInMemory(testInData);
            fileControll.setFileOutMemory(testInData);

            fileControll.showLineLenghts();

            String[] result = fileControll.getFileOutMemory();
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}