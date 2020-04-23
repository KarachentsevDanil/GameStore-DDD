using GSP.Shared.Utils.Application.UseCases.DTOs;
using System;

namespace GSP.Order.Application.UseCases.DTOs.Games
{
    public class AddGameDto : BaseAddItemDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public Uri PhotoUri { get; set; }

        public Uri IconUri { get; set; }
    }
}