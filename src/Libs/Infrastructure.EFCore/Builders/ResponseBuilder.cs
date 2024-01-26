﻿using Infrastructure.EFCore.DTOs;
using System.Net;

namespace Infrastructure.EFCore.Builders
{
    public class ResponseBuilder<TEntity>
    {
        private Response<TEntity> response = new Response<TEntity>();

        public ResponseBuilder(TEntity data)
        {
            response.Data = data;
        }

        public ResponseBuilder()
        {
            response.Data = default(TEntity);
        }

        public ResponseBuilder<TEntity> WithStatusCode(int code)
        {
            response.StatusCode = code;
            return this;
        }

        public ResponseBuilder<TEntity> WithMessage(string message)
        {
            response.Message = message;
            return this;
        }

        public ResponseBuilder<TEntity> WithError()
        {
            response.IsError = true;
            return this;
        }
        public ResponseBuilder<TEntity> With500(string message = "The Server Encountered!")
        {
            response.Message = message;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.IsError = true;
            return this;
        }

        public ResponseBuilder<TEntity> With404(string message =  $"{nameof(TEntity)} Not Found!")
        {
            response.Message = message;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.IsError = true;
            return this;
        }

        public ResponseBuilder<TEntity> With201()
        {
            response.Message = "Created!";
            response.StatusCode = (int)HttpStatusCode.Created;
            response.IsError = false;
            return this;
        }

        public ResponseBuilder<TEntity> With200()
        {
            response.Message = "Successfully!";
            response.StatusCode = (int)HttpStatusCode.OK;
            response.IsError = false;
            return this;
        }

        public Response<TEntity> Build()
        {
            return response;
        }
    }
}
