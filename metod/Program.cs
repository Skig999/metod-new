//Методы
using System;
using System.Linq;

class Program
{
    // 1. Сумма большего и меньшего из 3 чисел
    static double SumMinMax(double a, double b, double c)
    {
        double max = Math.Max(a, Math.Max(b, c));    //находит максимальное значение среди трёх чисел
        double min = Math.Min(a, Math.Min(b, c));
        return max + min;
    }

    // 2. Число на отрезке [2, n] с максимальной суммой делителей
    static int SumDivisors(int x)
    {
        int sum = 0;
        for (int i = 1; i <= x; i++)    //Перебирает все числа от 1 до x  
            if (x % i == 0) sum += i;   //Если i делит x без остатка (x % i == 0), добавляет i к сумме
        return sum;                     
    }

    static int MaxDivisorSum(int n)
    {
        int best = 2, bestSum = SumDivisors(2);   //Начинает с числа 2: запоминает его и сумму его делителей
        for (int i = 3; i <= n; i++)              //Проходит по всем числам от 3 до n, для каждого считает сумму делителей
        { 
            int s = SumDivisors(i);
            if (s > bestSum) { bestSum = s; best = i; }   //Если у текущего числа сумма делителей больше, чем у «лучшего» на данный момент, обновляет «лучшее» число и его сумму
        }
        return best;
    }

    // 3. Проверка: три числа взаимно простые
    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }  //Реализует алгоритм, пока b не станет нулём, заменяет пару (a, b) на (b, a % b)
        return a;
    }

    static bool AreCoprime(int a, int b, int c)  //находит первых двух чисел: Gcd(a, b)
    {                                            //Потом находит этого результата с третьим числом: Gcd(Gcd(a, b), c)
        return Gcd(Gcd(a, b), c) == 1;           //Если итог равен 1, числа взаимно просты
    }

    // 4. Среднее геометрическое модулей и среднее арифметическое пар
    static double GeometricMeanAbs(double a, double b, double c)
    {
        return Math.Pow(Math.Abs(a) * Math.Abs(b) * Math.Abs(c), 1.0 / 3);   //Берёт модули всех трёх чисел, чтобы избежать проблем с отрицательными значениями
    }                                                                        //Перемножает их, и возводит результат в степень 1/3

    static double[] ArithmeticMeansOfPairs(double a, double b, double c)
    {
        return new double[] { (a + b) / 2, (a + c) / 2, (b + c) / 2 };   //Считает среднее арифметическое
    }

    // 5. След матрицы
    static double Trace(double[,] m) //сумма элементов на главной диагонали
    {
        double sum = 0;
        for (int i = 0; i < m.GetLength(0); i++)   //Цикл идёт по индексам i от 0 до размера матрицы, суммируя m[i, i]
            sum += m[i, i];                        //только для квадратных матриц
        return sum;
    }

    // Ввод матрицы
    static double[,] ReadMatrix(string name, int size)
    {
        double[,] m = new double[size, size];
        Console.WriteLine($"Введите матрицу {name} ({size}x{size}):"); //Для каждой строки просит пользователя ввести числа через пробел
        for (int i = 0; i < size; i++)   //Разбивает строку на части, убирает пустые элементы и преобразует в double
        {
            var row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);  
            for (int j = 0; j < size; j++)
                m[i, j] = double.Parse(row[j]);
        }
        return m;
    }

    static void Main()
    {
        // --- Задание 1 ---
        Console.WriteLine("=== 1. Сумма большего и меньшего из 3 чисел ===");
        Console.Write("Введите 3 числа через пробел: ");
        var p1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);  //StringSplitOptions.RemoveEmptyEntries - задаёт поведение метода при обработке результатов разделения
        double a1 = double.Parse(p1[0]), b1 = double.Parse(p1[1]), c1 = double.Parse(p1[2]);
        Console.WriteLine($"Сумма min и max = {SumMinMax(a1, b1, c1)}");

        // --- Задание 2 ---
        Console.WriteLine("\n=== 2. Число на [2, n] с максимальной суммой делителей ===");
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Число с максимальной суммой делителей: {MaxDivisorSum(n)}");

        // --- Задание 3 ---
        Console.WriteLine("\n=== 3. Проверка взаимной простоты ===");
        Console.Write("Введите 3 целых числа через пробел: ");
        var p3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int a3 = int.Parse(p3[0]), b3 = int.Parse(p3[1]), c3 = int.Parse(p3[2]);
        Console.WriteLine(AreCoprime(a3, b3, c3) ? "Взаимно простые" : "Не взаимно простые");

        // --- Задание 4 ---
        Console.WriteLine("\n=== 4. Среднее геометрическое модулей и средние арифметические пар ===");
        Console.Write("Введите 3 действительных числа через пробел: ");
        var p4 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double a4 = double.Parse(p4[0]), b4 = double.Parse(p4[1]), c4 = double.Parse(p4[2]);
        Console.WriteLine($"Среднее геометрическое модулей: {GeometricMeanAbs(a4, b4, c4):F4}");
        var means = ArithmeticMeansOfPairs(a4, b4, c4);
        Console.WriteLine($"Средние арифметические пар: (a,b)={means[0]}, (a,c)={means[1]}, (b,c)={means[2]}");

        // --- Задание 5 ---
        Console.WriteLine("\n=== 5. Таблица y = c*x^2 + d ===");
        Console.Write("Размер матрицы A: ");
        int nA = int.Parse(Console.ReadLine());
        double[,] A = ReadMatrix("A", nA);

        Console.Write("Размер матрицы B: ");
        int nB = int.Parse(Console.ReadLine());
        double[,] B = ReadMatrix("B", nB);

        double cCoef = Trace(A);
        double dCoef = Trace(B);
        Console.WriteLine($"c = след(A) = {cCoef}, d = след(B) = {dCoef}");
        Console.WriteLine("x\ty");

        for (double x = 0; x <= 1.0001; x += 0.1)
        {
            double y = cCoef * x * x + dCoef;
            Console.WriteLine($"{x:F1}\t{y:F4}");
        }

        Console.ReadLine();
    }
}