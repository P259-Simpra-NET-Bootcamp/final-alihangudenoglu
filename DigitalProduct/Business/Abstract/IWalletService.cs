using Core.Utilities.Results;
using Entities.DTOs.Discount;
using Entities.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWalletService
    {
        public IResult Add(int userId);
        public Task<IDataResult<WalletDto>> GetBalance(ClaimsPrincipal claimsPrincipal);
        public IResult AddBalance(int userId,decimal balance);
        public IResult ReduceBalance(int userId, decimal balance);
        public IDataResult<WalletDto> GetByUserId(int userId);
    }
}
