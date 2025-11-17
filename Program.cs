using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BadCalcVeryBad
{
    // CAMBIO: Clase U → CalculatorHistory (nombre descriptivo)
    // CAMBIO: ArrayList → List<string> (más moderno y type-safe)
    // CAMBIO: Campos privados con propiedades públicas
    public static class CalculatorHistory
    {
        private static readonly List<string> operations = new List<string>();
        public static IReadOnlyList<string> Operations => operations;
        public static int OperationCount { get; private set; }

        public static void AddOperation(string operation)
        {
            operations.Add(operation);
            OperationCount++;
        }
    }

    // Clase Calculator: refactorizada desde ShoddyCalc
    // Eliminados campos innecesarios y métodos mejorados
    public static class Calculator
    {
        // Método Calculate: calcula operaciones aritméticas básicas
        public static double Calculate(string firstNumber, string secondNumber, string operation)
        {
            double numberA = ParseNumber(firstNumber);
            double numberB = ParseNumber(secondNumber);

            // Switch para operaciones aritméticas
            switch (operation)
            {
                case "+": return numberA + numberB;
                case "-": return numberA - numberB;
                case "*": return numberA * numberB;
                case "/":
                    // Validación de división por cero
                    if (Math.Abs(numberB) < 0.0001)
                    {
                        Console.WriteLine("Error: División por cero");
                        return 0;
                    }
                    return numberA / numberB;
                case "^":
                    return Math.Pow(numberA, numberB);
                case "%":
                    // Validación de módulo por cero
                    if (Math.Abs(numberB) < 0.0001)
                    {
                        Console.WriteLine("Error: Módulo por cero");
                        return 0;
                    }
                    return numberA % numberB;
                default:
                    return 0;
            }
        }

        // Método de parsing seguro usando TryParse
        private static double ParseNumber(string input)
        {
            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            return 0;
        }
    }

   

    // Clase Program: punto de entrada de la aplicación
    internal static class Program
    {
        private static void Main(string[] args)
        {
            bool running = true;
            
            while (running)
            {
                Console.WriteLine("\n=== CALCULADORA ===");
                Console.WriteLine("1) Suma  2) Resta  3) Multiplicación  4) División");
                Console.WriteLine("5) Potencia  6) Módulo  7) Raíz cuadrada  9) Historial  0) Salir");
                Console.Write("Opción: ");
                var option = Console.ReadLine();
                
                if (option == "0")
                {
                    running = false;
                    continue;
                }

                if (option == "9")
                {
                    ShowHistory();
                    continue;
                }

                if (option == "8")
                {
                    Console.WriteLine("Función no disponible");
                    continue;
                }

                string firstInput;
                string secondInput = "0";
                string operation = GetOperationSymbol(option);

                if (option == "7")
                {
                    Console.Write("Número: ");
                    firstInput = Console.ReadLine();
                }
                else
                {
                    Console.Write("Primer número: ");
                    firstInput = Console.ReadLine();
                    Console.Write("Segundo número: ");
                    secondInput = Console.ReadLine();
                }

                double result;
                
                if (option == "7")
                {
                    double number = ParseNumber(firstInput);
                    // Validación de números negativos
                    if (number < 0)
                    {
                        Console.WriteLine("Error: No se puede calcular raíz cuadrada de número negativo");
                        continue;
                    }
                    result = Math.Sqrt(number);
                }
                else
                {
                    result = Calculator.Calculate(firstInput, secondInput, operation);
                }

                Console.WriteLine($"\nResultado: {result:F4}");
                string historyEntry = option == "7" 
                    ? $"√{firstInput} = {result:F4}"
                    : $"{firstInput} {operation} {secondInput} = {result:F4}";
                
                CalculatorHistory.AddOperation(historyEntry);
                
                // Guardar historial en archivo
                try
                {
                    File.AppendAllText("history.txt", historyEntry + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Advertencia: No se pudo guardar el historial - {ex.Message}");
                }
            }
        }

        // Convierte string a double, acepta formato europeo
        private static double ParseNumber(string input)
        {
            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            return 0;
        }

        // Obtiene el símbolo de operación según la opción del menú
        private static string GetOperationSymbol(string option)
        {
            return option switch
            {
                "1" => "+",
                "2" => "-",
                "3" => "*",
                "4" => "/",
                "5" => "^",
                "6" => "%",
                _ => ""
            };
        }

        // Muestra el historial de operaciones
        private static void ShowHistory()
        {
            Console.WriteLine("\n=== HISTORIAL DE OPERACIONES ===");
            if (CalculatorHistory.Operations.Count == 0)
            {
                Console.WriteLine("No hay operaciones en el historial");
            }
            else
            {
                for (int i = 0; i < CalculatorHistory.Operations.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {CalculatorHistory.Operations[i]}");
                }
            }
        }
    }
}
