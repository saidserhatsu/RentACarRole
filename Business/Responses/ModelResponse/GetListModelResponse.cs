using Business.Dtos.Model;

namespace Business.Responses.ModelResponse
{
    public class GetListModelResponse
    {
        public ICollection<ModelListItemDto> Items { get; set; }

        public GetListModelResponse()
        {
            Items = Array.Empty<ModelListItemDto>();
        }
        public GetListModelResponse(ICollection<ModelListItemDto> items)
        {
            Items = items;
        }
    }
}