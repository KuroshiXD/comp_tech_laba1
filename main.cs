using System;


namespace laba1
{
    class Programm
    {
        public static void Main(string[] args)
        {

            ChainList chainList = new ChainList();
            ArrayList arrayList = new ArrayList();

            Random random = new Random();
            
            for (int i = 1; i < 500; i++)
            {
                int operations = random.Next(1, 6);
                int data = random.Next(100);
                int indexAr = random.Next(arrayList.Count);
                int indexCh = random.Next(chainList.Count);

                switch (operations)
                {
                    case 1:
                        arrayList.Add(data);
                        chainList.Add(data);
                        Console.WriteLine("Array added: " + data);
                        Console.WriteLine("Chain added: " + data);
                        break;

                    case 2:
                        if (arrayList.Count > 0 && indexAr < arrayList.Count)
                        {
                            int deletedFromArray = arrayList[indexAr]; // сохраняем значение для вывода
                            arrayList.Delete(indexAr);
                            Console.WriteLine("Array deleted: " + deletedFromArray); // выводим сохраненное значение
                        }
                        if (chainList.Count > 0 && indexCh < chainList.Count)
                        {
                            int deletedFromChain = chainList.Find(indexCh); // сохраняем значение для вывода
                            chainList.RemoveAt(indexCh);
                            Console.WriteLine("Chaim removed: " + deletedFromChain); // выводим сохраненное значение
                        }
                        break;

                    case 3:
                        if (indexAr < arrayList.Count || indexCh < chainList.Count)
                        {
                            arrayList.Insert(data, indexAr);
                            chainList.Insert(data, indexCh);
                            Console.WriteLine("Array inserted: " + data + " on index " + indexAr);
                            Console.WriteLine("Chain inserted: " + data + " on index " + indexCh);
                        }
                        break;

                    case 4:
                        if (arrayList.Count > 0)
                        {
                            arrayList[indexAr] = data;
                        }
                        break;
                }

                if (arrayList.Count > 0 || chainList.Count > 0)
                {
                    Console.Write("ArrayList: ");
                    arrayList.Print();
                    Console.WriteLine();
                    Console.Write("ChainList: ");
                    chainList.Print();
                    Console.WriteLine();
                    Console.WriteLine("----------------");
                }
            }

            Console.WriteLine("--> All tests completed! <--");
            arrayList.Clear();
            chainList.Clear();
            Console.WriteLine("Array cleared");
            Console.WriteLine("Chain cleared");
            Console.Write("ArrayList: ");
            arrayList.Print();
            Console.WriteLine();
            Console.Write("ChainList: ");
            chainList.Print();
        }
    }
}
