using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Nhập số thứ nhất: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập số thứ hai: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nĐang tính toán...\n");

        Task<double> addTask = AddAsync(num1, num2);
        Task<double> subTask = SubtractAsync(num1, num2);
        Task<double> mulTask = MultiplyAsync(num1, num2);
        Task<double> divTask = DivideAsync(num1, num2);

        double addResult = await addTask;
        double subResult = await subTask;
        double mulResult = await mulTask;
        double divResult = await divTask;

        Console.WriteLine($"Cộng: {addResult}");
        Console.WriteLine($"Trừ: {subResult}");
        Console.WriteLine($"Nhân: {mulResult}");
        Console.WriteLine($"Chia: {divResult}");
    }

    static async Task<double> AddAsync(double a, double b)
    {
        await Task.Delay(500); 
        return a + b;
    }

    static async Task<double> SubtractAsync(double a, double b)
    {
        await Task.Delay(500);
        return a - b;
    }

    static async Task<double> MultiplyAsync(double a, double b)
    {
        await Task.Delay(500);
        return a * b;
    }

    static async Task<double> DivideAsync(double a, double b)
    {
        await Task.Delay(500);
        if (b == 0) throw new DivideByZeroException("Không thể chia cho 0.");
        return a / b;
    }
}