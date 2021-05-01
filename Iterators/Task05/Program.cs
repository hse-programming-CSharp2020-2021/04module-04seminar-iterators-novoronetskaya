using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int value) || value < 0)
                {
                    throw new ArgumentException();
                }
                MyDigits myDigits = new MyDigits();
                IEnumerator enumerator = myDigits.MyEnumerator(value);
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
        }
        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current} ");
            }
            (enumerator as MyDigits).Reversed = !(enumerator as MyDigits).Reversed;
        }
    }
    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        private int count;
        private int position = -1;
        public bool Reversed { get; set; } = false;
        public MyDigits()
        {
        }
        public MyDigits(int value)
        {
            count = value;
        }
        public IEnumerator MyEnumerator(int value)
        {
            return new MyDigits(value);
        }
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
        public object Current
        {
            get
            {
                if (Reversed)
                {
                    return (int)Math.Pow(count - position, 10);
                }
                return (int)Math.Pow(position + 1, 10);
            }
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
