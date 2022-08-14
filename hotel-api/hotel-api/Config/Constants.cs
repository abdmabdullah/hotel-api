namespace hotel_api.Config
{
    public static class Constants
    {
        public static readonly string SUCCESS_MESSAGE = "OK";
        public static readonly int SUCCESS_CODE = 200;

        public static readonly string NOT_FOUND_MESSAGE = "Not Found";
        public static readonly int NOT_FOUND_CODE = 404;

        public static readonly string CREATED_MESSAGE = "Created";
        public static readonly int CREATED_CODE = 201;

        public static readonly string FAILURE_MESSAGE = "An error occurred. Please try again later";
        public static readonly int FAILURE_CODE = 999;

        public static readonly string INVALID_HOTEL_ID_MESSAGE = "The selected Hotel Id is invalid";
        public static readonly int INVALID_HOTEL_ID_CODE = 422;

        public static readonly string INVALID_USER_MESSAGE = "The selected user is invalid";
        public static readonly int INVALID_USER_CODE = 422;

        public static readonly string HOTEL_NOT_AVAILABLE_MESSAGE = "This hotel is not available for booking in this date range";
        public static readonly int HOTEL_NOT_AVAILABLE_CODE = 422;

        public static readonly string INVALID_FILTER_ID_MESSAGE = "Invalid Filter Id";
        public static readonly int INVALID_FILTER_ID_CODE = 422;
    }
}
