using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public string AddEmployee(UserpostModel employee);
        public IEnumerable<UserpostModel> GetAllEmployees();
        public UserpostModel GetEmployeeData(int? id);
        public string UpdateEmployee(UserpostModel employee);
        public string DeleteEmployee(int? id);
    }
}
