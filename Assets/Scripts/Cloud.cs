public class Cloud
{
    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }
    public int MinZ { get; private set; }
    public int MaxZ { get; private set; }
    public int MinScale { get; private set; }
    public int MaxScale { get; private set; }
    public int RespawnPoint { get; private set; }

    public Cloud(int minX, int maxX, int minY, int maxY, int minZ, int maxZ, int minScale, int maxScale, int respawnPoint)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
        MinZ = minZ;
        MaxZ = maxZ;
        MinScale = minScale;
        MaxScale = maxScale;
        RespawnPoint = respawnPoint;
    }
}
