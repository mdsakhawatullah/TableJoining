namespace InternshipTask.Models
{
    public class NotifyService
    {
        public static string Success(string message)
        {
            return $"$.notify(\"{message}\", \"success\");";
        }

        public static string Info(string message)
        {
            return $"$.notify(\"{message}\", \"info\");";
        }

        public static string Error(string message)
        {
            return $"$.notify(\"{message}\", \"error\");";
        }
    }
}
