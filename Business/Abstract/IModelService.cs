using Business.Requests.ModelRequest;
using Business.Responses.ModelResponse;

namespace Business.Abstract
{
    public interface IModelService
    {
        public AddModelResponse Add(AddModelRequest addModelRequest);
        public GetListModelResponse GetList(GetListModelRequest getListModelRequest);
        public GetByIdModelResponse GetById(GetByIdModelRequest getByIdModelRequest);
        public UpdateModelResponse Update(UpdateModelRequest modelRequest);
        public DeleteModelResponse Delete(DeleteModelRequest deleteModelRequest,bool isSoftDelete = true);
    }
}
