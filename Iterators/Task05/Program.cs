using System;
using System.Collections;
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            while (enumerator.MoveNext())
            {
                sb.Append($"{enumerator.Current} ");
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        private int position = -1;
        private int[] numbers;
        public MyDigits()
        {
        }
        public MyDigits(int[] numbers)
        {
            this.numbers = numbers;
        }
        public IEnumerator MyEnumerator(int value)
        {
            numbers = new int[value];
            for (int i = 1; i <= value; i++)
            {
                numbers[i - 1] = (int)Math.Pow(i, 10);
            }
            return new MyDigits(numbers);
        }
        public bool MoveNext()
        {
            if (position < numbers.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public object Current => numbers[position];
        public void Reset()
        {
            position = -1;
        }
    }
}
