namespace SharedResault
{
    public class Result
    {
        public bool IsSuccess { get; init; }
        public string Error { get; init; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new Result { IsSuccess = true };
        public static Result Failure(string error) => new Result { IsSuccess = false, Error = error };
    }

}
