using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.DAL.SQLite.Context;

namespace Moleculab.Core.SQLite.Services;

public class ElementService : IElementService
{
	private readonly MoleculabDbContext moleculabDbContext;
	private readonly IMapper mapper;

	public ElementService(MoleculabDbContext moleculabDbContext, IMapper mapper)
	{
		this.moleculabDbContext = moleculabDbContext;
		this.mapper = mapper;
	}

	public async Task<DeleteDto> DeleteById(Guid id)
	{
		var model = await moleculabDbContext.Elements
			.FirstOrDefaultAsync(x => x.Id == id.ToString());

		var dto = new DeleteDto();

		if (model == null)
		{
			dto.Id = id;
			dto.IsDeleted = false;
			return dto;
		}

		moleculabDbContext.Elements.Remove(model);
		await moleculabDbContext.SaveChangesAsync();

		dto.Id = id;
		dto.IsDeleted = true;

		return dto;
	}

	public async Task<List<ElementDto>> GetAll()
	{
		var model = await moleculabDbContext.Elements
			.ToListAsync();

		return mapper.Map<List<ElementDto>>(model);
	}

	public async Task<ElementDto> GetByAtomicMassAsync(int atomicMass)
	{
		var model = await moleculabDbContext.Elements
			.FirstOrDefaultAsync(x => (int)Math.Round(x.AtomicMass) == atomicMass);

		return mapper.Map<ElementDto>(model);
	}

	public async Task<ElementDto> GetById(Guid id)
	{
		var model = await moleculabDbContext.Elements
			.FirstOrDefaultAsync(x => x.Id == id.ToString());

		return mapper.Map<ElementDto>(model);
	}

	public async Task<ElementDto> GetByShortNameAsync(Element shortName)
	{
		var model = await moleculabDbContext.Elements
			.FirstOrDefaultAsync(x => x.ShortName == shortName.ToString());

		return mapper.Map<ElementDto>(model);
	}

	public async Task<ElementDto> UpdateOrInsert(ElementDto obj)
	{
		var model = mapper.Map<DAL.SQLite.Models.Element>(obj);

		if (model.Id == string.Empty || model.Id == " " || model.Id == null)
		{
			model.Id = Guid.NewGuid().ToString();
		}

		var existingModel = await moleculabDbContext.Elements
			.AsNoTracking()
			.FirstAsync(x => x.Id == model.Id);

		if (existingModel == null)
		{
			moleculabDbContext.Elements.Add(model);
		}
		else
		{
			moleculabDbContext.Elements.Update(model);
		}

		await moleculabDbContext.SaveChangesAsync();

		return mapper.Map<ElementDto>(model);
	}
}
