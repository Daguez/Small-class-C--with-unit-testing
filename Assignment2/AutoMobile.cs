using System;
namespace Assignment2
{
    public class AutoMobile
    {
        /*
         * For testing Purpose with Test Class AutoTest.cs
         */

        public const string FailYear = "Year out of Range 1950<=Year<=2020";
        public const string DiscountOutofRange = "Discount is out of Range 0<=Discount<=20";
        /*
         **************************
         */

        private int idNumber;
        public int IdNumber
        {
            get { return idNumber; }
            private set { idNumber = value; }
        }
        private string make;
        public string Make
        {
            get { return make; }
            private set { make = value; }
        }
        private int year;
        public int Year
        {
            get { return year; }
            private set { year = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            private set { price = value; }
        }

        //Constructor

        public AutoMobile(int CarId, string ModelMake, int ModelYear, float CarPrice)
        {
            idNumber = CarId;
            make = ModelMake;
            price = CarPrice;
            if (ModelYear >= 1950 & ModelYear <= 2020)
            {
                year = ModelYear;

            }
            else
            {
                throw new ArgumentOutOfRangeException(FailYear);
            }
        }
        //Extending the Constructor
        public AutoMobile(int CarId, string ModelMake, int ModelYear, float CarPrice, float Discount)
        {
            idNumber = CarId;
            make = ModelMake;
            year = ModelYear;

            if (ModelYear >= 1950 & ModelYear <= 2020)
            {
                year = ModelYear;
            }
            else
            {
                throw new ArgumentOutOfRangeException(FailYear);
            }
            if (Discount >= 0 & Discount <= 20)
            {
                price = CarPrice - (CarPrice * Discount) / 100;
            }
            else
            {
                throw new ArgumentOutOfRangeException(DiscountOutofRange);
            }

        }

        public void GetDetails()
        {
            string returnDetails = "Make : " + Make + ", Price : " + Price.ToString("C");
            Console.WriteLine(returnDetails);

        }
        public override string ToString()
        {
            string returnRecord = "CarID: " + IdNumber + ", Make: " + Make + ", Year model: " + Year + ", Price : " + Price.ToString("C");
            return returnRecord;
        }
    }
    public class FinancedAutoMobile : AutoMobile
    {
        /*
         * For testing Purpose with Test Class AutoTest.cs
         */
        public const string FinanceOutofRange = "Finance value out of range 0<=finance<=10";

        /*
        **************************
        */

        private float finance;
        public float Finance
        {
            get { return finance; }
            private set { finance = value; }
        }

        //Constructor
        public FinancedAutoMobile(int CarId, string ModelMake, int ModelYear, float CarPrice, float FinanceCar) : base(CarId, ModelMake, ModelYear, CarPrice)
        {
           if (FinanceCar>=0 & FinanceCar <= 10)
            {
                finance = FinanceCar;
            }

            else
            {
                throw new ArgumentOutOfRangeException(FinanceOutofRange);
            }

        }
        public override string ToString()
        {
            string returnRecord = "CarID: " + IdNumber + ", Make: " + Make + ", Year model: " + Year + ", Price : " + Price.ToString("C") + ", Finance: " + finance + "%";
            return returnRecord;
        }
    }
}
