using GSP.Shared.Utils.Application.UseCases.DTOs;
using System;

namespace GSP.Game.Application.UseCases.DTOs.Publishers
{
    public class GetPublisherDto : BaseGetItemDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Uri LogoUri { get; set; }

        public Uri WebPageUri { get; set; }
    }
}