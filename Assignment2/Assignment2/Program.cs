using System;
namespace Assignment2
{
    internal class Program
    {
            static void Main()
            {
                Employee o1 = new Employee("Amol", 123465, 10);
                Employee o2 = new Employee("Pooja", 15000);
                Employee o3 = new Employee("Rahul");
                Employee o4 = new Employee();

              
                Console.WriteLine("EmpNo for each object:");
                Console.WriteLine(o1.EmpNo);
                Console.WriteLine(o2.EmpNo);
                Console.WriteLine(o3.EmpNo);
                Console.WriteLine(o4.EmpNo);

                Console.WriteLine("Reverse Order:");
                Console.WriteLine(o4.EmpNo);
                Console.WriteLine(o3.EmpNo);
                Console.WriteLine(o2.EmpNo);
                Console.WriteLine(o1.EmpNo);
            }
        }

        public class Employee
        {
            private static int lastEmpNo = 0;  

            public int EmpNo { get; }  

            private string name;
            public string Name
            {
                get => name;
                set
                {
                    if (value != null && value != "")
                        name = value;
                    else
                        Console.WriteLine("Invalid Name");
                }
            }

            private decimal basic;
            public decimal Basic
            {
                get => basic;
                set
                {
                    if (value >= 10000 && value <= 200000)
                        basic = value;
                    else
                        Console.WriteLine("Invalid Basic salary");
                }
            }

            private short deptNo;
            public short DeptNo
            {
                get => deptNo;
                set
                {
                    if (value > 0)
                        deptNo = value;
                    else
                        Console.WriteLine("Invalid DeptNo");
                }
            }

           
            public Employee(string name, decimal basic, short deptNo)
            {
                EmpNo = ++lastEmpNo;
                Name = name;
                Basic = basic;
                DeptNo = deptNo;
            }

            public Employee(string name, decimal basic) : this(name, basic, 1) { }

            public Employee(string name) : this(name, 10000, 1) { }

            public Employee() : this("NoName", 10000, 1) { }

            public decimal GetNetSalary()
            {
                decimal hra = Basic * 0.20m;
                decimal da = Basic * 0.10m;
                decimal tax = Basic * 0.05m;
                return Basic + hra + da - tax;
            }
        }
    }
