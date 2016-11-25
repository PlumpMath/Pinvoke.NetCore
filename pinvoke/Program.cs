using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
namespace ConsoleApplication
{

	public class Program
	{

	    [DllImport("/root/pinvoke/sort.so",EntryPoint="_Z9quickSortPiii")]
	    static extern void sort(int[] handle, int start, int stop);

	    static void quickSort(int[] arr, int left, int right) {

		int i = left, j = right;
		int tmp;
		int pivot = arr[(left + right) / 2];

		/* partition */

		while (i <= j) {
		    while (arr[i] < pivot)
			i++;

		    while (arr[j] > pivot)
			j--;

		    if (i <= j) {
			tmp = arr[i];
			arr[i] = arr[j];
			arr[j] = tmp;
			i++;
			j--;
		    }

		};

		/* recursion */
		if (left < j)
		    quickSort(arr, left, j);

		if (i < right)
		    quickSort(arr, i, right);
	    }

	    public static void Main(string[] args)
	    {

		int Min = 0;
		int Max = 20;
		Random randNum = new Random();
		int[] numbers = new int[100000000];

		for(int i=0; i<numbers.Length; i++) {
		    numbers[i]=randNum.Next(Min, Max);
		}


		Stopwatch time = new Stopwatch();
		time.Reset();
		time.Start();
		sort(numbers,0,numbers.Length-1);
		time.Stop();

		Console.WriteLine("C Sort: " +  time.ElapsedMilliseconds);

		for(int i=0; i<numbers.Length; i++) {
		    numbers[i]=randNum.Next(Min, Max);
		}


		time.Reset();
		time.Start();
		quickSort(numbers,0,numbers.Length-1);
		time.Stop();

		Console.WriteLine("C# Sort: "+ time.ElapsedMilliseconds);

	    }
	}
}
