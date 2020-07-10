using System;

namespace Assignment2
{
    class TestAutoMobile
    {
        static void Main(string[] args)
        {
            /*
             * Declarations
             */
            const string line = "____________________________________________________________________________";
            AutoMobile[] carArray = new AutoMobile[10];

            /*
             * Creation of test objects
             */

            carArray[0] = new AutoMobile(0001, "Jaguar", 1955, 35000);
            carArray[1] = new AutoMobile(0002, "Holden", 2012, 15000);
            carArray[2] = new AutoMobile(0003, "Ford", 2017, 20000);
            carArray[3] = new AutoMobile(0004, "Volkswagen", 2013, 7500);
            carArray[4] = new AutoMobile(0005, "Citroen", 1970, 4000,20);

            carArray[5] = new FinancedAutoMobile(0006, "Mazda", 2019, 50000, 2);
            carArray[6] = new FinancedAutoMobile(0007, "Toyota", 2010, 10000, 5);
            carArray[7] = new FinancedAutoMobile(0008, "Kia", 2017, 25000, 6);
            carArray[8] = new FinancedAutoMobile(0009, "Tacot", 2019, 34000, 10);
            carArray[9] = new FinancedAutoMobile(0010, "BMW", 2020, 120000, 9);

          
            for (int i=0 ; i <= (carArray.Length - 1); i += 1)
            {
                Console.WriteLine(line);
                Console.WriteLine(carArray[i]);
            }

            Console.WriteLine(line);
            /*
             * Test with try catch statment (but complete test was done with MTest class AutoTest)
             */

            //Declaration for test

            const int id = 33;
            const string model= "Susuki";
            const int outofRangeFinance = 30;
            const int outofRangeDiscount = -1;
            const int outofRangeYear = 1945;
            const int Year = 2010;
            const float price = 11000;




            try
            {
                AutoMobile car1 = new AutoMobile(id, model, outofRangeYear, price); ;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine("If trying an out of range Year e.g. {0} Error reading Message = {1}",outofRangeYear,e.Message);
            }

    
            try
            {
                FinancedAutoMobile car3 = new FinancedAutoMobile(id, model, Year, price,outofRangeFinance);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine("If trying an out of range finance option e.g. {0} Error reading Message = {1}",outofRangeFinance, e.Message);
            }

            try
            {
                AutoMobile car4 = new AutoMobile(id, model, Year, price, outofRangeDiscount); ;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine("If trying an out of range Discount e.g. {0} Error reading Message = {1}",outofRangeDiscount, e.Message);
            }

        }
    }
}
