using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Program
    {
        //quick sort
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int PivotIndex = Partition(array, left, right);
                QuickSort(array, left, PivotIndex - 1);
                QuickSort(array, PivotIndex + 1, right);
            }
        }
        public static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //Merge sort
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        static void Main(string[] args)
        {
            //quick sort logic
            int[] arr = { 10, 3, 9, 4, 7, 5, 8, 1 };
            Console.WriteLine("Before Sorting array \n");
            Print(arr);
            Console.WriteLine("\n");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(arr);
            sw.Stop();

            Console.WriteLine("After Quick Sort \n");
            Print(arr);
            Console.WriteLine("\n");
            Console.WriteLine($"Array Size {arr.Length} Time taken for quick sort {sw.Elapsed.TotalMilliseconds} milliSeconds");


            //Merge sort logic
            int[] arr1 = { 10, 3, 9, 4, 7, 5, 8, 1 };
            Console.WriteLine("\n");
            Console.WriteLine("Before  Merge sort array " + string.Join(" ", arr1));
            //   MergeSort(arr);
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            MergeSort(arr1);
            Console.WriteLine("\n");
            sw1.Stop();
            Console.WriteLine("After Merge Sort");
            Console.WriteLine("\n");
            Console.WriteLine("Merge sorted Array: " + string.Join(" ", arr1));
            Console.WriteLine("\n");
            Console.WriteLine($"ArraySize {arr1.Length} Time Taken for merge sort {sw1.Elapsed.TotalMilliseconds} milliSeconds");
            Console.ReadKey();
        }
    }
}
