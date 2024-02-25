using Business.Dtos.Customer;

namespace Business.Responses.CustomerResponse
{
    public class GetListCustomerResponse
    {
        public ICollection<CustomerListItemDto> Items { get; set; }

        public GetListCustomerResponse()
        {
            Items = Array.Empty<CustomerListItemDto>();
        }
        public GetListCustomerResponse(ICollection<CustomerListItemDto> items)
        {
            Items = items;
        }
    }
}