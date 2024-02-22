using Infrastructure.EFCore.DTOs;
using Infrastructure.EFCore.Service;
using Infrastructure.Main.Enums;

namespace Infrastructure.EFCore.Helpers
{
    public class PaginationHelper<TEntity>
    {
        public static PaginationResponse<List<TEntity>> GeneratePaginationResponse(List<TEntity> data, PaginationRequest request, IUriService util, string route)
        {
            int totalRecords = data.Count();
            int totalPages = totalRecords / request.PageSize;

            var response = new PaginationResponse<List<TEntity>>(data, request.PageNumber, request.PageSize);

            if (request.Status != StatusEnum.All)
            {
                response.PreviousPage = (request.PageNumber > 1)
                    ? util.GetPageUri(new PaginationRequest(request.PageNumber - 1, request.PageSize, request.Status), route)
                    : null;

                response.NextPage = (request.PageNumber < totalPages)
                    ? util.GetPageUri(new PaginationRequest(request.PageNumber + 1, request.PageSize, request.Status), route)
                    : null;
            }
            else
            {
                response.PreviousPage = (request.PageNumber > 1)
                    ? util.GetPageUri(new PaginationRequest(request.PageNumber - 1, request.PageSize), route)
                    : null;

                response.NextPage = (request.PageNumber < totalPages)
                    ? util.GetPageUri(new PaginationRequest(request.PageNumber + 1, request.PageSize), route)
                    : null;
            }

            response.FirstPage = (request.Status != StatusEnum.All)
                ? util.GetPageUri(new PaginationRequest(1, request.PageSize, request.Status), route)
                : util.GetPageUri(new PaginationRequest(1, request.PageSize), route);

            response.LastPage = (request.Status != StatusEnum.All)
                ? util.GetPageUri(new PaginationRequest(totalPages, request.PageSize, request.Status), route)
                : util.GetPageUri(new PaginationRequest(totalPages, request.PageSize), route);

            response.TotalPages = totalPages;
            response.TotalRecords = totalRecords;

            return response;
        }
    }
}
