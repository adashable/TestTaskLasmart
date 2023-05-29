namespace TestTaskLasmart.Models
{
    public class PointRepository : IPointRepository
    {
        ApplicationContext _context;
        public PointRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<Point> GetPoints()
        {
            var points = _context.Points.ToList();
            foreach (var point in points)
            {
                point.Comments = GetCommentsByPointID(point.PointID);
            }
            return points;
        }

        private List<Comment> GetCommentsByPointID(int pointid)
        {
            return _context.Comments.Where(i => i.PointID == pointid).ToList();
        }

        public bool RemovePoint(int pointid)
        {
            var point = _context.Points.FirstOrDefault(i => i.PointID == pointid);
            if (point != null)
            {
                _context.Points.Remove(point);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
