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
            return arrayToSort;
        }
        static T[] sortCharsSelecting<T>(T[] arrayToSort) where T : IComparable<T>
        {
            for (int j = 0; j < arrayToSort.Length - 1; j++)
            {
                int minItemIndex = j;
                for (int i = j; i < arrayToSort.Length; i++)
                {
                    if (arrayToSort[minItemIndex].CompareTo(arrayToSort[i]) > 0)
                    {
                        minItemIndex = i;
                    }

                }
                T temp = arrayToSort[j];
                arrayToSort[j] = arrayToSort[minItemIndex];
                arrayToSort[minItemIndex] = temp;
            }
            return arrayToSort;
        }
        static T[] sortBabelkowo<T>(T[] arrayToSort) where T : IComparable<T>
        {
            T temp;
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = arrayToSort.Length - 1; j > i; j--)
                {
                    if (arrayToSort[j - 1].CompareTo(arrayToSort[j]) > 0)
                    {
                        temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j - 1];
                        arrayToSort[j - 1] = temp;
                    }
                }
            }
            return arrayToSort;
        }
        static T[] sortKoktajlowy<T>(T[] arrayToSort) where T : IComparable<T>
        {
            T temp;
            int topIndex = arrayToSort.Length - 1;
            int bottomIndex = 0;
            while (bottomIndex < topIndex)
            {
                for (int i = topIndex; i > bottomIndex; i--)
                {
                    if (arrayToSort[i - 1].CompareTo(arrayToSort[i]) > 0)
                    {
                        temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i - 1];
                        arrayToSort[i - 1] = temp;
                    }
                }
                bottomIndex++;
                for (int i = bottomIndex; i < topIndex; i++)
                {
                    if (arrayToSort[i].CompareTo(arrayToSort[i + 1]) > 0)
                    {
                        temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        arrayToSort[i + 1] = temp;
                    }
                }
                topIndex--;
            }
            return arrayToSort;
        }
        static void sortSzybki<T>(T[] arrayToSort, int l, int r) where T : IComparable<T>
        {
            T temp;
            int i = l, j = r;
            T x = arrayToSort[(l + r) / 2];
            while (i <= j)
            {
                while (arrayToSort[i].CompareTo(x) < 0) i++;
                while (arrayToSort[j].CompareTo(x) > 0) j--;
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
        static void makeTree<T>(T[] array, int size, int index) where T : IComparable<T>
        {
            int largestIndex = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild].CompareTo(array[largestIndex]) > 0)
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild].CompareTo(array[largestIndex]) > 0)
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                T tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                makeTree(array, size, largestIndex);
            }
        }
        static T[] sortStogowy<T>(T[] arrayToSort) where T : IComparable<T>
        {
            int size = arrayToSort.Length;
            int startIndex = size / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                makeTree(arrayToSort, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                T tempVar = arrayToSort[0];
                arrayToSort[0] = arrayToSort[i];
                arrayToSort[i] = tempVar;
                makeTree(arrayToSort, i, 0);
            }
            return arrayToSort;
        }
        static void displayResult<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        // public class CharOrInt
        // {
        //     public string Value;
        //     public char[] charsArrayValue(){
        //         return Value.ToCharArray();
        //     }
        //     public int[] intsArrayValue(){
        //         string[] stringArrayToConvert = Value.Split(' ');
        //         return Array.ConvertAll(stringArrayToConvert, s => int.Parse(s));
        //     }
        //     public bool isChar(){
        //         return true;
        //     }
        //     public CharOrInt<T>(T value) where T : IComparable<T>
        //     {

        //     }
        // }
        static void Main(string[] args)
        {
            Console.Write("Podaj tekst do posortowania: ");
            string dataToSort = Console.ReadLine();

            // CharOrInt testData = new CharOrInt(dataToSort);
            // Console.WriteLine(testData);

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

            Console.Write("\nSortowanie przez proste wstawianie: ");
            displayResult(simpleSorting(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie przez proste wybieranie: ");
            displayResult(sortCharsSelecting(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie bąbelkowe: ");
            displayResult(sortBabelkowo(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie koktajlowe: ");
            displayResult(sortKoktajlowy(dataToSort.ToCharArray()));
            Console.Write("\nSortowanie szybkie: ");
            char[] quickSortArray = dataToSort.ToCharArray();
            sortSzybki(quickSortArray, 0, quickSortArray.Length - 1);
            displayResult(quickSortArray);
            Console.Write("\nSortowanie stogowe: ");
            displayResult(sortStogowy(dataToSort.ToCharArray()));
        }
    }
}
