using System.Globalization;

namespace CSharpStepikHomework12_1_12
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo englishCulture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = englishCulture;

            int measureNumber = 1;
            List<Department> allDepartments = new List<Department>();
            allDepartments = Department.GetDepartmentEmployees();
            Department.GetDepartmentsStatistic(allDepartments);
            Console.WriteLine();
            Department.GetAntiCrisisMeashureResult(allDepartments, measureNumber);
            Department.GetDepartmentsStatistic(allDepartments);
        }
    }
}