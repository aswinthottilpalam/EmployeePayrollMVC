﻿using CommonLayer.User;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // To add New Employee Record
        public string AddEmployee(UserpostModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return "Employee Added Successfully";
                }
                else
                {
                    return "Employee Added Unsuccessfull";
                }
            }
        }

        // Delete Emplloyee
        public string DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return " Employee Deleted Successfully";
                }
                else
                {
                    return null;
                }
            }
        }

        // To View All Employee Details
        public IEnumerable<UserpostModel> GetAllEmployees()
        {
            List<UserpostModel> lstemployee = new List<UserpostModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserpostModel employee = new UserpostModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt32(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        // Get details of a particular employee
        public UserpostModel GetEmployeeData(int? id)
        {
            UserpostModel employee = new UserpostModel();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt32(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);
                }

            }
            return employee;
        }

        // To Update New Employee Record
        public string UpdateEmployee(UserpostModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return "Employee Updated Successfully";
                }
                else
                {
                    return " Employee Update Unsuccessfull";
                }
            }
        }
    }
}