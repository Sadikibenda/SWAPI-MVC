using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwapiMVC.Models;

namespace SwapiMVC.Controllers
{
    public class PeopleController: Controller
    {
        private readonly HttpClient _httpClient;                       // line 11-14 HTtpclient set up used to access API's data inside our controller
        public PeopleController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("swapi");
        }
        public async Task<IActionResult> Index([FromQuery] string page)
        {
            string route = $"people?page={page ?? "1"}";
            HttpResponseMessage response = await _httpClient.GetAsync(route);

            var viewModel = await response.Content.ReadFromJsonAsync<ResultsViewModel<PeopleViewModel>>();

            return View(viewModel);
        }
        public async Task<IActionResult> Person([FromRoute] string id)
        {
            var response = await _httpClient.GetAsync($"people/{id}");
            if (id is null || response.IsSuccessStatusCode == false)
                return RedirectToAction(nameof(Index));

                var person = await response.Content.ReadFromJsonAsync<PeopleViewModel>();
                return View(person);
        }
    }
}