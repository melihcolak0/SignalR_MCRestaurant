using _81MY_SignalROrderMan.DtoLayer.FeatureDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;

namespace _81MY_SignalROrderManAPI.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
        }
    }
}
