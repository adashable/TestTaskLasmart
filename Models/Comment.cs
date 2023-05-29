using System.Text.Json.Serialization;

namespace TestTaskLasmart.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public string BackgroundColor { get; set; }
        public int PointID { get; set; }
        [JsonIgnore]
        public Point Point { get; set; }
    }
}
