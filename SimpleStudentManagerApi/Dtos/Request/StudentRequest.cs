namespace SimpleStudentManagerApi.Dtos.Request
{
    public class StudentRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Major { get; set; } = string.Empty;
    }
}
