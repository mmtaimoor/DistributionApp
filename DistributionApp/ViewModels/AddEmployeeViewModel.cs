using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;

namespace DistributionApp.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        #region [private variables]

        private Employee employee;
        private EmployeeBL objEmployeeBL;

        #endregion

        #region [public properties]

        public Employee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [commands]

        public ICommand SaveEmployee { get; set; }

        #endregion

        public AddEmployeeViewModel()
        {
            Employee = new Employee();
            objEmployeeBL = new EmployeeBL();
            SaveEmployee = new RelayCommand(SaveEmployeeCommand);
        }

        #region [private methods]

        private void SaveEmployeeCommand (object commandparameter)
        {
            
            if (Employee != null)
            {
                objEmployeeBL.SaveEmployee(Employee);
                var window = commandparameter as Window;
                if (window != null)
                    window.Close();
            }
        }

        #endregion

        #region [public methods]

        public void LoadEmployee(int empId)
        {
            Employee = objEmployeeBL.FindEmployeeById(empId);
        }

        #endregion


    }
}
