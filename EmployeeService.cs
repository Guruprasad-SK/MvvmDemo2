using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeesList;

        public EmployeeService()
        {
            ObjEmployeesList = new List<Employee>()
            {
                new Employee{Id=1,Name="Vinay",Age=21},
                new Employee{Id=2,Name="Guruprasad",Age=23}
            };
        }

        public List<Employee> GetAll()
        {
            return ObjEmployeesList;

        }

        public bool Add(Employee objNewEmployee)
        {
           
           
            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee ObjEmployeeToUpdate)
        {
            bool IsUpdated = false;
            for (int index = 0; index <= ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == ObjEmployeeToUpdate.Id)
                {
                    ObjEmployeesList[index].Name = ObjEmployeeToUpdate.Name;
                    ObjEmployeesList[index].Age = ObjEmployeeToUpdate.Age;
                    IsUpdated = true;
                    break;

                }
            }
            return IsUpdated;
        }

        public bool Delete(int Id)
        {
            bool IsDeleted = false;
            for (int index = 0; index <= ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == Id)
                {
                    ObjEmployeesList.RemoveAt(index);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }

        public Employee Search(int Id)
        {
            return ObjEmployeesList.FirstOrDefault(X => X.Id == Id);
        }
    }
}
