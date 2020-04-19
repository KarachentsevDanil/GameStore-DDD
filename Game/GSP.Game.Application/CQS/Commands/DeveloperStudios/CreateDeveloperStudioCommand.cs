using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Shared.Utils.Application.CQS.Commands;
using System;

namespace GSP.Game.Application.CQS.Commands.DeveloperStudios
{
    public class CreateDeveloperStudioCommand : BaseCreateItemCommand<GetDeveloperStudioDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Uri LogoUri { get; set; }

        public Uri WebPageUri { get; set; }
    }
}