using AutoMapper;
using WebAPIPhong.Dtos;
using WebAPIPhong.Models;

namespace WebAPIPhong
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // book and upsertBookDtos
                config.CreateMap<UpsertBookDtos, Book>().ReverseMap();
                
                // category and upsertCategoryDtos
                config.CreateMap<UpsertCategoryDtos, Category>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}