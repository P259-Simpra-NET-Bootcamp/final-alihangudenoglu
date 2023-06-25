using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IResult Add(CategoryDto categoryDto);
        public IResult Update(CategoryDto categoryDto);
        public IResult Delete(int id);
        public IDataResult<CategoryDto> GetById(int id);
        public IDataResult<List<CategoryDto>> GetAll();
    }
}
