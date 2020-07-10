using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2;

namespace AutoTest
{
    [TestClass]
    public class TestAutoClass
    {
        /*
         * Declaration
         */

        const string model = "Tesla";
        const int id = 33;
        const int yearcar = 2000;
        const float prix = 1000000;
        const int financed = 5;

        [TestMethod]
        public void TestConstructorAutomobile()
        {
            AutoMobile car = new AutoMobile(id, model, yearcar, prix);

            Assert.AreEqual(id, car.IdNumber, "Id incorrect");
            Assert.AreEqual(model, car.Make, "Make incorrect");
            Assert.AreEqual(yearcar, car.Year, "Year incorrect");
            Assert.AreEqual(prix, car.Price, "Price incorrect");
           

        }
        /*
         * Test of the condition on Year that is not lower than 1950 and not higher than 2020
         */

        [TestMethod]
        public void ToLowTestYear()
        {
            int toLowTestYear = 1949;
            try
            {
                AutoMobile car = new AutoMobile(id, model, toLowTestYear, prix);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, AutoMobile.FailYear);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void TestYearHigh()
        {
            const int toHighTestYear = 2021;
            try
            {
                AutoMobile car = new AutoMobile(id, model, toHighTestYear, prix);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, AutoMobile.FailYear);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void TestYearLowBoundary()
        {
            const int minYear = 1950;

            AutoMobile car = new AutoMobile(id, model, minYear, prix);

            Assert.AreEqual(minYear, car.Year, 0, "Year loop lower boundary incorrect");

        }
        [TestMethod]
        public void TestYearHighBoundary()
        {
            const int maxYear = 2020;

            AutoMobile car = new AutoMobile(id, model, maxYear, prix);

            Assert.AreEqual(maxYear, car.Year, 0, "Year loop High boundary incorrect");

        }

        /*
         * Test of the Discount condition the accepted Discount must not be lower than 0 and not higher than 20.
         * The first test check if the discount calculation are correct.
         */

        [TestMethod]
        public void TestAutoMoblileOverloadDiscount()
        {
            const float testDiscount = 5;
            const float expected =950000;

            AutoMobile car = new AutoMobile(id, model, yearcar, prix, testDiscount);

            Assert.AreEqual(expected, car.Price, 0.001, "discount calculation incorrect");
            Assert.AreEqual(id, car.IdNumber, "Id incorrect");
            Assert.AreEqual(model, car.Make, "Make incorrect");
            Assert.AreEqual(yearcar, car.Year, "Year incorrect");

        }

        [TestMethod]
        public void TestDiscountHighBound()
        {
            const float toHighTestDiscount = 21;

            try
            {
                AutoMobile car = new AutoMobile(id, model, yearcar, prix, toHighTestDiscount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, AutoMobile.DiscountOutofRange);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void TestDiscountLowBound()
        {
            const float negativeDiscount = -1;

            try
            {
                AutoMobile car = new AutoMobile(id, model, yearcar, prix, negativeDiscount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, AutoMobile.DiscountOutofRange);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void TestDiscountLowBoundary()
        {
            const int minDiscount = 0;

            AutoMobile car = new AutoMobile(id, model, yearcar, prix, minDiscount);

            Assert.AreEqual(prix, car.Price, 0, "Discount lower boundary incorrect");

        }
        [TestMethod]
        public void TestDiscountHighBoundary() //also provide a check of correct calculation of price when a discount is provided
        {
            const int maxDiscount = 20;
            const float expected = 800000;
            AutoMobile car = new AutoMobile(id, model, yearcar, prix,maxDiscount);

            Assert.AreEqual(expected, car.Price, 0, "Discount High boundary incorrect");

        }

        /*
         * Test of FinancedAutomobile class
         * 
         */

        [TestMethod]
        public void TestConstructorFinancedAutomobile()
        {
            FinancedAutoMobile car = new FinancedAutoMobile(id, model, yearcar, prix, financed);

            Assert.AreEqual(id, car.IdNumber, "Id incorrect");
            Assert.AreEqual(model, car.Make, "Make incorrect");
            Assert.AreEqual(yearcar, car.Year, "Year incorrect");
            Assert.AreEqual(prix, car.Price, "Price incorrect");
            Assert.AreEqual(financed, car.Finance, "Finance incorrect");

        }

        [TestMethod]
        public void TestFinanceBound()
        {
            const float toHighTestFinance = 11;

            try
            {
                FinancedAutoMobile car = new FinancedAutoMobile(id, model, yearcar, prix, toHighTestFinance);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, FinancedAutoMobile.FinanceOutofRange);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        
        [TestMethod]
        public void TestFinanceLowBound()
        {
            const float toLowTestFinance = -1;

            try
            {
                FinancedAutoMobile car = new FinancedAutoMobile(id, model, yearcar, prix, toLowTestFinance);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, FinancedAutoMobile.FinanceOutofRange);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }




        /*
         * The following test should be passed as they are passed in the parent class
         * and the constructor call the parent class for that (but done for training purpose)
         */

        [TestMethod]
        public void TestYearHighFinanced()
        {
            const int toHighTestYear = 2021;
            try
            {
                FinancedAutoMobile car = new FinancedAutoMobile(id, model, toHighTestYear, prix, financed);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, FinancedAutoMobile.FailYear);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void ToLowTestYearFinanced()
        {
            int toLowTestYear = 1949;
            try
            {
                FinancedAutoMobile car = new FinancedAutoMobile(id, model, toLowTestYear, prix,financed);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, FinancedAutoMobile.FailYear);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void TestYearLowBoundaryFinanced()
        {
            const int minYear = 1950;

            FinancedAutoMobile car = new FinancedAutoMobile(id, model, minYear, prix, financed);

            Assert.AreEqual(minYear, car.Year, 0, "Year loop lower boundary incorrect");

        }
        [TestMethod]
        public void TestYearHighBoundaryFinanced()
        {
            const int maxYear = 2020;

            FinancedAutoMobile car = new FinancedAutoMobile(id, model, maxYear, prix,financed);

            Assert.AreEqual(maxYear, car.Year, 0, "Year loop High boundary incorrect");

        }
    }

}
