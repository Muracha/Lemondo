namespace Lemondo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthorService _service;

    public AuthorController(IMapper mapper, IAuthorService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var authors = await _service.Set().ToListAsync();
        var result = _mapper.Map<List<Author>, List<AuthorModel>>(authors);

        return Ok(result);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var author = _service.Get(id);
        var result = _mapper.Map<AuthorModel>(author);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create(AuthorModel authorModel)
    {
        var model = _mapper.Map<Author>(authorModel);
        await _service.InsertAsync(model);
        var updatedRows = await _service.SaveChangesAsync();

        if (updatedRows == 0)
        {
            return BadRequest();
        }

        return Ok(new { model.Id });
    }

    [HttpPut]
    public async Task<ActionResult> Update(AuthorModel authorModel)
    {
        _service.Update(_mapper.Map<Author>(authorModel));
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
        var authors = await _service.SearchByName(searchTerm).ToListAsync();
        var result = _mapper.Map<List<Author>, List<AuthorModel>>(authors);

        return Ok(result);
    }
}
