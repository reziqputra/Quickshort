using System;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Xml;

namespace QuickSort
{
    class Program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0;
        private int mov_count = 0;

        //Number of elements in array
        private int n;

        void read()
        {
            while (true)
            {
                Console.WriteLine("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\n Array can have maximum 20 elements \n");
            }
            Console.WriteLine("\n====================");
            Console.WriteLine("Enter Array Elements");
            Console.WriteLine("\n====================");

            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }

        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;
            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //Partition the list into two parts
            //One containing elements less that or equal to pivot
            //Outher containing elements greater than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //search for an element greater than pivot
                while ((arr[i]) <= pivot && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //search for an element less than or equal to pivot
                while ((arr[j]) > pivot && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j) //if the greater element is on the left of the element
                {
                    //swap the element at index i with the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            // j now contains the index of the last elements int the sorted list

            if (low < j)
            {
                //Move the pivot to its correct position in the list
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low, j - 1);

            //sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }

        void display()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("Sorted Array Elements");
            Console.WriteLine("\n-------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\n Number of Comparison: " + cmp_count);
            Console.WriteLine("\n Number of Data Movements: " + mov_count);
        }

        int getSize()
        {
            return n;
        }

        static void Main(string[] args)
        {
            //Declaring the object of the class
            Program mylist = new Program();
            //Accept Array Elements
            mylist.read();
            //Calling the sorting function
            //First call to quick sort Alogarithm
            mylist.q_sort(0, mylist.getSize() - 1);
            //Display sorted array
            mylist.display();
            //to exit from the console
            Console.WriteLine("\n\n Press enter to exit.");
            Console.Read();
        }
    }
}//selesai