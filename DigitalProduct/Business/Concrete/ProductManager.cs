using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;

        }

        public IResult Add(ProductDto productDto)
        {
            var entity = _mapper.Map<ProductDto, Product>(productDto);
             
            List<CategoryProduct> list= new List<CategoryProduct>();
            foreach (var item in productDto.CategoryProducts)
            {
                
                list.Add(new CategoryProduct { CategoryId=item.CategoryId,ProductId=entity.Id});
            }
            entity.CategoryProducts=list;
            _productDal.Insert(entity);
            _productDal.Complete();
            
            return new SuccessResult();
        }

        public IResult Update(ProductDto productDto)
        {
            var entity = _mapper.Map<ProductDto, Product>(productDto);
            _productDal.Update(entity);
            _productDal.Complete();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var entity = _productDal.GetById(id);
            entity.Status = false;
            _productDal.Update(entity);
            _productDal.Complete();
            return new SuccessResult();
        }

        public IDataResult<ProductDto> GetById(int id)
        {
            var entity = _productDal.GetById(id);

            var result = _mapper.Map<Product, ProductDto>(entity);
            return new SuccessDataResult<ProductDto>(result);
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            var entity = _productDal.GetAll();
            var result=_mapper.Map<List<Product>,List<ProductDto>>(entity);
            
            return new SuccessDataResult<List<ProductDto>>(result);
        }
    }
}
