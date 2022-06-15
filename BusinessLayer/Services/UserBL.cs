using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL UserRL;
        public UserBL(IUserRL UserRL)
        {
            this.UserRL = UserRL;
        }

        public string AddEmployee(UserpostModel employee)
        {
            try
            {
                return UserRL.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                return UserRL.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserpostModel> GetAllEmployees()
        {
            try
            {
                return UserRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserpostModel GetEmployeeData(int? id)
        {
            try
            {
                return UserRL.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateEmployee(UserpostModel employee)
        {
            try
            {
                return UserRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
