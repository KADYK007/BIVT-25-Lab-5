using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = int.MaxValue;
                int index = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        index = j;
                    }
                }
                array[i] = index;
            }
            
            // end

            return array;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int mx = int.MinValue;
                int mx_index = -1;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mx_index = j;
                    }
                }

                for (int j = 0; j < mx_index; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        double num = (double)matrix[i, j] / mx;
                        matrix[i, j] = (int)Math.Floor(num);
                    }
                }
            }

            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int mx = int.MinValue;
            int rows = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (rows == col)
            {
                int mx_d = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, i] > mx)
                    {
                        mx = matrix[i, i];
                        mx_d = i;
                    }
                }
                
                if ((k != mx_d) && (k >= 0) && (k < col))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        (matrix[i, mx_d], matrix[i, k]) = (matrix[i, k], matrix[i, mx_d]);
                    }
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int mx = int.MinValue;
            int mx_i = -1;

            if (rows != cols) return;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    mx_i = i;
                }

            }

            for (int i = 0; i < rows; i++)
            {
                (matrix[i, mx_i], matrix[mx_i, i]) = (matrix[mx_i, i], matrix[i, mx_i]);
            }

            // end

        }
        public int[,] Task5(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            
            
            int mx_sm = int.MinValue;
            int sm = 0;
            int i_sm = -1;

            for (int i = 0; i < rows; i++)
            {
                sm = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0)
                        sm += matrix[i, j];
                }

                if (sm > mx_sm)
                {
                    mx_sm = sm;
                    i_sm = i;
                }
            }
            
            int[,] answer = new int[rows-1,col];
            for (int i = 0; i < rows - 1; i++)
            {
                if (i < i_sm)
                {
                    for (int j = 0; j < col; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }

                else
                {
                    for (int j = 0; j < col; j++)
                    {
                        answer[i, j] = matrix[i+1, j];
                    }
                }

            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            
            int k_mx = int.MinValue;
            int i_mx = -1;
            
            int k_mn = int.MaxValue;
            int i_mn = -1;
            

            for (int i = 0; i < rows; i++)
            {
                int k = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] < 0)
                        k++;
                }

                if (k > k_mx)
                {
                    k_mx = k;
                    i_mx = i;
                }


                if (k < k_mn)
                {
                    k_mn = k;
                    i_mn = i;
                }
            }

            if (k_mx != k_mn)
            {
                for (int j = 0; j < col; j++)
                {
                    (matrix[i_mx, j], matrix[i_mn, j]) = (matrix[i_mn, j], matrix[i_mx, j]);
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int mn = int.MaxValue;
            int j_mn = 0;
            

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        j_mn = j;
                    }
                }
            }
            
            if (array == null || array.Length != rows)
            {
                return matrix;
            }
            int[,] answer = new int[rows,cols+1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols + 1; j++)
                {
                    if (j <= j_mn)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == j_mn + 1)
                    {
                        answer[i, j] = array[i];
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int pos = 0;
                int neg = 0;

                int mx = int.MinValue;
                int mx_r = -1;

                for (int i = 0; i < rows; i++)
                {
                    int temp = matrix[i, j];

                    if (temp > 0) 
                        pos++;
                    else if (temp < 0)
                        neg++;
                    

                    if (temp > mx)
                    {
                        mx = temp;
                        mx_r = i;
                    }
                }

                if (pos > neg)
                {
                    matrix[mx_r, j] = 0;
                }
                else if (neg > pos)
                {
                    matrix[mx_r, j] = mx_r;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols) 
                return;
    
            int n = rows;

            for (int k = 0; k < 4 * (n - 1); k++)
            {
                int i, j;

                if (k < n)
                {
                    i = 0;
                    j = k;
                }
                else if (k < 2 * n - 1)
                {
                    i = k - n + 1;
                    j = n - 1;
                }
                else if (k < 3 * n - 2)
                {
                    i = n - 1;
                    j = n - 1 - (k - (2 * n - 2));
                }
                else
                {
                    i = n - 1 - (k - (3 * n - 3));
                    j = 0;
                }

                matrix[i, j] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int rows = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (rows != col)
                return (A, B);

            int up_tr = rows * (rows + 1) / 2;
            int low_tr = rows * (rows - 1) / 2;

            A = new int[up_tr];
            B = new int[low_tr];

            int i_A = 0, i_B = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i <= j)
                    {
                        A[i_A++] = matrix[i, j];
                    }
                    else
                    {
                        B[i_B++] = matrix[i, j];
                    }
                }
            }
            //end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int k = 0; k < rows - i - 1; k++)
                    {
                        if (j % 2 == 0)
                        {
                            if (matrix[k, j] < matrix[k + 1, j])
                            {
                                (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
                            }
                        }
                        else
                        {
                            if (matrix[k, j] > matrix[k + 1, j])
                            {
                                (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
                            }
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    bool flag = false;

                    int curr = array[j].Length;
                    int next = array[j + 1].Length;

                    if (curr < next)
                    {
                        flag = true;
                    }
                    else if (curr == next)
                    {
                        int sm_curr = 0;
                        int sm_next = 0;

                        for (int k = 0; k < curr; k++)
                            sm_curr += array[j][k];

                        for (int k = 0; k < next; k++)
                            sm_next+= array[j + 1][k];

                        if (sm_curr < sm_next)
                            flag = true;
                    }

                    if (flag)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            // end
        }
    }
}
