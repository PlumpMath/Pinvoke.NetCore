# Pinvoke.NetCore
A small Demo to show how Pinvoke can be used to make .Net Core Faster

Its very easy to call a C function from the C# code:

```C#
            [DllImport("/root/pinvoke/sort.so",EntryPoint="_Z9quickSortPiii")]
            static extern void sort(int[] handle, int start, int stop);
```

Qsort code is from here:
http://www.algolist.net/Algorithms/Sorting/Quicksort

C++

```C
void quickSort(int arr[], int left, int right) {

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
```

C#
```C#
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
```

C Sort: 8249

C# Sort: 13718



The example is quite trivial, but it shows how you can use pinvoke to make .net core faster by using C code and calling it from the c# code. The Array.Sort method happens to be faster than either method in case you were wondering.
