namespace Lemondo.API.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Author, AuthorModel>().ReverseMap();
        CreateMap<Book, BookModel>().ReverseMap();
    }
}
