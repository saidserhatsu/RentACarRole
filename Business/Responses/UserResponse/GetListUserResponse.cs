namespace Business.Responses.UserResponse
{
    public class GetListUserResponse
    {
        public ICollection<UserListItemDto> Items { get; set; }

        public GetListUserResponse()
        {
            Items = Array.Empty<UserListItemDto>();
        }
        public GetListUserResponse(ICollection<UserListItemDto> items)
        {
            Items = items;
        }
    }
}