using System;
using System.Collections;
using System.Text;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF7;
                int N = 0;
                if (!int.TryParse(Console.ReadLine(), out N) || N < 0)
                {
                    throw new ArgumentException();
                }
                Person[] people = new Person[N];
                for (int i = 0; i < N; i++)
                {
                    string[] data = Console.ReadLine().Split(' ');
                    if (data.Length < 2 || data.Length > 3)
                    {
                        throw new ArgumentException();
                    }
                    people[i] = new Person(data[1], data[0]);
                }
                People peopleList = new People(people);
                foreach (Person p in peopleList)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
                foreach (Person p in peopleList.GetPeople)
                {
                    Console.WriteLine(p);
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }
    }
    public class Person : IComparable<Person>
    {
        public string firstName;
        public string lastName;
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public int CompareTo(Person b)
        {
            return lastName.CompareTo(b.lastName);
        }
        public override string ToString()
        {
            return $"{lastName} {firstName.ToUpper()[0]}.";
        }
    }
    public class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] people)
        {
            _people = people;
        }
        public Person[] GetPeople
        {
            get 
            {
                return _people;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        private int Position = -1;
        public PeopleEnum(Person[] people)
        {
            _people = new Person[people.Length];
            Array.Copy(people, _people, people.Length);
            Array.Sort(_people);
        }
        public bool MoveNext()
        {
            if (Position < _people.Length - 1)
            {
                Position++;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            Position = -1;
        }
        public Person Current
        {
            get
            {
                return _people[Position];
            }
        }
        object IEnumerator.Current
        {
            get => Current;
        }
    }
}