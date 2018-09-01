using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class EmployeeBL
    {
        public EmployeeBL()
        {

        }

        public List<Employee> GetAllEmployees()
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Employees.ToList();
            }
        }

        public List<Employee> SearchEmployeeByParameters(string _empName, bool isSalesMan, bool isOrderBooker)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Employees.Where(x =>
                        x.Name.Contains(_empName) ).ToList();
            }
        }

        public void SaveEmployee(Employee _employee)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var emp = context.Employees.FirstOrDefault(x => x.EmployeeId == _employee.EmployeeId);
                if (emp == null)
                {
                    context.Employees.Add(_employee);
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(emp).CurrentValues.SetValues(_employee);
                    context.SaveChanges();
                }
            }
        }

        public Employee FindEmployeeById(int empId)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Employees.FirstOrDefault(x => x.EmployeeId == empId);
            }
        }



    }
}
