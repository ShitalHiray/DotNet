using System;
namespace Assignment3
{
    internal class Program
    {
        static void Main()
        {
            Employee e1 = new Manager("Rahul", 10, "Team Lead", 40000);
            Employee e2 = new GeneralManager("Priya", 20, "GM Admin", 60000, "Car");
            Employee e3 = new CEO("Neha", 1, 150000);

            Console.WriteLine($"EmpNo: {e1.EmpNo}, Salary: {e1.CalcNetSalary()}");
            Console.WriteLine($"EmpNo: {e2.EmpNo}, Salary: {e2.CalcNetSalary()}");
            Console.WriteLine($"EmpNo: {e3.EmpNo}, Salary: {e3.CalcNetSalary()}");

            e1.Insert();
            e2.Update();
            e3.Delete();
        }
    }


    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public abstract class Employee : IDbFunctions
    {
        private static int empCounter = 100;

        public int EmpNo { get; }
        public string Name { get; set; }
        public short DeptNo { get; set; }
        public abstract decimal Basic { get; set; }

        public Employee(string name, short deptNo)
        {
            EmpNo = empCounter++;
            Name = string.IsNullOrWhiteSpace(name) ? throw new Exception("Name can't be blank") : name;
            DeptNo = deptNo > 0 ? deptNo : throw new Exception("DeptNo must be > 0");
        }

        public abstract decimal CalcNetSalary();

        public virtual void Insert() => Console.WriteLine($"{GetType().Name} Inserted");
        public virtual void Update() => Console.WriteLine($"{GetType().Name} Updated");
        public virtual void Delete() => Console.WriteLine($"{GetType().Name} Deleted");
    }

    public class Manager : Employee
    {
        private decimal basic;
        public string Designation { get; set; }

        public override decimal Basic
        {
            get => basic;
            set => basic = (value >= 30000 && value <= 100000)
                ? value
                : throw new Exception("Basic for Manager must be between 30000 and 100000");
        }

        public Manager(string name, short deptNo, string designation, decimal basic)
            : base(name, deptNo)
        {
            Designation = string.IsNullOrWhiteSpace(designation) ? throw new Exception("Designation can't be blank") : designation;
            Basic = basic;
        }

        public override decimal CalcNetSalary() => Basic + Basic * 0.2m;
    }

    public class GeneralManager : Manager
    {
        private decimal basic;
        public string Perks { get; set; }

        public override decimal Basic
        {
            get => basic;
            set => basic = (value >= 50000 && value <= 150000)
                ? value
                : throw new Exception("Basic for GM must be between 50000 and 150000");
        }

        public GeneralManager(string name, short deptNo, string designation, decimal basic, string perks)
            : base(name, deptNo, designation, basic)
        {
            Perks = perks;
            Basic = basic;
        }

        public override decimal CalcNetSalary() => Basic + Basic * 0.3m;
    }

    public class CEO : Employee
    {
        private decimal basic;

        public override decimal Basic
        {
            get => basic;
            set => basic = (value >= 100000 && value <= 200000)
                ? value
                : throw new Exception("Basic for CEO must be between 100000 and 200000");
        }

        public CEO(string name, short deptNo, decimal basic) : base(name, deptNo)
        {
            Basic = basic;
        }

        public sealed override decimal CalcNetSalary() => Basic + Basic * 0.5m;
    }
}
