namespace CorePayAPI.Service
{
    public class ApiResponse<Tentity> 
        where Tentity : class
    {
        public int statusCode { get; set; }
        public bool isSucess { get; set; }
        public string? message { get; set; }
        public Tentity? data { get; set; }

        public void Fail(int code, string msg)
        {
            statusCode = code;
            message = msg;
            isSucess = false;
        }

        public void Sucess(Tentity dt)
        {
            statusCode = 200;
            message = "OK";
            data = dt;
            isSucess = true; 
        }
    }
}
