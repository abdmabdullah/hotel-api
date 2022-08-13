using hotel_api.ApiModels;

namespace hotel_api.Utilities
{
    public class ResponseUtil
    {
        public ResponseModel GenerateResponseObject(Object response, string message, int statusCode)
        {
            return new ResponseModel(response, message, statusCode);
        }
    }
}
