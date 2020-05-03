namespace GSP.Order.Application.UseCases.DTOs.Orders
{
    public class CompleteOrderDto
    {
        public CompleteOrderDto(long accountId)
        {
            AccountId = accountId;
        }

        public long AccountId { get; set; }
    }
}