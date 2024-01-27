using TaskManager.Api.Dtos;

namespace TaskManager.Api.ResponseProvider
{
    public interface IResponseProvider
    {
        ResponseDto GenerateGetResponse(Func<object?> query);
        ResponseDto GeneratePostResponse(Action command);
    }
}
