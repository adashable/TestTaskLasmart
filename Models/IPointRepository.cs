namespace TestTaskLasmart.Models
{
    public interface IPointRepository
    {
        List<Point> GetPoints();
        bool RemovePoint(int pointid);
    }
}
