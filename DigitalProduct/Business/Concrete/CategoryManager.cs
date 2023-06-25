using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public IResult Add(CategoryDto categoryDto)
        {
            var entity = _mapper.Map<CategoryDto, Category>(categoryDto);
            _categoryDal.Insert(entity);
            _categoryDal.Complete();

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            //var result = _categoryDal.GetByIdWithInclude(id,"CategoryProducts");

            //if (!result.CategoryProducts.Any())
            //{
            //    return new ErrorResult();
            //}
            
            //var entity = _categoryDal.GetById(id);
            _categoryDal.DeleteById(id);
            _categoryDal.Complete();
            return new SuccessResult();
        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            var entity = _categoryDal.GetAll();
            var result = _mapper.Map<List<Category>, List<CategoryDto>>(entity);
            return new SuccessDataResult<List<CategoryDto>>(result);
        }

        public IDataResult<CategoryDto> GetById(int id)
        {
            var entity = _categoryDal.GetById(id);
            var result = _mapper.Map<Category, CategoryDto>(entity);
            return new SuccessDataResult<CategoryDto>(result);
        }

        public IResult Update(CategoryDto categoryDto)
        {
            var entity = _mapper.Map<CategoryDto, Category>(categoryDto);
            _categoryDal.Update(entity);
            _categoryDal.Complete();
            return new SuccessResult();
        }
    }
}
