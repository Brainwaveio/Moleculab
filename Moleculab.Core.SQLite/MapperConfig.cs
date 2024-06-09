using AutoMapper;
using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Core.SQLite;

public static class MapperConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var configuration = new MapperConfiguration(config =>
		{
			config.CreateMap<DAL.SQLite.Models.Element, ElementDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id != null ? Guid.Parse(src.Id) : (Guid?)null))
				.ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => Enum.Parse<Element>(src.ShortName)))
				.ForMember(dest => dest.StandardState, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.StandardState) ? Enum.Parse<ElemntState>(src.StandardState, true) : (ElemntState?)null))
				.ReverseMap()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
				.ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName.ToString()))
				.ForMember(dest => dest.StandardState, opt => opt.MapFrom(src => src.StandardState.HasValue ? src.StandardState.Value.ToString() : null));
		});

		configuration.AssertConfigurationIsValid();

		return configuration;
	}
}
