// 2320. Count Number of Ways to Place Houses

public class Solution
{
    public const int MOD = 1000000007;
    public int[,] MultiplyMatrix(int[,] A, int[,] B)
    {
        var rA = A.GetLength(0);
        var cA = A.GetLength(1);
        var rB = B.GetLength(0);
        var cB = B.GetLength(1);
        long temp = new int { };
        var kHasil = new int[rA, cB];
        if (cA != rB)
        {
            Console.WriteLine("matrik can't be multiplied !!");
        }
        else
        {
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    temp = 0;
                    for (int k = 0; k < cA; k++)
                    {
                        temp += (long)(A[i, k]) * (long)(B[k, j]);
                        temp = temp % MOD;
                    }
                    kHasil[i, j] = (int)temp;
                }
            }
        }
        return kHasil;

    }
    public int[,] FastPower(int[,] X, int n)
    {
        var r = X.GetLength(0);
        var Y = new int[r, r];
        for (int i = 0; i < r; i++)
        {
            Y[i, i] = 1;
        }
        if (n == 0)
        {
            return Y;
        }

        while (n > 1)
        {
            if (n % 2 > 0)
            {
                Y = MultiplyMatrix(X, Y);
            }
                        
            X = MultiplyMatrix(X, X);
            n /= 2;
        }    

        return MultiplyMatrix(X, Y);
    }



    public int CountHousePlacements(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        int[,] m = {
            { 1, 1 , 1 , 1},
            { 1, 1 , 0 , 0},
            { 1, 0 , 1 , 0},
            { 1, 0 , 0 , 0}
        };


        int[,] init = {
            { 1 },
            { 1 },
            { 1 },
            { 1 }
        };
            
        init = MultiplyMatrix(FastPower(m, n - 1), init);


        int sum = 0;
        foreach (int i in init)
        {
            sum += i;
            sum = sum % MOD;
        }

        return sum;
    }
}
