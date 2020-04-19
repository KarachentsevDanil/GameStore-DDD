using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Shared.Utils.Application.CQS.Commands;
using System;

namespace GSP.Game.Application.CQS.Commands.Publishers
{
    public class UpdatePublisherCommand : BaseUpdateItemCommand<GetPublisherDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Uri LogoUri { get; set; }

        public Uri WebPageUri { get; set; }
    }
}