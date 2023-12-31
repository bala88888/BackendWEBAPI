﻿using AspwebApi_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AspwebApi_crud.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> emp_list=new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp_list = display.Result;
            }
           
            return View(emp_list);
        }

        //  ----------------------------------insert- GET------------------
        public ActionResult Create() { 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi", emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Create");
        }

        //Update--------------------------------------------
        public ActionResult Details(int id)
        {
            Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id="+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();

                display.Wait();

                e = display.Result;


            }
            return View(e);
        }


        //Edit-------------------------------------------------------

        public ActionResult Edit(int id)
        {
            Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();

                display.Wait();

                e = display.Result;


            }
            return View(e);
          
        }

        //Edited then post----------------------------
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi",e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
              return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //---Delete----------------------------------------------------
        public ActionResult Delete(int id)
        { Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();

                display.Wait();

                e = display.Result;


            }
            return View(e);


            
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirme(int id)
        {

            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/"+ id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
       
        }
    }
       
    }
