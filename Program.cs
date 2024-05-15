using System.Diagnostics;

namespace dz_processes
{
    internal class Program
    {
        static void ShowProcesses()
        {
            Console.WriteLine("Список запущенных процессов:");
            foreach (var process in Process.GetProcesses().OrderBy(p => p.ProcessName))
            {
                Console.WriteLine($"{process.ProcessName} (ID: {process.Id})");
            }
        }

        static void KillProcessById()
        {
            Console.Write("Введите ID процесса для завершения: ");
            if (int.TryParse(Console.ReadLine(), out int processId))
            {
                var processToKill = Process.GetProcesses().FirstOrDefault(p => p.Id == processId);
                if (processToKill != null)
                {
                    processToKill.Kill();
                    Console.WriteLine($"Процесс {processToKill.ProcessName} успешно завершен.");
                }
                else
                {
                    Console.WriteLine("Процесс с указанным ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID процесса.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать список процессов");
            Console.WriteLine("2. Завершить процесс по ID");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ShowProcesses();
                        break;
                    case 2:
                        KillProcessById();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}
