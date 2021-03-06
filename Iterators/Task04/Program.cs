using System;
using System.Collections;
using System.Text;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value = 0;
                if (!int.TryParse(Console.ReadLine(), out value) || value < 0)
                {
                    throw new ArgumentException();
                }
                MyInts myInts = new MyInts();
                IEnumerator enumerator = myInts.MyEnumerator(value);
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }           
        }
        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            StringBuilder sb = new StringBuilder();
            while (enumerator.MoveNext())
            {
                sb.Append($"{enumerator.Current} ");
            }
            Console.Write(sb.ToString().Trim());
        }
    }
    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        private int position = -1;
        private int count;
        public bool MoveNext()
        {
            if (position < count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public MyInts()
        { }
        public MyInts(int value)
        {
            count = value;
        }
        public IEnumerator MyEnumerator(int value)
        {
            return new MyInts(value);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current => (position + 1) * (position + 1);
    }
}