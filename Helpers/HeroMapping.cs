using AutoMapper;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Helpers
{
    public class HeroMapping : Profile
    {
        public HeroMapping()
        {
            CreateMap<HeroesContext, Hero>();
        }
    }
}
