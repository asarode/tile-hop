using System.Collections.Generic;

public class GridCoord : IEqualityComparer<GridCoord>
{
    public double x;
    public double z;

    public GridCoord(double xIn, double zIn)
    {
        x = xIn;
        z = zIn;
    }

    public bool Equals(GridCoord thisOne, GridCoord thatOne)
    {
        return thisOne.x == thatOne.x && thisOne.z == thatOne.z;
    }

    public int GetHashCode(GridCoord coord)
    {
        return int.Parse("" + x + "0000" + z);
    }
}
