namespace RenterInsuranceApp.Utilities
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }

        public static ApiResponse<T> Success(T data, int statusCode = 200)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = data, Error = null };
        }

        public static ApiResponse<T> Fail(string error, int statusCode = 400)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = default, Error = error };
        }
    }
}
