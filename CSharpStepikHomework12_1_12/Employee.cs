using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStepikHomework12_1_12
{
    public class Employee
    {
        public string Position { get; private set; }
        public int Grade { get; internal set; }
        public int Salary { get; internal set; }
        public int CoffeeLiters { get; internal set; }
        public int PagesAmount { get; internal set; }
        private int BaseSalary { get; }

        public Employee(int grade, string position, bool isBoss = false)
        {
            Grade = grade;
            Position = position;

            switch (position)
            {
                case "manager":
                    BaseSalary = 50_000;
                    CoffeeLiters = 20;
                    PagesAmount = 200;
                    break;
                case "marketer":
                    BaseSalary = 40_000;
                    CoffeeLiters = 15;
                    PagesAmount = 150;
                    break;
                case "engineer":
                    BaseSalary = 20_000;
                    CoffeeLiters = 5;
                    PagesAmount = 50;
                    break;
                case "analyst":
                    BaseSalary = 80_000;
                    CoffeeLiters = 50;
                    PagesAmount = 5;
                    break;
            }

            GetEmployeeSalary();

            if (isBoss)
            {
                Salary = (int)Math.Round(Salary * 1.5, 0, MidpointRounding.AwayFromZero);
                CoffeeLiters = CoffeeLiters * 2;
                PagesAmount = 0;
            }
        }

        private int GetEmployeeSalary()
        {
            switch (Grade)
            {
                case 1:
                    Salary = BaseSalary;
                    break;
                case 2:
                    Salary = (int)Math.Round(BaseSalary * 1.25, 0, MidpointRounding.AwayFromZero);

                    break;
                case 3:
                    Salary = (int)Math.Round(BaseSalary * 1.5, 0, MidpointRounding.AwayFromZero);
                    break;
            }

            return Salary;
        }
    }
}
