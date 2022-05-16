namespace Policy.API
{
    public class ApiResponse
    {
        public dynamic Data { get; set; }
        public ApiResponseMetaData MetaData { get; set; }
    }

    public class ApiResponseMetaData
    {
        public string Staus { get; set; }
        public string StausCode { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponseConstants
    {
        public const string SuccessStatus = "success";
        public const string ErrorStatus = "Error";
        public const string SuccessStatusCode = "200";
        public const string ErrorStatusCode = "500";
        public const string NotFoundStatusCode = "404";
    }
}
