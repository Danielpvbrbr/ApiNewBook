﻿using ApiNewBook.Model;
using AutoMapper;

namespace ApiNewBook.DTOs.Mappings;

public class DTOsMapping : Profile
{
    public DTOsMapping()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<Book, BookDTOCreate>().ReverseMap();
        CreateMap<Language, LanguageDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Favorite, FavoriteDTO>().ReverseMap();
    }
}
