using TaskManager.Api.Dtos;

namespace TaskManager.Api.ResponseProvider
{
    public class ResponseProvider : IResponseProvider
    {
        public ResponseDto GenerateGetResponse(Func<object?> query)
        {
            ResponseDto responseDto = new();
            try
            {
                responseDto.Result = query();
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        public ResponseDto GeneratePostResponse(Action command)
        {
            ResponseDto responseDto = new();
            try
            {
                command();
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }
    }
}
