using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Shared.DTOs;

namespace Shared.Common
{
    public interface IUriUtil
    {
        Uri GetPageUri(PaginationRequest request, string route);
    }

    public class UriUtil : IUriUtil
    {
        private readonly string _uri;

        public UriUtil(IServiceProvider serviceProvider)
        {
            var accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext.Request;
            _uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        }

        public Uri GetPageUri(PaginationRequest request, string route)
        {
            Uri endpoint = new Uri(string.Concat(_uri,route));
            string uriUpdated = QueryHelpers.AddQueryString(endpoint.ToString(), "pageNumber", request.PageNumber.ToString());
            uriUpdated = QueryHelpers.AddQueryString(uriUpdated, "pageSize", request.PageSize.ToString());
            uriUpdated = QueryHelpers.AddQueryString(uriUpdated, "status", request.Status.ToString());

            return new Uri(uriUpdated);
        }
    }
}
