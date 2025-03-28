using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eventos.Application.Dtos.Category;
using Eventos.Application.Interfaces;
using Eventos.Domain.Entities;
using Eventos.Infra.Data.Repository.Base;
using Eventos.Infra.Data.Repository.Interfaces;

namespace Eventos.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(
            IBaseRepository<Category> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<CategoryDTO> AddCategory(CategoryAddOrEditDTO dto)
        {
            try
            {
                var model = _mapper.Map<Category>(dto);
                var createdModel = _repository.Create(model);
                return Task.FromResult(_mapper.Map<CategoryDTO>(createdModel));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public Task<CategoryDTO> DeleteCategory(int id, CategoryDeleteDTO dto)
        {
            try
            {
                var model = _repository.FindByID(id);
                if (model == null) throw new Exception("Categoria não encontrada.");
                model.UpdatedAt = DateTime.Now;
                _mapper.Map(dto, model);
                var updatedModel = _repository.Update(model);
                return Task.FromResult(_mapper.Map<CategoryDTO>(updatedModel));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public Task<CategoryDTO[]> GetAllCategorys()
        {
            try
            {
                var model = _repository.FindAll();
                return Task.FromResult(_mapper.Map<CategoryDTO[]>(model));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Categorias", ex);
            }
        }

        public Task<CategoryDTO> GetCategoryById(int id)
        {
            try
            {
                var model = _repository.FindByID(id);
                if (model == null) throw new Exception("Categoria não encontrada.");
                return Task.FromResult(_mapper.Map<CategoryDTO>(model));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public Task<CategoryDTO> UpdateCategory(int id, CategoryAddOrEditDTO dto)
        {
            try
            {
                var model = _repository.FindByID(id);
                if (model == null) throw new Exception("Categoria não encontrada.");
                model.UpdatedAt = DateTime.Now;
                _mapper.Map(dto, model);
                var updatedModel= _repository.Update(model);
                return Task.FromResult(_mapper.Map<CategoryDTO>(updatedModel));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
