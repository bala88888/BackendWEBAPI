using AspwebApi_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AspwebApi_crud.Controllers
{
    public class CrudApiController : ApiController
    {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployees() { 
        List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }
        //Update--------------------------------------------

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)

        {
            var emp=db.Employees.Where(model=>model.id==id).FirstOrDefault();
          
            return Ok(emp);
        }

        //  ----------------------------------insert-------------------
        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
         db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        //  ----------------------------------update-------------------
        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();
            if(emp != null)
            {
                emp.id = e.id;
                emp.name = e.name;
                emp.degignation = e.degignation;
                emp.gender = e.gender;
                emp.age = e.age;
               emp.salary = e.salary;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        //-----------------------Delete--------------------------------------------------------------------
        [System.Web.Http.HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }







    }
}
