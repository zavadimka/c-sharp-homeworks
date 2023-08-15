using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStepikHomework12_1_12
{
    public class Department
    {
        public string DepartmentName { get; init; }
        public List<Employee> Employees { get; }
        public int TotalDepartmentSalary { get; private set; }
        public int TotalDepartmentCoffeeLiters { get; private set; }
        public int TotalDepartmentPagesAmount { get; private set; }

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            Employees = new List<Employee>();
            TotalDepartmentSalary = 0;
            TotalDepartmentCoffeeLiters = 0;
            TotalDepartmentPagesAmount = 0;
        }


        public static List<Department> GetDepartmentEmployees()
        {
            string[] inputStrings = new string[4];

            //for (int i = 0; i < inputStrings.Length; i++)
            //{
            //    inputStrings[i] = Console.ReadLine();
            //}

            //inputStrings[0] = "Департамент закупок: 9*manager1, 3*manager2, 2*manager3, 2*marketer1 + руководитель департамента manager2";
            //inputStrings[1] = "Департамент продаж: 12*manager1, 6*manager1, 3*analyst1, 2*analyst2 + руководитель департамента marketer2";
            //inputStrings[2] = "Департамент рекламы: 15*marketer1, 10*marketer2, 8*manager1, 2*engineer1 + руководитель департамента marketer3";
            //inputStrings[3] = "Департамент логистики: 13*manager1, 5*manager2, 5*engineer1 + руководитель департамента manager1";

            inputStrings[0] = "Департамент закупок: 1*analyst1, 1*analyst1, 1*analyst1, 1*analyst1 + руководитель департамента marketer1";
            inputStrings[1] = "Департамент закупок: 1*engineer3, 1*marketer1, 1*marketer1, 1*marketer1 + руководитель департамента engineer1";
            //inputStrings[1] = "Департамент закупок: 1*engineer1, 1*engineer1, 1*engineer1, 1*engineer1 + руководитель департамента engineer1";
            inputStrings[2] = "Департамент закупок: 1*marketer1, 1*marketer1, 1*marketer1, 1*marketer1 + руководитель департамента marketer1";
            inputStrings[3] = "Департамент закупок: 1*manager1, 1*manager1, 1*manager1, 1*manager1 + руководитель департамента manager1";

            List<Department> allDepartments = new List<Department>();

            for (int i = 0; i < 4; i++)
            {
                // Создаём департаменты
                Department departament = new Department(inputStrings[i].Split(':')[0].Split(' ')[1][0].ToString().ToUpper() + inputStrings[i].Split(':')[0].Split(' ')[1].Substring(1));

                // Добавляем департамент в список департаментов
                allDepartments.Add(departament);


                // Парсим босса департамента
                string bossInfo = inputStrings[i].Split('+')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];
                string bossPosition = bossInfo.Substring(0, bossInfo.Length - 1);
                int bossGrade = int.Parse(bossInfo.Substring(bossInfo.Length - 1));

                // Создаём экземпляр босса и добавляем в список департамента
                Employee boss = new Employee(bossGrade, bossPosition, true);
                departament.Employees.Add(boss);

                departament.TotalDepartmentSalary += departament.Employees[0].Salary;
                departament.TotalDepartmentCoffeeLiters += departament.Employees[0].CoffeeLiters;
                departament.TotalDepartmentPagesAmount += departament.Employees[0].PagesAmount;

                string[] positionsInfo = new string[inputStrings[i].Split(", ").Count()];
                positionsInfo = inputStrings[i].Split(", ");
                positionsInfo[0] = positionsInfo[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[2];
                positionsInfo[positionsInfo.Length - 1] = positionsInfo[positionsInfo.Length - 1].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];


                foreach (string positionInfo in positionsInfo)
                {
                    int positionAmount = int.Parse(positionInfo.Substring(0, positionInfo.IndexOf('*')));

                    string position = positionInfo.Substring(positionInfo.IndexOf('*') + 1, positionInfo.Length - positionInfo.IndexOf('*') - 2);

                    int grade = int.Parse(positionInfo.Substring(positionInfo.Length - 1));

                    //Создаём экземпляры сотрудников и добавляем в список департамента
                    for (int j = 1; j <= positionAmount; j++)
                    {
                        Employee employee = new Employee(grade, position);
                        departament.Employees.Add(employee);

                        departament.TotalDepartmentSalary += employee.Salary;
                        departament.TotalDepartmentCoffeeLiters += employee.CoffeeLiters;
                        departament.TotalDepartmentPagesAmount += employee.PagesAmount;
                    }
                }
            }
            return allDepartments;
        }


        public static void GetDepartmentsStatistic(List<Department> allDepartments)
        {
            Console.WriteLine("Департамент     Сотрудников     Тугрики     Кофе     Страницы     Тугр./стр.");
            Console.WriteLine("----------------------------------------------------------------------------");

            foreach (var department in allDepartments)
            {
                Console.Write($"{department.DepartmentName}");
                for (int i = 1; i <= "Департамент     ".Length - department.DepartmentName.Length; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(department.Employees.Count);
                for (int i = 1; i <= "Сотрудников     ".Length - department.Employees.Count.ToString().Length; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(department.TotalDepartmentSalary);
                for (int i = 1; i <= "Тугрики     ".Length - department.TotalDepartmentSalary.ToString().Length; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(department.TotalDepartmentCoffeeLiters);
                for (int i = 1; i <= "Кофе     ".Length - department.TotalDepartmentCoffeeLiters.ToString().Length; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(department.TotalDepartmentPagesAmount);
                for (int i = 1; i <= "Страницы     ".Length - department.TotalDepartmentPagesAmount.ToString().Length; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(Math.Round((double)department.TotalDepartmentSalary / (double)department.TotalDepartmentPagesAmount, 2, MidpointRounding.AwayFromZero));
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.Write("Всего           ");

            Console.Write(allDepartments.Sum(Department => Department.Employees.Count));
            for (int i = 1; i <= "Сотрудников     ".Length - allDepartments.Sum(department => department.Employees.Count).ToString().Length; i++)
            {
                Console.Write(" ");
            }

            Console.Write(allDepartments.Sum(Department => Department.TotalDepartmentSalary));
            for (int i = 1; i <= "Тугрики     ".Length - allDepartments.Sum(department => department.TotalDepartmentSalary).ToString().Length; i++)
            {
                Console.Write(" ");
            }

            Console.Write(allDepartments.Sum(Department => Department.TotalDepartmentCoffeeLiters));
            for (int i = 1; i <= "Кофе     ".Length - allDepartments.Sum(department => department.TotalDepartmentCoffeeLiters).ToString().Length; i++)
            {
                Console.Write(" ");
            }

            Console.Write(allDepartments.Sum(Department => Department.TotalDepartmentPagesAmount));
            for (int i = 1; i <= "Страницы     ".Length - allDepartments.Sum(department => department.TotalDepartmentPagesAmount).ToString().Length; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(Math.Round((double)allDepartments.Sum(department => department.TotalDepartmentSalary) / (double)allDepartments.Sum(department => department.TotalDepartmentPagesAmount), 2, MidpointRounding.AwayFromZero));
        }


        public static void GetAntiCrisisMeashureResult(List<Department> allDepartments, int measureNumber)
        {
            Console.WriteLine();
            switch (measureNumber)
            {
                case 1:
                    /* Сократить в каждом департаменте 40 % (округляя в большую сторону) инженеров, преимущественно самого низкого ранга.
                     * Если инженер является боссом, вместо него надо уволить другого инженера, не босса */
                    for (int i = 0; i < allDepartments.Count; i++)
                    {
                        int engineerTotalAmount = allDepartments[i].Employees.Count(employee => employee.Position == "engineer");
                        int firstGradeEngineerAmount = allDepartments[i].Employees.Count(employee => employee.Position == "engineer" && employee.Grade == 1);
                        int secondGradeEngineerAmount = allDepartments[i].Employees.Count(employee => employee.Position == "engineer" && employee.Grade == 2);
                        
                        if (allDepartments[i].Employees[0].Position == "engineer")
                        {
                            if (allDepartments[i].Employees[0].Grade == 1)
                            {
                                firstGradeEngineerAmount--;
                            }
                            else if (allDepartments[i].Employees[0].Grade == 2)
                            {
                                secondGradeEngineerAmount--;
                            }
                        }

                        int numberOfEngineersToFire = (int)Math.Ceiling(engineerTotalAmount * 0.4);
                        int firedEngineers = 0;

                        if (allDepartments[i].Employees[0].Position == "engineer" && engineerTotalAmount == 1)
                        {
                            firedEngineers = 1;
                        }

                        while (firedEngineers < numberOfEngineersToFire)
                        {
                            for (int j = 1; j < allDepartments[i].Employees.Count; j++)
                            {
                                if (allDepartments[i].Employees[j].Position == "engineer" && allDepartments[i].Employees[j].Grade == 1 && firedEngineers < numberOfEngineersToFire)
                                {
                                    allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                    allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[j].CoffeeLiters;
                                    allDepartments[i].TotalDepartmentPagesAmount -= allDepartments[i].Employees[j].PagesAmount;

                                    allDepartments[i].Employees.Remove(allDepartments[i].Employees[j]);
                                    firedEngineers++;
                                    firstGradeEngineerAmount--;
                                    j--;
                                }
                                else if (allDepartments[i].Employees[j].Position == "engineer" && allDepartments[i].Employees[j].Grade == 2 && firstGradeEngineerAmount == 0 && firedEngineers < numberOfEngineersToFire)
                                {
                                    allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                    allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[j].CoffeeLiters;
                                    allDepartments[i].TotalDepartmentPagesAmount -= allDepartments[i].Employees[j].PagesAmount;

                                    allDepartments[i].Employees.Remove(allDepartments[i].Employees[j]);
                                    firedEngineers++;
                                    secondGradeEngineerAmount--;
                                    j--;
                                }
                                else if (allDepartments[i].Employees[j].Position == "engineer" && allDepartments[i].Employees[j].Grade == 3 && firstGradeEngineerAmount == 0 && secondGradeEngineerAmount == 0 && firedEngineers < numberOfEngineersToFire)
                                {
                                    allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                    allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[j].CoffeeLiters;
                                    allDepartments[i].TotalDepartmentPagesAmount -= allDepartments[i].Employees[j].PagesAmount;

                                    allDepartments[i].Employees.Remove(allDepartments[i].Employees[j]);
                                    firedEngineers++;
                                    j--;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    /* 2. Увеличить в целях стимуляции умственной деятельности базовую ставку аналитика с 80000 до 110000 тугриков,
                     * а количество выпиваемого им кофе с 50 до 75 литров. В тех департаментах, где руководитель не является аналитиком,
                     * заменить его на аналитика самого высшего ранга из этого департамента (а бывшего руководителя вернуть к обычной работе) */
                    for (int i = 1; i < allDepartments.Count; i++)
                    {
                        // Увеличиваем ЗП и потребление кофе всем аналитикам
                        for (int j = 0; j < allDepartments[i].Employees.Count; j++)
                        {
                            if (allDepartments[i].Employees[j].Position == "analyst")
                            {
                                allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[j].CoffeeLiters;

                                allDepartments[i].Employees[j].Salary = (int)Math.Round((allDepartments[i].Employees[j].Salary * 1.375), 0, MidpointRounding.AwayFromZero);
                                allDepartments[i].Employees[j].CoffeeLiters = (int)Math.Round((allDepartments[i].Employees[j].CoffeeLiters * 1.5), 0, MidpointRounding.AwayFromZero);

                                allDepartments[i].TotalDepartmentSalary += allDepartments[i].Employees[j].Salary;
                                allDepartments[i].TotalDepartmentCoffeeLiters += allDepartments[i].Employees[j].CoffeeLiters;
                            }
                        }

                        // Понижаем руководителя до обычного сотрудника
                        if (allDepartments[i].Employees[0].Position != "analyst" && allDepartments[i].Employees.Exists(employee => employee.Position == "analyst"))
                        {
                            string bossPosition = allDepartments[i].Employees[0].Position;
                            int bossGrade = allDepartments[i].Employees[0].Grade;
                            var bossDowngrade = new Employee(bossGrade, bossPosition);
                            allDepartments[i].Employees.Add(bossDowngrade);
                            
                            allDepartments[i].TotalDepartmentSalary += bossDowngrade.Salary;
                            allDepartments[i].TotalDepartmentCoffeeLiters += bossDowngrade.CoffeeLiters;
                            allDepartments[i].TotalDepartmentPagesAmount += bossDowngrade.PagesAmount;

                            allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[0].Salary;
                            allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[0].CoffeeLiters;
                            allDepartments[i].Employees.RemoveAt(0);


                            // Меняем руководителя на аналитика самого высшего ранга
                            int indexOfMaxGradeAnalyst = allDepartments[i].Employees.FindIndex(1, employee => employee.Position == "analyst" && employee.Grade == allDepartments[i].Employees.Max(employee => employee.Grade));
                            var bossAnalyst = new Employee(allDepartments[i].Employees[indexOfMaxGradeAnalyst].Grade, "analyst", true);
                            bossAnalyst.Salary = (int)Math.Round((bossAnalyst.Salary * 1.375), 0, MidpointRounding.AwayFromZero);
                            bossAnalyst.CoffeeLiters = (int)Math.Round((bossAnalyst.CoffeeLiters * 1.5), 0, MidpointRounding.AwayFromZero);

                            allDepartments[i].Employees.Add(bossAnalyst);
                            allDepartments[i].TotalDepartmentSalary += bossAnalyst.Salary;
                            allDepartments[i].TotalDepartmentCoffeeLiters += bossAnalyst.CoffeeLiters;
                            
                            allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[indexOfMaxGradeAnalyst].Salary;
                            allDepartments[i].TotalDepartmentCoffeeLiters -= allDepartments[i].Employees[indexOfMaxGradeAnalyst].CoffeeLiters;
                            allDepartments[i].TotalDepartmentPagesAmount -= allDepartments[i].Employees[indexOfMaxGradeAnalyst].PagesAmount;
                            allDepartments[i].Employees.RemoveAt(indexOfMaxGradeAnalyst);
                        }
                    }
                    break;
                case 3:
                    /* 3. В каждом департаменте повысить 50% (округляя в большую сторону) менеджеров 1-го и 50% менеджеров 2-го ранга на один ранг
                     * с целью расширить их полномочия.*/
                    for (int i = 0; i < allDepartments.Count; i++)
                    {
                        int firstGradeManagerAmount = allDepartments[i].Employees.Count(employee => employee.Position == "manager" && employee.Grade == 1);
                        int secondGradeManagerAmount = allDepartments[i].Employees.Count(employee => employee.Position == "manager" && employee.Grade == 2);

                        int firstGradeManagerAmountToPromotion = (int)Math.Ceiling(firstGradeManagerAmount * 0.5);
                        int secondGradeManagerAmountToPromotion = (int)Math.Ceiling(secondGradeManagerAmount * 0.5);

                        int promotedFirstGradeManagers = 0;
                        int promotedSecondGradeManagers = 0;

                        if (allDepartments[i].Employees[0].Position == "manager" && allDepartments[i].Employees[0].Grade == 2 && promotedSecondGradeManagers < secondGradeManagerAmountToPromotion)
                        {
                            allDepartments[i].Employees[0].Grade = 3;
                            allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[0].Salary;
                            allDepartments[i].Employees[0].Salary = 112_500;
                            allDepartments[i].TotalDepartmentSalary += allDepartments[i].Employees[0].Salary;
                            promotedSecondGradeManagers++;
                        }
                        else if (allDepartments[i].Employees[0].Position == "manager" && allDepartments[i].Employees[0].Grade == 1 && promotedFirstGradeManagers < firstGradeManagerAmountToPromotion)
                        {
                            allDepartments[i].Employees[0].Grade = 2;
                            allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[0].Salary;
                            allDepartments[i].Employees[0].Salary = 93_750;
                            allDepartments[i].TotalDepartmentSalary += allDepartments[i].Employees[0].Salary;
                            promotedFirstGradeManagers++;
                        }

                        for (int j = 1; j < allDepartments[i].Employees.Count; j++)
                        {
                            if (allDepartments[i].Employees[j].Position == "manager" && allDepartments[i].Employees[j].Grade == 2 && promotedSecondGradeManagers < secondGradeManagerAmountToPromotion)
                            {
                                allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                allDepartments[i].Employees.Remove(allDepartments[i].Employees[j]);
                                
                                Employee promotingEmployee = new Employee(3, "manager");
                                allDepartments[i].Employees.Add(promotingEmployee);

                                allDepartments[i].TotalDepartmentSalary += promotingEmployee.Salary;
                                promotedSecondGradeManagers++;
                            }
                            else if (allDepartments[i].Employees[j].Position == "manager" && allDepartments[i].Employees[j].Grade == 1 && promotedFirstGradeManagers < firstGradeManagerAmountToPromotion)
                            {
                                allDepartments[i].TotalDepartmentSalary -= allDepartments[i].Employees[j].Salary;
                                allDepartments[i].Employees.Remove(allDepartments[i].Employees[j]);

                                Employee promotingEmployee = new Employee(2, "manager");
                                allDepartments[i].Employees.Add(promotingEmployee);

                                allDepartments[i].TotalDepartmentSalary += promotingEmployee.Salary;
                                promotedFirstGradeManagers++;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
