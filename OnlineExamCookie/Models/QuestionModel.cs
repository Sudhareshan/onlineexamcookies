namespace OnlineExamCookie.Models
{
    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public List<string>? Options { get; set; }
        public string? SeletedOption { get; set; }

        public string CorrectOptions { get; set; }
    }
}
