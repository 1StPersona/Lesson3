using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    internal class Program
    {
        static void Exmpl01()
        {
            int[] arr = new int[5];
            arr[0] = 55;
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = i;
            }


            int[] arr2 = new int[] { 1, 2, 3 };
        }
        static void Check(out int a)
        {
            while (!Int32.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ввод некорректный! Введите целочисленное значение!");
            }
        }
        static void FillArray(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 100);
            }
        }
        static void OutputArrayHorizontal(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
        static void OutputArrayVertical(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0}", arr[i]);
            }
            Console.WriteLine();
        }

        static void Exmpl02()
        {
            int cnt = 0;
            int[,] arr = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = cnt;
                    Console.Write("{0}\t", arr[i, j]);
                    cnt++;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а двумерный массив В случайными числами с помощью циклов. Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В.
        /// </summary>
        static void Task1()
        {
            Random rand = new Random();

            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Введите значения одномерного массива: ");
            for (int i = 0; i < A.Length; i++)
            {
                Check(out A[i]);
            }
            Console.WriteLine("Одномерный массив целых чисел:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0} ", A[i]);
            }
            Console.WriteLine("\nДвумерный массив дробных чисел:");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = Math.Round(rand.NextDouble() * 100, 2);
                    Console.Write("{0}\t", B[i, j]);
                }
                Console.WriteLine();
            }

            double[] C = new double[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                C[i] = A[i];
            }
            int cnt = A.Length;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    C[cnt] = B[i, j];
                    cnt++;
                }
            }
            Console.WriteLine();
            /*for(int i = 0; i < C.Length; i++)
            {
                Console.Write("{0} ", C[i]);
            }*/
            double max = 0, min = 1000000;
            double sum = 0, mult = 1;
            double sumA = 0, sumB = 0;

            for (int i = 0; i < C.Length; i++)
            {
                if (max < C[i]) max = C[i];
                if (min > C[i]) min = C[i];
                sum += C[i];
                mult *= C[i];

                if (i % 2 == 0 && i < 5) sumA += A[i];
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 4; j += 2)
                {
                    sumB += B[i, j];
                }
            }

            Console.WriteLine("Максимальный элемент в обоих массивах: " + max);
            Console.WriteLine("Минимальный элемент в обоих массивах: " + min);
            Console.WriteLine("Сумма всех элементов в обоих массивах: " + sum);
            Console.WriteLine("Произведение всех элементов в обоих элементах: " + mult);

            Console.WriteLine("Сумма всех четных элементов в одномерном массиве: " + sumA);
            Console.WriteLine("Сумма нечетных столбцов в двумерном массиве: " + sumB);

        }
        /// <summary>
        /// Даны 2 массива размерности M и N соответственно. Необходимо переписать в третий массив общие элементы первых двух массивов без повторений.
        /// </summary>
        static void Task2()
        {
            int length3 = 0;
            int cnt = 0;
            int[] M = new int[10];
            int[] N = new int[10];
            FillArray(M);
            System.Threading.Thread.Sleep(50);
            FillArray(N);

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < N.Length; j++)
                {
                    if (M[i] == N[j])
                    {
                        length3++;
                    }
                }
            }
            int[] K = new int[length3];
            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < N.Length; j++)
                {
                    if (M[i] == N[j] && !isExist(K, M[i]))
                    {
                        K[cnt++] = M[i];
                    }
                }
            }

            OutputArrayHorizontal(M);
            OutputArrayHorizontal(N);
            OutputArrayHorizontal(K);
        }
        static bool isExist(int[] arr, int a)
        {
            bool flag = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a) flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Пользователь вводит строку. Проверить, является ли эта строка палиндромом. Палиндромом называется строка, которая одинаково читается слева направо и справа налево.
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("Введите строку: ");
            string userInput = Console.ReadLine();
            bool flag = true;
            for (int i = 0; i < userInput.Length / 2; i++)
            {
                if (userInput[i] != userInput[userInput.Length - 1 - i])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Введенная строка является полиндромом");
            }
            else Console.WriteLine("Введенная строка не является полиндромом");
        }
        /// <summary>
        /// Подсчитать количество слов во введенном предложении.
        /// </summary>
        static void Task4()
        {
            Console.WriteLine("Введите строку: ");
            string userInput = Console.ReadLine();
            string[] strArr = userInput.Split(' ');
            Console.WriteLine("Колчисество слов в предложении: {0}", strArr.Length);
        }
        /// <summary>
        /// Дан текст. Найти наибольшее количество идущих подряд одинаковых символов
        /// </summary>
        static void Task6()
        {
            Console.WriteLine("Введите строку: ");
            string userInput = Console.ReadLine();
            char[] arr = userInput.ToCharArray();
            int cnt = 0, cntMax = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    cnt++;
                }
                else
                {
                    if (cnt > cntMax)
                    {
                        cntMax = cnt;
                        cnt = 0;
                    }
                }
            }
            Console.WriteLine(cntMax + 1);
        }
        /// <summary>
        /// Составить программу, которая подсчитывает, сколько содержится цифр в строке длиной 20 символов.
        /// </summary>
        static void Task8()
        {
            Console.WriteLine("Введите строку: ");
            string userInput = Console.ReadLine();
            char[] arr = userInput.ToCharArray();
            int cnt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 48 && arr[i] <= 57) cnt++;
            }
            Console.WriteLine(cnt);
        }
        /// <summary>
        /// Дан текст, состоящий из 20 букв. Проверить, можно ли из заданной последовательности символов составить Ваше имя и напечатать его. В противном случае напечатать текст “Нет имени”.
        /// </summary>
        static void Task9()
        {
            char[] name = new char[] { 'v', 'a', 'l', 'e', 'r', 'a' };
            string text = "Have one's head in the clouds";
            text = text.ToLower();
            char[] textChar = text.ToCharArray();
            bool flag = true;

            for (int i = 0; i < name.Length; i++) //пробегаемся по буквам в имени
            {
                for (int j = 0; j < textChar.Length; j++) //пробегаемся по буквам в предложении
                {
                    if (name[i] == textChar[j]) //если нашли совпадение, то перестаем пробегаться по предложению и присваиваем flag = true; Также меняем букву на заглавную, чтобы избежать повторов
                    {
                        textChar[j] = Char.ToUpper(text[j]);
                        flag = true;
                        break;
                    }
                    else flag = false; //если совпадение не нашлось, то присваиваем flag = false

                }
                if (!flag) break; //если буква из имени не нашлась, то выходим из цикла
            }

            if (!flag) Console.WriteLine("Нет имени"); //Так как буква не нашлась, выводим Нет имени
            else //Если буква нашлась, первую букву имени делаем заглавной и выводим имя
            {
                name[0] = Char.ToUpper(name[0]);
                Console.WriteLine(name);
            }

        }
        /// <summary>
        /// Написать программу, в которой по малой русской букве выводится соответствующая большая.
        /// </summary>
        static void Task11()
        {
            Console.WriteLine("Введите любую букву");
            char[] letter = Console.ReadLine().ToCharArray();
            bool flag = true;
            if (letter.Length > 1) flag = false;
            while (!flag)
            {
                Console.WriteLine("Введите только 1 букву!");
                letter = Console.ReadLine().ToCharArray();
                if (letter.Length == 1) flag = true;
            }
            letter[0] = Char.ToUpper(letter[0]);
            Console.WriteLine("Большая буква {0}", letter[0]);
        }

        static int[] DeleteElemByIndex(int[] arr, int id)
        {
            int[] bufArr = new int[arr.Length - 1];
            for (int i = 0; i < id; i++)
            {
                bufArr[i] = arr[i];
            }
            for (int i = id; i < bufArr.Length; i++)
            {
                bufArr[i] = arr[i + 1];
            }
            return bufArr;
        }
        static string[] DeleteElemByIndex(string[] arr, int id)
        {
            string[] bufArr = new string[arr.Length - 1];
            for (int i = 0; i < id; i++)
            {
                bufArr[i] = arr[i];
            }
            for (int i = id; i < bufArr.Length; i++)
            {
                bufArr[i] = arr[i + 1];
            }
            return bufArr;
        }


        static void HTask1()
        {
            int[] arr = new int[] { 1, 2, 12, 45, 65, 32 };
            //Напечатать весь массив целых чисел
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            //Найти индекс максимального значения в массиве
            int maxInd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr.Max()) maxInd = i;
            }
            Console.WriteLine("Индекс максимального значения в массиве {0}", maxInd);
            Console.WriteLine();
            //Удалить элемент из массива по индексу
            arr = DeleteElemByIndex(arr, 2);
            OutputArrayHorizontal(arr);
            //Удалить из строки слова, в которых есть буква 'a'
            string str = "bnsfg asxz lflks fhgjfha";
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains('a'))
                {
                    words = DeleteElemByIndex(words, i);
                }
            }
            str = string.Join(" ", words);
            Console.WriteLine(str);
            //Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
            int[,] matrix = new int[,] {{2, 3, 4},
                                        {4, 5, 6},
                                        {7, 4, 8}};
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, i] % 2 == 0)
                {
                    index = i;
                    for (int j = 0; j < 3; j++)
                    {
                        matrix[j, index] = 0;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить является ли данный билет счастливым (если на билете напечатано шестизначное число,
            //и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым).
            Console.WriteLine("Введите 6-значный номер трамвайного билета: ");
            int ticket = 0;
            bool flag = false;
            while (!flag)
            {
                Check(out ticket);
                if (ticket > 999999 || ticket < 100000)
                {
                    Console.WriteLine("6-значный нужно!");
                }
                else flag = true;
            }
            int sum1 = 0, sum2 = 0;
            sum1 = ticket / 1000 % 10 + ticket / 10000 % 10 + ticket / 100000 % 10;
            sum2 = ticket % 10 + ticket / 10 % 10 + ticket / 100 % 10;
            if (sum1 == sum2) Console.WriteLine("Ваш билет счастливый!");
            else Console.WriteLine("Ваш билет не является счастливым!");

        }

        /// <summary>
        /// Числовые значения символов нижнего регистра в коде ASCII отличаются от значений символов верхнего регистра на величину 32. 
        /// Используя эту информацию, написать программу, которая считывает с клавиатуры и конвертирует все символы нижнего регистра в символы верхнего регистра и наоборот.
        /// </summary>
        static void HTask2()
        {
            Console.WriteLine("Введите любую букву: ");
            char[] letter = Console.ReadLine().ToCharArray();
            for (int i = 0; i < letter.Length; i++)
            {
                if (letter[i] >= 65 && letter[i] <= 90) letter[i] = Char.ToLower(letter[i]);
                else if (letter[i] >= 97 && letter[i] <= 122) letter[i] = Char.ToUpper(letter[i]);
            }
            string words = string.Join("", letter);
            Console.WriteLine("Реверснутая строка: {0}", words);

        }
        /// <summary>
        /// Дано целое число N (> 0), найти число, полученное при прочтении числа N справа налево. Например, если было введено число 345, то программа должна вывести число 543.
        /// </summary>
        static void HTask3()
        {
            Console.WriteLine("Введите любое целое число: ");
            char[] c = Console.ReadLine().ToCharArray();
            bool flag = false;
            while (!flag)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] >= 57 || c[i] <= 48)
                    {
                        Console.WriteLine("Введите только целое число!");
                        flag = false;
                        break;
                    }
                    else flag = true;
                }
            }

            char[] buffC = new char[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                buffC[i] = c[c.Length - i - 1];
            }
            string result = string.Join("", buffC);
            Console.WriteLine("reversed: {0}", result);

        }
        /// <summary>
        /// Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100.
        /// Определить сумму элементов массива, расположенных между минимальным и максимальным элементами
        /// </summary>
        static void HTask4()//НЕ СДЕЛАНО, ДОДЕЛАТЬ ПОСЛЕДНИЕ ДВА ИФА
        {
            int[,] arr = new int[5, 5];
            Random rand = new Random();
            int max = 0, min = 1000;
            int maxIndI = 0, maxIndJ = 0;
            int minIndI = 0, minIndJ = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                    Console.Write(arr[i, j] + "\t");
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        maxIndI = i;
                        maxIndJ = j;
                    }
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minIndI = i;
                        minIndJ = j;
                    }
                }
                Console.WriteLine();
            }
            int sum = 0;

            var startI = (minIndI <= maxIndI) ? minIndI : maxIndI;
            var endI = (startI == minIndI) ? maxIndI : minIndI;

            var startJ = (minIndJ <= maxIndJ) ? minIndJ : maxIndJ;
            var endJ = (startJ == minIndJ) ? maxIndJ : minIndJ;

            for (int i = startI; i <= endI; i++)
            {
                for (int j = startJ; j <= endJ; j++)
                {
                    sum += arr[i, j];
                }
            }
            /*
            if(maxIndI >= minIndI && maxIndJ >= minIndJ)
            {
                for(int i = minIndI; i <= maxIndI; i++)
                {
                    for(int j = minIndJ; j <= maxIndJ; j++)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            else if(maxIndI <= minIndI && maxIndJ <= minIndJ)
            {
                for (int i = maxIndI; i <= minIndI; i++)
                {
                    for (int j = maxIndJ; j <= minIndJ; j++)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            */


            Console.WriteLine("Max Value: {0}\nMin Value: {1}\nSum: {2}", max, min, sum);
        }
        /// <summary>
        /// Составьте программу, которая в слове «класс» две одинаковые буквы заменяет цифрой «1»
        /// </summary>
        static void Htask5()
        {
            string word = "class";
            char[] arr = word.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    arr[i] = '1';
                    arr[i + 1] = '1';
                }
            }
            Console.WriteLine(arr);
        }

        /// <summary>
        ///  Дан текст.Определить, есть ли в тексте слово one
        /// </summary>

        static void Htask6()
        {
            string text = "Lorem ipsum one world ";
            char[] arr1 = text.ToCharArray();
            bool find = false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == 'o')
                {
                    if (arr1[i + 1] == 'n')
                    {
                        if (arr1[i + 2] == 'e')
                        {
                            find = true;
                        }
                    }
                }
            }
            Console.WriteLine(find);
        }
        ///<summary>
        ///Дана строка символов, состоящая из цифр от 0 до 9 и пробелов. Группы цифр, разделенные пробелами (одним или несколькими) и не содержащие пробелов внутри себя, будем называть словами. Рассматривая эти слова как числа, определить и напечатать сумму чисел, оканчивающихся на цифры 3 или 4.
        ///</summary>
        static void Htask7()
        {
            string str = "123 456 104 012 345";

            // Разбиваем строку на слова, используя пробелы в качестве разделителей.
            string[] words = str.Split(' ');

            // Итерируемся по словам, проверяя, заканчиваются ли они на цифры 3 или 4.
            int sum = 0;
            foreach (string word in words)
            {
                // Получаем последнюю цифру слова.
                char lastDigit = word[word.Length - 1];

                // Если последняя цифра равна 3 или 4, добавляем слово к сумме.
                if (lastDigit == '3' || lastDigit == '4')
                {
                    sum += int.Parse(word);
                }
            }

            // Выводим сумму.
            Console.WriteLine(sum);
        }

        ///<summary>
        ///Дана строка символов. Группы символов, разделенные пробелами и не содержащие пробелов внутри себя, будем называть словами. Найти количество слов, у которых первый и последний символы совпадают между собой (если можно с комментариями).
        ///</summary>

        static void Htask8()
        {
            string str8 = "bob hob dot rot ror";

            // Разбиваем строку на слова, используя пробелы в качестве разделителей.
            string[] masswords8 = str8.Split(' ');
            int sum8 = 0;

            foreach (string word8 in masswords8)
            {
                char FirstDigits8 = word8[0];
                char LastDigits8 = word8[word8.Length - 1];

                if (FirstDigits8 == LastDigits8)
                {
                    sum8++;
                }
            }

            Console.WriteLine(sum8);

        }
        ///<summary>
        ///Есть строка (любая), нужно удалить из этой строки знаки / и \.
        ///</summary>
        static void Htask9()
        {
            string str9 = Console.ReadLine();
            str9 = str9.Replace('/', ' ');
            str9 = str9.Replace('\\', ' ');
            Console.WriteLine(str9);



        }


        static void Main(string[] args)
        {
            //int[] arr = new int[5];
            //FillArray(arr);
            //OutputArrayHorizontal(arr);
            //OutputArrayVertical(arr);
            //Exmpl02();

            //Практические задания

            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task6();
            //Task8();
            //Task9();
            //Task11();

            //Домашние задания

            //HTask1();
            //HTask2();
            //HTask3();
            //HTask4();
            // Htask5();
            //Htask6();
            //Htask7();
            // Htask8();
            Htask9();
            Console.Read();
        }
       
    }
}
