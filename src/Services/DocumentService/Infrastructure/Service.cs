using AutoMapper;
using DocumentService.Models;
using DocumentService.Models.DTOs;
using DocumentService.Models.Enums;
using Infrastructure.EFCore.DTOs;
using Infrastructure.EFCore.Helpers;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.Service;

namespace DocumentService.Infrastructure
{
    public interface IDocumentService : IFileService<Document, DocumentRequest, DocumentResponse, DocumentExtensionsEnum>
    {
        Task<Response<List<DocumentResponse>>> AddWithFlightId(Guid flightId, List<IFormFile> files);
    }

    public class CDocumentService : FileService<Document, DocumentRequest, DocumentResponse, DocumentExtensionsEnum>, IDocumentService
    {
        private readonly IRepository<Document> _repository;
        private readonly IMapper _mapper;
        public CDocumentService(IRepository<Document> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<DocumentResponse>>> AddWithFlightId(Guid flightId, List<IFormFile> files)
        {
            var records = await FileHelper.WriteFile<DocumentExtensionsEnum>(files, typeof(Document).Name);

            List<Document> entities = new List<Document>();

            foreach (var record in records)
            {
                if (record is not null)
                {
                    var entity = _mapper.Map<Document>(record);
                    entity.FlightId = flightId;
                    var result = await _repository.AddAsync(entity);
                    entities.Add(result);
                }
            }

            var response = _mapper.Map<List<DocumentResponse>>(entities);

            return ResponseHelper.CreateCreatedResponse(response);
        }
    }
}
