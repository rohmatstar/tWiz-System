using Client.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Client.Contracts
{
    public interface IRepository<T, X>
        where T : class
    {
        Task<ResponseListDto<T>> Get();
        Task<ResponseDto<T>> Get(X id);
        Task<ResponseMessageDto> Post(T entity);
        Task<ResponseMessageDto> Put(T entity);
        Task<ResponseMessageDto> Delete(X id);
    }
}