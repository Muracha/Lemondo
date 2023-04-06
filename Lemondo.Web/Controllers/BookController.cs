namespace Lemondo.Web.Controllers;

public class BookController : Controller
{
    private readonly IConfigurationRoot _configuration;

    public BookController(IConfigurationRoot configurationRoot)
    {
        _configuration = configurationRoot;
    }

    public async Task<ActionResult> Index()
    {
        using (var client = new HttpClient())
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            var response = await client.GetAsync("api/Book");
            var result = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookModel>>(result, options);

            return View(books);
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

            var response = await client.GetAsync($"api/Book/get/{id}");
            var result = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<BookModel>(result, options);

            return View(books);
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

            var response = await client.GetAsync($"api/Book/search/{searchTerm}");
            var result = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookModel>>(result, options);

            return View(books);
        }
    }

    public async Task<ActionResult> Update(BookModel model)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.PutAsJsonAsync($"api/Book", model);

            return RedirectToAction("Details", "Book", new { id = model.Id });
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.DeleteAsync($"api/Book/delete/{id}");

            return RedirectToAction("Index", "Book");
        }
    }

    public async Task<ActionResult> Create(BookModel model)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.PostAsJsonAsync($"api/Book", model);

            return RedirectToAction("Index", "Book");
        }
    }

    public async Task<ActionResult> AddAuthor(int bookId, int authorId)
    {
        using (var client = new HttpClient())
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("bookId", bookId.ToString()),
                new KeyValuePair<string, string>("authorId", authorId.ToString())
            });
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.PostAsync($"api/Book/addauthor/{bookId}/{authorId}", content);

            return RedirectToAction("Details", "Book", new { id = bookId });
        }
    }

    public async Task<ActionResult> DeleteAuthor(int bookId, int authorId)
    {
        using (var client = new HttpClient())
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("bookId", bookId.ToString()),
                new KeyValuePair<string, string>("authorId", authorId.ToString())
            });
            client.BaseAddress = new Uri(_configuration.GetValue<string>("AppSettings:BaseUrl"));

            await client.PostAsync($"api/Book/deleteauthor/{bookId}/{authorId}", content);

            return RedirectToAction("Details", "Book", new { id = bookId });
        }
    }

    public async Task<IActionResult> CreateView()
    {
        return View();
    }
}
