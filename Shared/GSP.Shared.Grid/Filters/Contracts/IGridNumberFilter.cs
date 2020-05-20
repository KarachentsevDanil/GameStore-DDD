using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridNumberFilter
    {
        NumberFilterOption? NumberFilterOption { get; set; }

        string FirstOperand { get; set; }

        string SecondOperand { get; set; }
    }
}