
namespace Business.Responses.IndividualCustomerResponse
{
    public class GetListIndividualCustomerResponse
    {
        public ICollection<IndividualCustomerListItemDto> Items { get; set; }

        public GetListIndividualCustomerResponse()
        {
            Items = Array.Empty<IndividualCustomerListItemDto>();
        }
        public GetListIndividualCustomerResponse(ICollection<IndividualCustomerListItemDto> items)
        {
            Items = items;
        }
    }
}