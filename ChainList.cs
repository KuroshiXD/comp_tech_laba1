using System;

namespace laba1
{
    public class ChainList
    {
        public Node head;

        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                Node.count++;
                return;
            }

            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Node.count++;
        }

        public Node Find(int index)
        {
            if (index < 0 || index >= Node.count)
            {
                return null;
            }

            int currentIndex = 0;
            Node current = head;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }
                current = current.Next;
                currentIndex++;
            }

            return null;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Node.count) return;

            if (index == 0)
            {
                head = head.Next;
                Node.count--;
                return;
            }

            int currentIndex = 0;
            Node current = head;

            while (current != null)
            {
                if (currentIndex + 1 == index)
                {
                    current.Next = current.Next.Next;
                    Node.count--;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public void Insert(int data, int index)
        {
            if (index < 0 || index > Node.count) return;

            Node newNode = new Node(data);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                Node.count++;
                return;
            }

            Node current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex + 1 == index)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Node.count++;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Node.count) return 0;

                Node node = Find(index);
                return node.Data;
            }
            set
            {
                if (index >= 0 && index < Node.count)
                {
                    Node node = Find(index);
                    if (node != null)
                        node.Data = value;
                }
            }
        }

        public void Print()
        {
            Node current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void Clear()
        {
            head = null;
            Node.count = 0;
        }

        public int Count
        {
            get { return Node.count; }
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public static int count = 0;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
