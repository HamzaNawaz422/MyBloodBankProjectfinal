using BloodReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BloodReal.Controllers
{
    public class RequestsController : Controller
    {
        // GET: Requests
        public ActionResult Index()
        {
            IEnumerable<Models.Request> requests = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");
                var responseTask = client.GetAsync("requests");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Models.Request>>();
                    readTask.Wait();

                    requests = readTask.Result;
                }
                else
                {
                    requests = Enumerable.Empty<Models.Request>();
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact admin.");
                }
            }
            return View(requests);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");
                var postTask = client.PostAsJsonAsync<Request>("requests", request);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact admin.");

            return View(request);
        }

        public ActionResult Edit(int id)
        {
            Request request = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");

                var responseTask = client.GetAsync("requests?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Request>();
                    readTask.Wait();

                    request = readTask.Result;
                }
            }

            return View(request);
        }

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10497/api/");

                var putTask = client.PutAsJsonAsync("requests?id=" + request.Id, request);
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

                var deleteTask = client.DeleteAsync("requests/" + id.ToString());
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