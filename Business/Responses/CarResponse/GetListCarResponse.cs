using Business.Dtos.Car;

namespace Business
{
    public class GetListCarResponse
    {
        public ICollection<CarListItemDto> Items { get; set; }

        public GetListCarResponse()
        {
            Items = Array.Empty<CarListItemDto>();
        }
        public GetListCarResponse(ICollection<CarListItemDto> items)
        {
            this.Items = items;
        }
    }
}