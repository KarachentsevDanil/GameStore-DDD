using GSP.Shared.Grid.Models;
using System;

namespace GSP.Shared.Grid.Stores.Contracts
{
    public interface IGridTypeStore
    {
        GridTypeModel GetGridTypeModel(Type type);
    }
}