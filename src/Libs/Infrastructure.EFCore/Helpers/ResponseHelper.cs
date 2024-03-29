﻿using Infrastructure.EFCore.Builders;
using Infrastructure.EFCore.DTOs;

namespace Infrastructure.EFCore.Helpers
{
    public class ResponseHelper
    {
        public static Response<TEntity> CreateSuccessResponse<TEntity>(TEntity data)
        {
            return new ResponseBuilder<TEntity>(data).With200().Build();
        }

        public static Response<TEntity> CreateCreatedResponse<TEntity>(TEntity data)
        {
            return new ResponseBuilder<TEntity>(data).With201().Build();
        }

        public static Response<TEntity> CreateNotFoundResponse<TEntity>(string message)
        {
            return new ResponseBuilder<TEntity>().With404(message).Build();
        }

        public static Response<TEntity> CreateErrorResponse<TEntity>(string message)
        {
            return new ResponseBuilder<TEntity>().With500(message).Build();
        }
    }
}
