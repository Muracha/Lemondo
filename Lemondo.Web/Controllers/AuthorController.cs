namespace Lemondo.Web.Controllers;

public class AuthorController : Controller
{
    private readonly IConfigurationRoot _configuration;

    public AuthorController(IConfigurationRoot configuration)
    {
        _configuration = configuration;
    }

    public async Task<ActionResult> Index()
    {
        using (var client = new HttpClient())
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            var response = await client.GetAsync("api/Author");
            var result = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<List<AuthorModel>>(result, options);

            return View(authors);
        }
    }

    public async Task<ActionResult> Details(int id)
    {
        using (var client = new HttpClient())
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            var response = await client.GetAsync($"api/Author/get/{id}");
            var result = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<AuthorModel>(result, options);

            return View(authors);
        }
    }

    public async Task<ActionResult> Search(string searchTerm)
    {
        if (searchTerm == null)
        {
            return RedirectToAction("Index", "Author");
        }
        using (var client = new HttpClient())
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            var response = await client.GetAsync($"api/Author/search/{searchTerm}");
            var result = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<List<AuthorModel>>(result, options);

            return View(authors);
        }
    }

    public async Task<ActionResult> Update(AuthorModel model)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));
            
            var response = await client.PutAsJsonAsync($"api/Author", model);

            return RedirectToAction("Details", new { id = model.Id });
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));
            
            await client.DeleteAsync($"api/Author/delete/{id}");

            return RedirectToAction("Index", "Author");
        }
    }

    public async Task<ActionResult> Create(AuthorModel model)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.PostAsJsonAsync($"api/Author", model);

            return RedirectToAction("Index", "Author");
        }
    }

    public async Task<IActionResult> CreateView()
    {
        return View();
    }
}
