using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public string AddEmployee(UserpostModel employee);
        public IEnumerable<UserpostModel> GetAllEmployees();
        public UserpostModel GetEmployeeData(int? id);
        public string UpdateEmployee(UserpostModel employee);
        public string DeleteEmployee(int? id);



    }
}
