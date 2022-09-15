// 1710. Maximum Units on a Truck

public class Solution
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
        int sum = 0;
        foreach (var box in boxTypes)
        {
            if (truckSize > box[0])
            {
                truckSize -= box[0];
                sum += box[0] * box[1];
            }
            else             
            {
                sum += truckSize * box[1];
                return sum;
            }
        }
        return sum;
    }
}
