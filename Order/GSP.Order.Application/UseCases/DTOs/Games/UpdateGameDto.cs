using GSP.Shared.Utils.Application.UseCases.DTOs;
using System;

namespace GSP.Order.Application.UseCases.DTOs.Games
{
    public class UpdateGameDto : BaseUpdateItemDto
    {
        public UpdateGameDto(long id, string name, string description, float price, Uri photoUri, Uri iconUri)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PhotoUri = photoUri;
            IconUri = iconUri;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public Uri PhotoUri { get; set; }

        public Uri IconUri { get; set; }
    }
}