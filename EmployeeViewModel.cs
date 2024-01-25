using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using MvvmDemo.Commands;
using MvvmDemo.Models;
using System.Collections.ObjectModel;
namespace MvvmDemo.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
        }
        #region DisplayListOperation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value;OnPropertyChanged("EmployeesList"); }
        }
        private void LoadData()
        {
            EmployeesList =new ObservableCollection<Employee>( ObjEmployeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value;OnPropertyChanged("CurrentEmployee"); }
        }
        private string messege;

        public string Messege
        {
            get { return messege; }
            set { messege = value; OnPropertyChanged("Messege"); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
          

        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Messege = "Employee Saved";
                else
                    Messege = "Save option failed";
            }
            catch(Exception ex)
            {
                Messege = ex.Message;
            }
        }



    }
}
