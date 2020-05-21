using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts.Types
{
    public interface INumberFilter
    {
        NumberFilterOption? NumberFilterOption { get; set; }

        string FirstOperand { get; set; }

        string SecondOperand { get; set; }
    }
}