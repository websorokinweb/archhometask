using System;
using System.Globalization;

namespace archhometask
{
    internal class Program
    {
        static string simpleSorting(char[] arrayToSort)
        {
            // startujemy z drugiego elementu
            char needItem;
            int j;
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                needItem = arrayToSort[i];
                j = i - 1;
                while (j >= 0 && needItem <= arrayToSort[j])
                {
                    arrayToSort[j + 1] = arrayToSort[j];
                    j--;
                }
                arrayToSort[j + 1] = needItem;
            }
            return new string(arrayToSort);
        }
        static string sortCharsSelecting(char[] arrayToSort)
        {
            int minItemIndex = 0;
            for (int j = 0; j < arrayToSort.Length; j++)
            {
                for (int i = j; i < arrayToSort.Length - 1; i++)
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
        static string sortSzybki(char[] arrayToSort, int l, int r)
        {
            char temp;
            int i = l, j = r;
            int x = arrayToSort[arrayToSort.Length - 1];
            while (i <= j)
            {
                while (arrayToSort[i] < x && i < r) i++;
                while (arrayToSort[j] < x && j > l) j--;
                if (i <= j)
                {
                    temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[j];
                    arrayToSort[j] = temp;
                    i++;
                    j--;
                }
                if (l < j) sortSzybki(arrayToSort, l, j);
                if (r > i) sortSzybki(arrayToSort, i, r);
            }
            return new string(arrayToSort);
        }
        static string sortStogowy(char[] arrayToSort)
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
        static void Main(string[] args)
        {
            string wordToSort = "sortowanie";

            Console.Write("\nDONE Sortowanie przez proste wstawianie: ");
            Console.Write(simpleSorting(wordToSort.ToCharArray()));
            Console.Write("\nSortowanie przez proste wybieranie: ");
            Console.Write(sortCharsSelecting(wordToSort.ToCharArray()));
            Console.Write("\nDONE Sortowanie bąbelkowe: ");
            Console.Write(sortBabelkowo(wordToSort.ToCharArray()));
            Console.Write("\nDONE Sortowanie koktajlowe: ");
            Console.Write(sortKoktajlowy(wordToSort.ToCharArray()));
            Console.Write("\nSortowanie szybkie: ");
            Console.Write(sortSzybki(wordToSort.ToCharArray(), 0, -1));
            Console.Write("\nSortowanie stogowe: ");
            Console.Write(sortStogowy(wordToSort.ToCharArray()));
        }
    }
}