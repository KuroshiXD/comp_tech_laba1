using System;


namespace laba1
{
    class Programm
    {
        public static void Main(string[] args)
        {

            DoublyLinkedList doublyLinked = new DoublyLinkedList();
            ChainList chainList = new ChainList();
            ArrayList arrayList = new ArrayList();

            Random random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int operation = random.Next(1, 5);
                int index = random.Next(50);
                int Data = random.Next(50);

                                
                switch (operation){

                    case 1:
                        arrayList.Add(Data);
                        chainList.Add(Data);
                        doublyLinked.Add(Data);
                        break;

                    case 2:
                        arrayList.Delete(index);
                        chainList.RemoveAt(index);
                        doublyLinked.RemoveAt(index);
                        break;

                    //case 3:
                    //    arrayList.Insert(index, Data);
                    //    chainList.Insert(index, Data);
                    //    doublyLinked.Insert(index, Data);
                    //    break;

                    //case 4:

                    //    //arrayList.Clear();
                    //    //chainList.Clear();
                    //    //doublyLinked.Clear();
                    //    break;

                    case 5:
                        arrayList[i] = Data;
                        chainList[i] = Data;
                        doublyLinked[i] = Data;
                        break;
                }

            }

            Console.WriteLine("ArrayList:");
            arrayList.Print();
            Console.WriteLine("ChainList:");
            chainList.Print();
            Console.WriteLine("DoublyLinkedList:");
            doublyLinked.Print();

            AreListsEqual(arrayList, chainList, doublyLinked);

            void AreListsEqual(ArrayList arrayList, ChainList chainList, DoublyLinkedList doublyLinkedList)
            {
                bool areEqual = true;

                if (arrayList.Count != chainList.Count || arrayList.Count != doublyLinkedList.Count)
                {
                    areEqual = false;
                }
                else
                {
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        if (arrayList[i] != chainList[i] || arrayList[i] != doublyLinkedList[i])
                        {
                            areEqual = false;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Равны ли списки?: {areEqual}");
            }
        }
    }
}
