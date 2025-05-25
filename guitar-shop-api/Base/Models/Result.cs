namespace guitar_shop_api.Base.Models
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        private Result(string message, T data)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        private Result(string message)
        {
            Success = false;
            Message = message;
            Data = default!;
        }
        public static Result<T> Ok(string message, T data)
            => new Result<T>(message, data);

        public static Result<T> Ok(string message)
            => new Result<T>(message, default!);

        public static Result<T> Fail(string message)
            => new Result<T>(message);

    }
}
