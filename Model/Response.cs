namespace ApiNewBook.Model
{
    public class Response<T>
    {
        public T? Data { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }

        public UserResponse? Values { get; set; }
    }
}
