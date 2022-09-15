// 1354. Construct Target Array With Multiple Sums

public class Solution
{
    public bool IsPossible(int[] target)
    {
        var queue = new PriorityQueue<int, int>();
        target.ToList().ForEach(x => queue.Enqueue(x, -x));
        int sum = queue.UnorderedItems.Aggregate(0, (x, y) => x + y.Element);

        bool success = true;
        while (success)
        {
            var x = queue.Dequeue();
            int local_sum = sum - x;
            if (x > local_sum && local_sum > 0)
            {
                int a = x / local_sum;
                a -= (x % local_sum) == 0 ? 1: 0;
                x -= a * local_sum;
                sum -= a * local_sum;
            }
            else
            {
                success = false;
            }
            queue.Enqueue(x, -x);
        }

        bool verify = queue.UnorderedItems.Where(x => x.Element == 1).Count() == queue.Count;
        return verify;
    }
}
