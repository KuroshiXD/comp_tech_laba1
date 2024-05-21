using System;

namespace laba1
{
    public class IndexList
    {
        public struct Element
        {
            public DoublyLinkedList.Node node { get; set; }
            public int index { get; set; }
            public Element(DoublyLinkedList.Node node, int index)
            {
                this.node = node;
                this.index = index;
            }
        }

        private int count;
        private int capacity;
        Element[] buffer = null;

        public IndexList()
        {
            capacity = 5;
            count = 0;
            buffer = new Element[capacity];
        }

        private void ResizeArray()
        {
            Array.Resize(ref buffer, capacity * 2);
        }

        public void Append(DoublyLinkedList.Node data, int index)
        {
            if (index >= count) { ResizeArray(); }
            buffer[count++] = new Element(data, index);
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
            for (int i = index; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }
            count--;
        }
        public void Clear()
        {
            buffer = null;
            capacity = 5;
            count = 0;
        }

        public int Count { get { return count; } }

        public int Find(int index)
        {
            if (index == 0) { return 0; }
            else
            {
                int left = 0;
                int right = count - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (buffer[mid].index == index) { return mid; }
                    else if (buffer[mid].index < index) { left = mid + 1; }
                    else { right = mid - 1; }
                }
            }
            throw new IndexOutOfRangeException();
        }

        public DoublyLinkedList.Node this[int index]
        {
            get
            {
                if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
                else { return buffer[index].node; }
            }

            set
            {
                if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
                else { buffer[index].node = value; }
            }
        }
        public int GetIndex(int index)
        {
            return buffer[index].index;
        }
        public DoublyLinkedList.Node GetNode(int index)
        {
            return buffer[Find(index)].node;
        }
        public void SetNode(DoublyLinkedList.Node node, int index)
        {
            buffer[Find(index)].node = node;
            buffer[Find(index)].index = index;
        }
    }
}
