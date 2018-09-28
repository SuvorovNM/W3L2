using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace W3L2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader std = new StreamReader("input.txt");
            StreamWriter stw = new StreamWriter("output.txt");
            string str = std.ReadLine();
            string[] info = str.Split(' ');
            int n = Int32.Parse(info[0]);
            int m = Int32.Parse(info[1]);
            int k = Int32.Parse(info[2]);
            char[,] arr = new char[n,m];
            int[] pos1 = new int[n];
            int[] pos2 = new int[n];
            //Считывание символов массива
            for (int i = 0; i < n; i++)
            {
                str = std.ReadLine();
                //info = str.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = str[j];
                }
                pos1[i] = i + 1;//poss_pred
                pos2[i] = i + 1;//poss_after                
            }
            char[] temparray = new char[m];
            int min_idx;
            for (int i = 1; i <= k; i++)//Сортировка "построчно" начиная с конца
            {
                for (int p = 0; p < m; p++)
                {
                    temparray[p] = arr[n - i, pos1[p]-1];
                }
                for (int t = 0; t < m - 1; t++)//Select-sort
                {
                    min_idx = t;
                    for (int j = t + 1; j < m; j++)
                    {
                        if (arr[n - i, j] < arr[n - i, min_idx])
                            min_idx = j;
                    }
                        char temp = arr[n-i, t];
                        arr[n - i, t] = arr[n-i,min_idx];
                        arr[n - i, min_idx] = temp;
                        int tmpIndex = pos1[t];
                        pos1[t] = pos1[min_idx];
                        pos1[min_idx] = tmpIndex;
                }
            }
            for (int i = 0; i < m; i++)
            {
                stw.Write(pos1[i] + " ");
            }
            stw.Close();
        }
    }
}
