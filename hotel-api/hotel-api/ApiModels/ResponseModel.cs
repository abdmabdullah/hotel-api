namespace hotel_api.ApiModels
{
    public class ResponseModel
    {
        private Object _response;
        private string _message;
        private int _statusCode;

        public Object Response { get { return _response; } set { _response = value; } }
        public string Message { get { return _message; } set { _message = value; } }
        public int StatusCode { get { return _statusCode; } set { _statusCode = value; } }

        public ResponseModel(Object response, string message, int statusCode)
        {
            _response = response;
            _message = message;
            _statusCode = statusCode;
        }
    }
}
