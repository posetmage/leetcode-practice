// 630. Course Schedule III
public class Solution
{
    public int ScheduleCourse(int[][] courses)
    {
        Array.Sort(courses, Comparer<int[]>.Create((left, right) => left[1] - right[1]));
        PriorityQueue<int, int> priorityQueue = new();

        int time = 0;
        foreach (int[] course in courses)
        {
            (int duration, int lastDay) = (course[0], course[1]);
            time += duration;
            priorityQueue.Enqueue(duration, -duration);
            if (time > lastDay)
            {
                time -= priorityQueue.Dequeue();
            }
        }

        return priorityQueue.Count;
    }
}
