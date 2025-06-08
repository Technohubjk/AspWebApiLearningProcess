using AspWebApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspWebApiCrud.Controllers
{
    public class CrudMVCController : Controller
    {
        // GET: CrudMVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<tbl_Employees> emp_list = new List<tbl_Employees>();
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
           var response= client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<tbl_Employees>>();
                display.Wait();
                emp_list= display.Result;
            }
            return View(emp_list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Create(tbl_Employees emp)
        {
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.PostAsJsonAsync<tbl_Employees>("CrudApi", emp);
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            tbl_Employees e = null;
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.GetAsync("CrudApi?id="+id.ToString());
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<tbl_Employees>();
                display.Wait();
                e=display.Result;
                //return RedirectToAction("Index");
            }
            return View(e);
        }
        public ActionResult Edit(int id)
        {
            tbl_Employees e = null;
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.GetAsync("CrudApi?id=" + id.ToString());
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<tbl_Employees>();
                display.Wait();
                e = display.Result;
                //return RedirectToAction("Index");
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(tbl_Employees e)
        {
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.PutAsJsonAsync<tbl_Employees>("CrudApi", e);
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            tbl_Employees e = null;
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.GetAsync("CrudApi?id=" + id.ToString());
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<tbl_Employees>();
                display.Wait();
                e = display.Result;
                //return RedirectToAction("Index");
            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44370/api/CrudApi");
            var res = client.DeleteAsync("CrudApi/"+id.ToString());
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}