using E_Commerce.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7214/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return View(values);
            }
            return NotFound("Kategori listesi alınamadı");
        }

        public async Task<IActionResult> Details(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7214/api/Categories/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("https://localhost:7214/api/Categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(category);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7214/api/Categories/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PutAsync("https://localhost:7214/api/Categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7214/api/Categories/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7214/api/Categories/" + id);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return NotFound();
        }
    }
}
