using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PiMatchScoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = CalculateScore(3149);
            Assert.AreEqual(-82.5, result);  
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = CalculateScore(357878);
            Assert.AreEqual(336, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = CalculateScore(47201);
            Assert.AreEqual(-150.3, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var result = CalculateScore(3672301);
            Assert.AreEqual(153.4, result);
        }


        private double CalculateScore(int input)
        {
            string intString = input.ToString();
            var separatedList = CreateList(intString);

            var listToBeAveraged = PerformMath(separatedList);

            var average = AverageList(listToBeAveraged);

            return average;
        }

        private List<int> CreateList(string input)
        {
            List<int> topNumbersList = new List<int>();
            for (int i = 0; i < input.Length-2; i++)
            {
                string smallChunk = input.Substring(i, 3);

                int convertedInt = int.Parse(smallChunk);
                topNumbersList.Add(convertedInt);
            }

            return topNumbersList;
        }

        private List<int> PerformMath(List<int> separatedList)
        {
            for (int i = 0; i < separatedList.Count; i++)
            {
                if (separatedList[i] - 314 < 100 && separatedList[i] - 314 > -100)
                    separatedList[i] = 0;
                else
                    separatedList[i] = separatedList[i] - 314;
            }
            return separatedList;
        }

        private double AverageList(List<int> listToBeAveraged)
        {
            double sum = 0;
            var count = listToBeAveraged.Count;

            for (int i = 0; i < listToBeAveraged.Count; i++)
            {
                sum = sum + listToBeAveraged[i];
            }
            return sum/count;
        }
    }
}
