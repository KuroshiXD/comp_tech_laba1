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
            CheckException(index);

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
            CheckException(index);

            for (int i = index; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            count--;

        }

        public void Clear()
        {
            buffer = null;
            count = 0;
            capacity = 5;
        }

        public int Count
        {
            get { return count; }
        }

        private void CheckException(int index)
        {
            if (index < 0 || index > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= buffer.Length)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                return buffer[index];
            }

            set
            {
                if (index < 0 || index >= buffer.Length)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                buffer[index] = value;
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[i] + " ");
            }
        }
    }
}