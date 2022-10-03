using AutoMapper;
using WebAPIPhong.Dtos;
using WebAPIPhong.Dtos.UserDtos;
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
                
                // user 
                config.CreateMap<UpdateRequest, User>()
                    .ForAllMembers(x=>x.Condition(
                        (src, dest, prop) =>
                        {
                            if (prop == null) return false;
                            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                            
                            return true;
                        }));
            });
            return mappingConfig;
        }
    }
}