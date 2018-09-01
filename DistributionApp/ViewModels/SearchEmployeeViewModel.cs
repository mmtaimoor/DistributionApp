using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;
using DistributionApp.Views;

namespace DistributionApp.ViewModels
{
    public class SearchEmployeeViewModel : BaseViewModel
    {
        #region [private variables]

        private ObservableCollection<Employee> _employeeList;
        private Employee _searchParamEmp;
        private EmployeeBL objEmpBL;

        #endregion

        #region [public properties]

        public ObservableCollection<Employee> EmployeeList
        {
            get { return _employeeList; }
            set
            {
                _employeeList = value;
                OnPropertyChanged();
            }
        }

        public Employee SearchEmpParams
        {
            get { return _searchParamEmp; }
            set
            {
                _searchParamEmp = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [commands]

        public ICommand SearchEmployee { get; set; }
        public ICommand AddNewEmployee { get; set; }
        public ICommand EditEmplopyee { get; set; }

        #endregion


        public SearchEmployeeViewModel()
        {
            objEmpBL = new EmployeeBL();
            SearchEmpParams = new Employee();
            SearchEmployee = new RelayCommand(SearchEmployeeCommand);
            AddNewEmployee = new RelayCommand(AddNewEmployeeCommand);
            EditEmplopyee = new RelayCommand(EditEmplopyeeCommand);
            EmployeeList = new ObservableCollection<Employee>(objEmpBL.GetAllEmployees());
        }

        #region [private methods]

        private void SearchEmployeeCommand (object commandparameter)
        {
            EmployeeList = new ObservableCollection<Employee>
                (objEmpBL.SearchEmployeeByParameters(SearchEmpParams.Name, SearchEmpParams.IsSalesman.GetValueOrDefault(), 
                SearchEmpParams.IsOrderBooker.GetValueOrDefault()));
        }
        private void AddNewEmployeeCommand (object commandparameter)
        {
            AddEmployeeView view = new AddEmployeeView()
            {
                DataContext = new AddEmployeeViewModel()
            };
            view.ShowDialog();
            EmployeeList = new ObservableCollection<Employee>(objEmpBL.GetAllEmployees());
        }

        private void EditEmplopyeeCommand(object commandparameter)
        {
            int empId = int.Parse(commandparameter.ToString());
            AddEmployeeViewModel model = new AddEmployeeViewModel();
            model.LoadEmployee(empId);
            AddEmployeeView view = new AddEmployeeView()
            {
                DataContext = model,
                Title = "Edit Employee"
            };
            view.ShowDialog();
            EmployeeList = new ObservableCollection<Employee>(objEmpBL.GetAllEmployees());
        }

        #endregion

    }
}
