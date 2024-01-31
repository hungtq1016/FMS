﻿using Infrastructure.Main.Enums;

namespace Infrastructure.EFCore.DTOs
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StatusMessageEnum Status { get; set; }

        public PaginationRequest()
        {
            PageNumber = 1;
            PageSize = 10;
            Status = StatusMessageEnum.All;
        }

        public PaginationRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 100 ? 100 : pageSize;
        }
    }
}
