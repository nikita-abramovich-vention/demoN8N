namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Калькулятор .NET 8 ===");
        Console.WriteLine();

        while (true)
        {
            try
            {
                Console.Write("Введите первое число (или 'exit' для выхода): ");
                string? input1 = Console.ReadLine();
                
                if (input1?.ToLower() == "exit")
                {
                    Console.WriteLine("До свидания!");
                    break;
                }

                if (!double.TryParse(input1, out double num1))
                {
                    Console.WriteLine("Ошибка: введите корректное число!");
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Введите операцию (+, -, *, /): ");
                string? operation = Console.ReadLine();

                Console.Write("Введите второе число: ");
                string? input2 = Console.ReadLine();

                if (!double.TryParse(input2, out double num2))
                {
                    Console.WriteLine("Ошибка: введите корректное число!");
                    Console.WriteLine();
                    continue;
                }

                double result = operation switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Деление на ноль невозможно!"),
                    _ => throw new InvalidOperationException("Неизвестная операция!")
                };

                Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
                Console.WriteLine();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }
    }
}
