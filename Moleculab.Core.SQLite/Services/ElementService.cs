using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.DAL.SQLite.Context;

namespace Moleculab.Core.SQLite.Services
{
	public class ElementService : IElementService
	{
		private readonly MoleculabDbContext _moleculabDbContext;
		private readonly IMapper _mapper;

		public ElementService(MoleculabDbContext moleculabDbContext, IMapper mapper)
		{
			_moleculabDbContext = moleculabDbContext;
			_mapper = mapper;
		}

		public async Task<DeleteDto> DeleteById(Guid id)
		{
			var model = await _moleculabDbContext.Elements
				.FirstOrDefaultAsync(x => x.Id == id.ToString());

			var dto = new DeleteDto();

			if (model == null)
			{
				dto.Id = id;
				dto.IsDeleted = false;
				return dto;
			}

			_moleculabDbContext.Elements.Remove(model);
			await _moleculabDbContext.SaveChangesAsync();

			dto.Id = id;
			dto.IsDeleted = true;

			return dto;
		}

		public async Task<List<ElementDto>> GetAll()
		{
			var model = await _moleculabDbContext.Elements
				.ToListAsync();

			return _mapper.Map<List<ElementDto>>(model);
		}

		public async Task<ElementDto> GetByAtomicMassAsync(int atomicMass)
		{
			var model = await _moleculabDbContext.Elements
				.FirstOrDefaultAsync(x => (int)Math.Round(x.AtomicMass) == atomicMass);

			return _mapper.Map<ElementDto>(model);
		}

		public async Task<ElementDto> GetById(Guid id)
		{
			var model = await _moleculabDbContext.Elements
				.FirstOrDefaultAsync(x => x.Id == id.ToString());

			return _mapper.Map<ElementDto>(model);
		}

		public async Task<ElementDto> GetByShortNameAsync(Element shortName)
		{
			var model = await _moleculabDbContext.Elements
				.FirstOrDefaultAsync(x => x.ShortName == shortName.ToString());

			return _mapper.Map<ElementDto>(model);
		}

		public async Task<ElementDto> UpdateOrInsert(ElementDto obj)
		{
			var model = _mapper.Map<DAL.SQLite.Models.Element>(obj);

			if (model.Id == string.Empty || model.Id == " " || model.Id == null)
			{
				model.Id = Guid.NewGuid().ToString();
			}

			var existingModel = await _moleculabDbContext.Elements
				.AsNoTracking()
				.FirstAsync(x => x.Id == model.Id);

			if (existingModel == null)
			{
				_moleculabDbContext.Elements.Add(model);
			}
			else
			{
				_moleculabDbContext.Elements.Update(model);
			}

			await _moleculabDbContext.SaveChangesAsync();

			return _mapper.Map<ElementDto>(model);
		}
	}
}
