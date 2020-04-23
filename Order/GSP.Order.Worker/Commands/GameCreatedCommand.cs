using AzureFromTheTrenches.Commanding.Abstractions;
using System;

namespace GSP.Order.Worker.Commands
{
    public class GameCreatedCommand : ICommand
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public Uri PhotoUri { get; set; }

        public Uri IconUri { get; set; }
    }
}