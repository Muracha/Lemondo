namespace Lemondo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBookService _service;
    private readonly IAuthorService _authorService;

    public BookController(IMapper mapper, IBookService bookService, IAuthorService authorService)
    {
        _mapper = mapper;
        _service = bookService;
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var books = await _service.Set().ToListAsync();
        var result = _mapper.Map<List<Book>, List<BookModel>>(books);

        return Ok(result);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var book = _service.Get(id);
        var result = _mapper.Map<BookModel>(book);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create(BookModel bookModel)
    {
        var model = _mapper.Map<Book>(bookModel);
        await _service.InsertAsync(model);
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return Ok(new { model.Id });
    }

    [HttpPost("addauthor/{bookId}/{authorId}")]
    public async Task<ActionResult> AddAuthor(int bookId, int authorId)
    {
        var book = _service.Get(bookId);
        var author = _authorService.Get(authorId);
        book.Authors.Add(author);
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPost("deleteauthor/{bookId}/{authorId}")]
    public async Task<ActionResult> DeleteAuthor(int bookId, int authorId)
    {
        var book = _service.Get(bookId);
        var author = _authorService.Get(authorId);
        book.Authors.Remove(author);
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> Update(BookModel bookModel)
    {
        _service.Update(_mapper.Map<Book>(bookModel));
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        _service.Delete(id);
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult> Search(string searchTerm)
    {
        var books = await _service.SearchByTitle(searchTerm).ToListAsync();
        var result = _mapper.Map<List<Book>, List<BookModel>>(books);

        return Ok(result);
    }
}
