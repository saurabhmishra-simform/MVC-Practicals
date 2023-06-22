﻿using Practical12.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Practical12.Controllers
{
    public class EmployeeController : Controller
    {
        private string _connectionstring= ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString;
        public ActionResult Index()
        {
            List<Employee> employees = GetEmployees(); 
            return View(employees);
        }
        public ActionResult Create(int? id) 
        {
            if(id==0 || id==null)
            {
                ViewBag.btnval = "Create";
            }
            else
            {
                ViewBag.btnval = "Update";
                Employee employees = GetEmployees(id ??0);
                return View(employees);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(DateTime.Now.Year-employee.DOB.Year<18)
            {
                ModelState.AddModelError("invaliddate", "Invalid DOB");
            }
            if(employee.Id!=null ||employee.Id!=0)
            {
                ViewBag.btnval = "Update";
            }
            else
            {
                ViewBag.btnval = "Create";
            }
            if(ModelState.IsValid)
            {
                int status=0;
                if(employee.Id!=0)
                {
                    status = UpdateEmployee(employee);
                }
                else
                {
                    status = CreateEmployee(employee);
                }
                if (status > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if(id==0 || id == null)
            {
                HttpNotFound();
            }
            int status= DeleteEmployee(id);
            return RedirectToAction("Index");    
        }
        [NonAction]
        private List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Employee", con);
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    employees.Add(new Employee()
                    {
                        Id = dataReader.GetInt32(dataReader.GetOrdinal("Id")),
                        FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName")),
                        MiddleName = dataReader.IsDBNull(dataReader.GetOrdinal("MiddleName")) ? string.Empty : dataReader.GetString(dataReader.GetOrdinal("MiddleName")),
                        LastName = dataReader.GetString(dataReader.GetOrdinal("LastName")),
                        DOB = dataReader.GetDateTime(dataReader.GetOrdinal("DOB")),
                        Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile")),
                        Address = dataReader.IsDBNull(dataReader.GetOrdinal("Address")) ? string.Empty : dataReader.GetString(dataReader.GetOrdinal("Address")),

                    });
                }
            }
            return employees;
        }
        [NonAction]
        private Employee GetEmployees(int id)
        {
            Employee employees=new Employee();
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                
                SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE Id=@Id", con);
                command.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                     employees = new Employee()
                    {
                        Id = dataReader.GetInt32(dataReader.GetOrdinal("Id")),
                        FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName")),
                        MiddleName = dataReader.IsDBNull(dataReader.GetOrdinal("MiddleName")) ? string.Empty : dataReader.GetString(dataReader.GetOrdinal("MiddleName")),
                        LastName = dataReader.GetString(dataReader.GetOrdinal("LastName")),
                        DOB = dataReader.GetDateTime(dataReader.GetOrdinal("DOB")),
                        Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile")),
                        Address = dataReader.IsDBNull(dataReader.GetOrdinal("Address")) ? string.Empty : dataReader.GetString(dataReader.GetOrdinal("Address")),
                    };
                 
                }
            }
            return employees;
        }
        [NonAction]
        private int CreateEmployee(Employee employee)
        {
            int affectedRows = 0;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Employee(FirstName, MiddleName, LastName, DOB, Mobile, Address) VALUES(@FirstName, @MiddleName, @LastName, @DOB, @MobileNumber, @Address)", con);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@MiddleName", (object)employee.MiddleName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@DOB", employee.DOB);
                command.Parameters.AddWithValue("@MobileNumber", employee.Mobile);
                command.Parameters.AddWithValue("@Address", (object)employee.Address ?? DBNull.Value);
                con.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            return affectedRows;
        }
        [NonAction]
        private int UpdateEmployee(Employee employee)
        {
            int affectedRows = 0;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("UPDATE Employee SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DOB = @DOB, Mobile = @Mobile, Address = @Address WHERE Id = @Id", con);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@MiddleName", (object)employee.MiddleName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@DOB", employee.DOB);
                command.Parameters.AddWithValue("@Mobile", employee.Mobile);
                command.Parameters.AddWithValue("@Address", (object)employee.Address ?? DBNull.Value);
                con.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            return affectedRows;
        }
        [NonAction]
        private int DeleteEmployee(int id)
        {
            int affectedRows = 0;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE Id = @Id", con);
                command.Parameters.AddWithValue("@Id", id);
                con.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            return affectedRows;
        }
    }
}