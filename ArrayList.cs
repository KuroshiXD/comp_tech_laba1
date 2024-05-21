using System;

namespace laba1
{
    public class ArrayList
    {
        private int[] buffer;
        private int count;
        private int capacity;

        public ArrayList()
        {
            capacity = 5;
            buffer = new int[capacity];
            count = 0;
        }

        public void Add(int item)
        {
            if (count == buffer.Length)
            {
                ResizeArray();
            }
            buffer[count++] = item;
        }

        public void ResizeArray()
        {
            int newSize = buffer.Length * 2;
            int[] newArray = new int[newSize];
            Array.Copy(buffer, newArray, buffer.Length);
            buffer = newArray;
        }

        public void Insert(int item, int index)
        {
            if (index < 0 || index > count) return;

            if (count == buffer.Length)
            {
                ResizeArray();
            }

            for (int i = count; i > index; i--)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[index] = item;
            count++;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= count) return;

            for (int i = index; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            count--;
        }

        public void Clear()
        {
            buffer = new int[capacity];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    return 0;
                }
                return buffer[index];
            }

            set
            {
                if (index >= 0 && index < count)
                {
                    buffer[index] = value;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
