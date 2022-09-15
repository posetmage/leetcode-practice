//307. Range Sum Query - Mutable

public class NumArray
    {
        private class SegTree
        {
            private const int CHUNK_SIZE = 256;

            private class Node
            {
                public readonly int Min;
                public readonly int Max;

                public Node(int min, int max)
                {
                    Min = min;
                    Max = max;
                }

                public Node Left;
                public Node Right;
                public bool IsLeaf => Left == null && Right == null;
                public long Sum;
            }

            private readonly Node _root;

            public SegTree(int min, int max, int[] input)
            {
                _root = new Node(min, max);
                Build(_root, input);
            }

            private void Build(Node node, int[] input)
            {
                int chunk = node.Max - node.Min + 1;
                int chunksCount = Convert.ToInt32(Math.Ceiling((double)chunk / CHUNK_SIZE));

                if (chunksCount <= 1)
                {
                    checked
                    {
                        long sum = 0;

                        for (int i = node.Min; i <= node.Max; i++)
                        {
                            sum += input[i];
                        }

                        node.Sum = sum;
                    }

                    return;
                }

                int leftChunksCount = chunksCount / 2;

                node.Left = new Node(node.Min, node.Min + leftChunksCount * CHUNK_SIZE - 1);
                node.Right = new Node(node.Min + leftChunksCount * CHUNK_SIZE, node.Max);

                Build(node.Left, input);
                Build(node.Right, input);

                node.Sum = node.Left.Sum + node.Right.Sum;
            }

            private void Update(Node node, int i, int diff)
            {
                if (node == null || i < node.Min || i > node.Max)
                {
                    return;
                }

                node.Sum += diff;

                if (!node.IsLeaf)
                {
                    Update(node.Left, i, diff);
                    Update(node.Right, i, diff);
                }
            }

            public void Update(int i, int val)
            {
                Update(_root, i, val);
            }

            private long SumRange(Node node, int from, int to, int[] data)
            {
                if (node == null || from > node.Max || to < node.Min)
                {
                    return 0;
                }

                if (node.Min == from && node.Max == to)
                {
                    return node.Sum;
                }

                if (node.IsLeaf)
                {
                    int start = Math.Max(node.Min, from);
                    int end = Math.Min(node.Max, to);
                    long res = 0;
                    for (int i = start; i <= end; i++)
                    {
                        res += data[i];
                    }

                    return res;
                }

                return SumRange(node.Left, Math.Max(node.Left.Min, from), Math.Min(node.Left.Max, to), data)
                       + SumRange(node.Right, Math.Max(node.Right.Min, from), Math.Min(node.Right.Max, to), data);
            }

            public long SumRange(int from, int to, int[] data)
            {
                return SumRange(_root, from, to, data);
            }
        }

        private readonly SegTree _tree;
        private readonly int[] _raw;

        public NumArray(int[] nums)
        {
            _raw = nums;
            _tree = new SegTree(0, nums.Length - 1, _raw);
        }

        public void Update(int i, int val)
        {
            int diff = val - _raw[i];
            _raw[i] = val;
            _tree.Update(i, diff);
        }

        public int SumRange(int i, int j)
        {
            var res = (int)_tree.SumRange(i,j, _raw);
            return res;
        }
    }
    
    
    
    public class NumArray {
    int[] arr;
    int[] BIT;
    int n;

    public NumArray(int[] nums) {
        arr = nums;
        
        n = nums.Length;
        BIT = new int[n + 1];
        for(int i = 0; i < n; i++)
            init(i, nums[i]);
    }
    
    public void init(int i, int val)
    {
        i++;
        while(i <= n)
        {
            BIT[i] += val;
            i += (i & -i);
        }
    }
    
    public void Update(int i, int val) {
        int diff = val - arr[i];
        arr[i] = val;
        init(i, diff);
    }
    
    private int GetSum(int i)
    {
        int sum = 0;
        i++;
        while(i > 0)
        {
            sum += BIT[i];
            i -= (i & -i);
        }
        return sum;
    }
    
    public int SumRange(int left, int right) {
        return GetSum(right) - GetSum(left - 1);
    }
}
