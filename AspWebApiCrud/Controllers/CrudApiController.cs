using AspWebApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspWebApiCrud.Controllers
{
    public class CrudApiController : ApiController
    {
        DEMOEntities db = new DEMOEntities();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<tbl_Employees> list = db.tbl_Employees.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeesById(int id)
        {
           var a= db.tbl_Employees.Where(m => m.id == id).FirstOrDefault();
           
            return Ok(a);
        }

        [HttpPost]
        public IHttpActionResult EmpInsert(tbl_Employees model)
        {
            db.tbl_Employees.Add(model);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EmpUpdate(tbl_Employees model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            //var emp = db.tbl_Employees.Where(m => m.id == model.id).FirstOrDefault();
            //if (emp!= null)
            //{
            //    emp.id = model.id;
            //    emp.name = model.name;
            //    emp.gender = model.gender;
            //    emp.age = model.age;
            //    emp.designation = model.designation;
            //    emp.salary = model.salary;
            //    db.SaveChanges();

            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.tbl_Employees.Where(m => m.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
