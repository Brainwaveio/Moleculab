using AutoMapper;
using QuantumQuery.Core.SQLite.DTOs;
using QuantumQuery.DAL.SQLite.Models;

namespace QuantumQuery.Core.SQLite
{
	public static class MapperConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var configuration = new MapperConfiguration(config =>
			{
				config.CreateMap<Element, ElementDto>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id != null ? Guid.Parse(src.Id) : (Guid?)null))
					.ForMember(dest => dest.CPKHexColor, opt => opt.MapFrom(src => src.CpkhexColor))
					.ReverseMap()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
			});

			configuration.AssertConfigurationIsValid();

			return configuration;
		}		
	}
}
