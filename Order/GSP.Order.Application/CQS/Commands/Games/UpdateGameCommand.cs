﻿using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.CQS.Commands;
using System;

namespace GSP.Order.Application.CQS.Commands.Games
{
    public class UpdateGameCommand : BaseUpdateItemCommand<GetGameDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public Uri PhotoUri { get; set; }

        public Uri IconUri { get; set; }
    }
}