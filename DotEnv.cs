namespace ocian_net
{
    public class DotEnv
    {
        public string SERVER { get; set; }
        public string PORT { get; set; }
        public string DATABASE_NAME { get; set; }
        public string DB_USER { get; set; }
        public string DB_PASSWORD { get; set; }


        public string HOST { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        

        public DotEnv()
        {   
            
            DotNetEnv.Env.Load();

            SERVER = Environment.GetEnvironmentVariable("SERVER")!;
            PORT = Environment.GetEnvironmentVariable("PORT")!;
            DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME")!;
            DB_USER = Environment.GetEnvironmentVariable("DB_USER")!;
            DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
            
            HOST = Environment.GetEnvironmentVariable("HOST")!;
            USERNAME = Environment.GetEnvironmentVariable("USERNAME")!;
            PASSWORD = Environment.GetEnvironmentVariable("PASSWORD")!;
            EMAIL = Environment.GetEnvironmentVariable("EMAIL")!;
            
        }
    }
}