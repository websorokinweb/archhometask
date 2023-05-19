using System;
using System.Globalization;

namespace archhometask
{
    internal class Program
    {
        static T[] simpleSorting<T>(T[] arrayToSort) where T : IComparable<T>
        {
            T needItem;
            int j;
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                needItem = arrayToSort[i];
                j = i - 1;
                while (j >= 0 && needItem.CompareTo(arrayToSort[j]) < 0)
                {
                    arrayToSort[j + 1] = arrayToSort[j];
                    j--;
                }
                arrayToSort[j + 1] = needItem;
            }
            // return new string(arrayToSort);
            return arrayToSort;
        }
        static string sortCharsSelecting(char[] arrayToSort)
        {
            for (int j = 0; j < arrayToSort.Length - 1; j++)
            {
                int minItemIndex = j;
                for (int i = j; i < arrayToSort.Length; i++)
                {
                    if (arrayToSort[minItemIndex] > arrayToSort[i])
                    {
                        minItemIndex = i;
                    }

                }
                char temp = arrayToSort[j];
                arrayToSort[j] = arrayToSort[minItemIndex];
                arrayToSort[minItemIndex] = temp;
            }
            return new string(arrayToSort);
        }
        static string sortBabelkowo(char[] arrayToSort)
        {
            char temp;
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = arrayToSort.Length - 1; j > i; j--)
                {
                    if (arrayToSort[j - 1] > arrayToSort[j])
                    {
                        temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j - 1];
                        arrayToSort[j - 1] = temp;
                    }
                }
            }
            return new string(arrayToSort);
        }
        static string sortKoktajlowy(char[] arrayToSort)
        {
            char temp;
            int topIndex = arrayToSort.Length - 1;
            int bottomIndex = 0;
            while (bottomIndex < topIndex)
            {
                for (int i = topIndex; i > bottomIndex; i--)
                {
                    if (arrayToSort[i - 1] > arrayToSort[i])
                    {
                        temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i - 1];
                        arrayToSort[i - 1] = temp;
                    }
                }
                bottomIndex++;
                for (int i = bottomIndex; i < topIndex; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        arrayToSort[i + 1] = temp;
                    }
                }
                topIndex--;
            }
            return new string(arrayToSort);
        }
        static void sortSzybki(char[] arrayToSort, int l, int r)
        {
            char temp;
            int i = l, j = r;
            int x = arrayToSort[(l + r) / 2];
            while (i <= j)
            {
                while (arrayToSort[i] < x) i++;
                while (arrayToSort[j] > x) j--;
                if (i <= j)
                {
                    temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[j];
                    arrayToSort[j] = temp;
                    i++;
                    j--;
                }
            }
            if (l < j) sortSzybki(arrayToSort, l, j);
            if (r > i) sortSzybki(arrayToSort, i, r);
        }
        static void makeTree(char[] array, int size, int index)
        {
            int largestIndex = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                char tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                makeTree(array, size, largestIndex);
            }
        }
        static string sortStogowy(char[] arrayToSort)
        {
            int size = arrayToSort.Length;
            int startIndex = size / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                makeTree(arrayToSort, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                char tempVar = arrayToSort[0];
                arrayToSort[0] = arrayToSort[i];
                arrayToSort[i] = tempVar;
                makeTree(arrayToSort, i, 0);
            }
            return new string(arrayToSort);
        }
        static void displayResult<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Podaj tekst do posortowania: ");
            string dataToSort = Console.ReadLine();

            // string stringToSort = "SORTOWANIE";
            // string stringToSort = "45 98 7 12";
            // string divider = " ";
            // bool isChar = Char.IsLetter(stringToSort[0]);
            // if(isChar){
                // char[] dataToSort = stringToSort.ToCharArray();
            // }else{
                // string[] stringArrayToConvert = stringToSort.Split(divider);
                // int[] dataToSort = Array.ConvertAll(stringArrayToConvert, s => int.Parse(s));
            // }
            // displayResult(dataToSort);

            // string dataToSort = "SORTOWANIE";
            // string dataToSort = "cba";
            // int[] dataToSort = new int[] { 4, 2, 1, 6 };


            Console.Write("\nSortowanie przez proste wstawianie: ");
            displayResult(simpleSorting(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie przez proste wybieranie: ");
            Console.Write(sortCharsSelecting(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie bąbelkowe: ");
            Console.Write(sortBabelkowo(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie koktajlowe: ");
            Console.Write(sortKoktajlowy(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie szybkie: ");
            char[] quickSortArray = dataToSort.ToCharArray();
            sortSzybki(quickSortArray, 0, quickSortArray.Length - 1);
            Console.Write(new string(quickSortArray));
            Console.Write("\nSortowanie stogowe: ");
            Console.Write(sortStogowy(dataToSort.ToCharArray()));
        }
    }
}
