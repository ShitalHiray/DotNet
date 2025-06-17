
using System;

namespace Assignment1
{
    internal class Program
    {
        static void Main()
        {
            Employee o1 = new Employee(1, "Amol", 123465, 10);
            Employee o2 = new Employee(1, "Amol", 123465);
            Employee o3 = new Employee(1, "Amol");
            Employee o4 = new Employee(1);
            Employee o5 = new Employee();


            Console.WriteLine("o1: " + o1.EmpNo + ", " + o1.Name + ", " + o1.Basic + ", " + o1.DeptNo + ", Net Salary = " + o1.GetNetSalary());
            Console.WriteLine("o2: " + o2.EmpNo + ", " + o2.Name + ", " + o2.Basic + ", " + o2.DeptNo + ", Net Salary = " + o2.GetNetSalary());
            Console.WriteLine("o3: " + o3.EmpNo + ", " + o3.Name + ", " + o3.Basic + ", " + o3.DeptNo + ", Net Salary = " + o3.GetNetSalary());
            Console.WriteLine("o4: " + o4.EmpNo + ", " + o4.Name + ", " + o4.Basic + ", " + o4.DeptNo + ", Net Salary = " + o4.GetNetSalary());
            Console.WriteLine("o5: " + o5.EmpNo + ", " + o5.Name + ", " + o5.Basic + ", " + o5.DeptNo + ", Net Salary = " + o5.GetNetSalary());

        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }

        public Employee(int empNo = 1, string name = "NoName", decimal basic = 10000, short deptNo = 1)
        {
            if (empNo > 0)
                EmpNo = empNo;
            else
                Console.WriteLine("Invalid EmpNo");

            if (name != null && name != "")
                Name = name;
            else
                Console.WriteLine("Invalid Name");

            if (basic >= 10000 && basic <= 200000)
                Basic = basic;
            else
                Console.WriteLine("Basic must be between 10000 and 200000");

            if (deptNo > 0)
                DeptNo = deptNo;
            else
                Console.WriteLine("DeptNo must be greater than 0");

      
        }

        public decimal GetNetSalary()
        {
            // Sample formula: Basic + HRA (20%) + DA (10%) - Tax (5%)
            decimal hra = Basic * 0.20m;
            decimal da = Basic * 0.10m;
            decimal tax = Basic * 0.05m;
            return Basic + hra + da - tax;
        }
    }
}