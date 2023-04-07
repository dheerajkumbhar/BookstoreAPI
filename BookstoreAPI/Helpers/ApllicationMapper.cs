using AutoMapper;
using BookstoreAPI.Models;
using BookstoreAPI.Data;

namespace BookstoreAPI.Helpers
{
    public class ApllicationMapper:Profile
    {
        public ApllicationMapper()
        {
            CreateMap<Book, Book>().ReverseMap();
        }
    }
}

