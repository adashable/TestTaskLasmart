namespace TestTaskLasmart.Models
{
    public class Point
    {
        public int PointID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int R { get; set; }
        public string Color { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
