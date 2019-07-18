	using BloodReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BloodReal.Controllers
{
    public class DonorsController : Controller
    {
        // GET: Donors
        public ActionResult Index()
        {
            IEnumerable<Models.Donor> donors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");
                var responseTask = client.GetAsync("donors");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Models.Donor>>();
                    readTask.Wait();

                    donors = readTask.Result;
                }
                else
                {
                    donors = Enumerable.Empty<Models.Donor>();
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact admin.");
                }
            }
            return View(donors);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Donor donor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");
                var postTask = client.PostAsJsonAsync<Donor>("donors", donor);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact admin.");

            return View(donor);
        }

        public ActionResult Edit(int id)
        {
            Donor donor = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");

                var responseTask = client.GetAsync("donors?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Donor>();
                    readTask.Wait();

                    donor = readTask.Result;
                }
            }

            return View(donor);
        }

        [HttpPost]
        public ActionResult Edit(Donor donor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");

                var putTask = client.PutAsJsonAsync("donors?id=" + donor.Id, donor);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");

                var deleteTask = client.DeleteAsync("donors/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact admin.");

            return RedirectToAction("Index");
        }

    }
}