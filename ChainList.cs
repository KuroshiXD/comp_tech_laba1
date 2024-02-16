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

        public int Find(int index)
        {
            int currentIndex = 0;

            Node current = head;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Data;
                }
                current = current.Next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException();
        }

        public void RemoveAt(int index)
        {
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

            throw new IndexOutOfRangeException();
        }

        public void Insert(int data, int index)
        {

            Node current = head;
            int currentIndex = 0;

            if (index < 0 || index > Node.count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Node currentNode = new Node(data);
                currentNode.Next = head;
                head = currentNode;
                Node.count++;

            }
            else
            {
                while (current != null)
                {
                    if (currentIndex + 1 == index)
                    {
                        Node currentNode = new Node(data);
                        currentNode.Next = current.Next;
                        current.Next = currentNode;
                        Node.count++;
                        return;
                    }
                    currentIndex++;
                    current = current.Next;
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
