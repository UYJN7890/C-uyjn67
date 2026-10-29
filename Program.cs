using System.Globalization;
using System.Text;

namespace UniversalHelperApp;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var outputPath = Path.Combine(AppContext.BaseDirectory, "saved.txt");

        Console.WriteLine("1. Автомобиль");
        var car = new Car("Toyota", 2022, 2_500_000m);
        car.ShowInfo();
        car.ShowInfo(2022);
        car.ShowInfo(2022, 2_500_000m);

        Console.WriteLine("\n2. Оценка студента");
        Console.WriteLine(Student.CalculateGrade(5));
        Console.WriteLine(Student.CalculateGrade(4, 5));
        Console.WriteLine(Student.CalculateGrade(5, 4, 5));

        Console.WriteLine("\n3. Скидка");
        Console.WriteLine(Discounts.CalculateDiscount(1000m, 10d));
        Console.WriteLine(Discounts.CalculateDiscount(1000m, 100m));

        Console.WriteLine("\n4. Доставка");
        Console.WriteLine(Delivery.CalculateDelivery());
        Console.WriteLine(Delivery.CalculateDelivery(true));
        Console.WriteLine(Delivery.CalculateDelivery(3.5));

        Console.WriteLine("\n5. Книга");
        var book = new Book("Война и мир", "Лев Толстой", 1869);
        book.DisplayBook();
        book.DisplayBook("Лев Толстой");
        book.DisplayBook("Лев Толстой", 1869);

        Console.WriteLine("\n6. Игровые очки");
        Console.WriteLine(GameScore.AddScore(100, 10));
        Console.WriteLine(GameScore.AddScore(100, new BonusPoints(25)));
        Console.WriteLine(GameScore.AddScore(100, 10, 2.5));

        Console.WriteLine("\n7. Сохранение файлов");
        FileSaver.SaveFile(outputPath, "Текстовый файл");
        FileSaver.SaveFile(outputPath, new[] { "Первая строка", "Вторая строка" });
        FileSaver.SaveFile(outputPath, "Текст в UTF-8", Encoding.UTF8);
        Console.WriteLine($"Сохранено: {outputPath}");

        Console.WriteLine("\n8. Объём фигур");
        Console.WriteLine(Geometry.CalculateVolume(3d));
        Console.WriteLine(Geometry.CalculateVolume(2d, 3d, 4d));
        Console.WriteLine(Geometry.CalculateVolume(2d, 5d));

        Console.WriteLine("\n9. Такси");
        Console.WriteLine(Taxi.CalculateFare(10d));
        Console.WriteLine(Taxi.CalculateFare(10d, 5d));
        Console.WriteLine(Taxi.CalculateFare(10d, VehicleClass.Business));

        Console.WriteLine("\n10. Поиск книги");
        var library = new Library(new[] { book, new Book("Преступление и наказание", "Федор Достоевский", 1866) });
        Console.WriteLine(library.SearchBook("Война и мир"));
        Console.WriteLine(library.SearchBook(new AuthorQuery("Лев Толстой")));
        Console.WriteLine(library.SearchBook("Война и мир", "Лев Толстой"));

        Console.WriteLine("\n11. Сортировка");
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { 3, 1, 2 })));
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { 3.2, 1.1, 2.4 })));
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { "груша", "яблоко", "слива" })));

        Console.WriteLine("\n12. Анализ массива");
        Console.WriteLine(ArrayStatistics.Analyze(new[] { 3, 1, 5 }));
        Console.WriteLine(ArrayStatistics.Analyze(new[] { 3.5, 1.5, 5.0 }));
        Console.WriteLine(ArrayStatistics.Analyze((IEnumerable<double>)new List<double> { 2, 8, 4 }));

        Console.WriteLine("\n13. Проверка пароля");
        Console.WriteLine(PasswordValidator.ValidatePassword("Abcdef12"));
        Console.WriteLine(PasswordValidator.ValidatePassword("Abcdef12", 8));
        Console.WriteLine(PasswordValidator.ValidatePassword("Abcdef12!", 8, true));

        Console.WriteLine("\n14. Конвертация валюты");
        Console.WriteLine(CurrencyConverter.ConvertCurrency(100m));
        Console.WriteLine(CurrencyConverter.ConvertCurrency(100m, 90m, 1m));

        Console.WriteLine("\n15. Форматирование даты");
        Console.WriteLine(DateFormatter.FormatDate(DateTime.Now));
        Console.WriteLine(DateFormatter.FormatDate("2026-10-29"));
        Console.WriteLine(DateFormatter.FormatDate(DateTime.Today, TimeSpan.FromHours(14.5)));

        Console.WriteLine("\n16. Уведомления");
        Console.WriteLine(NotificationService.SendNotification("Сообщение"));
        Console.WriteLine(NotificationService.SendNotification("Заголовок", "Сообщение"));
        Console.WriteLine(NotificationService.SendNotification("Заголовок", "Сообщение", "user@example.com"));

        Console.WriteLine("\n17. Сотрудники");
        var employee = EmployeeFactory.CreateEmployee("Анна");
        Console.WriteLine(EmployeeFactory.CreateEmployee("Борис", "Разработчик"));
        Console.WriteLine(EmployeeFactory.CreateEmployee("Вера", "Дизайнер", 120_000m));
        Console.WriteLine(employee);

        Console.WriteLine("\n18. Склад");
        Console.WriteLine(Inventory.UpdateStock(10, 5, StockUpdateMode.Increase));
        Console.WriteLine(Inventory.UpdateStock(10, 5, StockUpdateMode.Decrease));
        Console.WriteLine(Inventory.UpdateStock(25));

        Console.WriteLine("\n19. Математические операции");
        Console.WriteLine(MathLibrary.Calculate(7, 3, MathOperation.Add));
        Console.WriteLine(MathLibrary.Calculate(7.5, 2.5, MathOperation.Subtract));
        Console.WriteLine(MathLibrary.Calculate(7m, 3m, MathOperation.Multiply));
        Console.WriteLine(MathLibrary.Calculate(7m, 2m, MathOperation.Divide));

        Console.WriteLine("\n20. Авторизация");
        Console.WriteLine(Authentication.Login("user", "password"));
        Console.WriteLine(Authentication.Login(new EmailAddress("user@example.com"), "password"));
        Console.WriteLine(Authentication.Login("user", "password", "123456"));

        Console.WriteLine("\n21. Изменение размера изображения");
        Console.WriteLine(ImageResizer.ResizeImage(new ImageSize(800, 600), 400, 300));
        Console.WriteLine(ImageResizer.ResizeImage(new ImageSize(800, 600), 0.5));
        Console.WriteLine(ImageResizer.ResizeImage(new ImageSize(800, 600), 300, 300, true));

        Console.WriteLine("\n22. Стоимость топлива");
        Console.WriteLine(Transport.CalculateFuelCost(100, 8));
        Console.WriteLine(Transport.CalculateFuelCost(100, 8, 60));

        Console.WriteLine("\n23. Итоговая цена");
        Console.WriteLine(ElectronicsStore.CalculateFinalPrice(1000m, 10m));
        Console.WriteLine(ElectronicsStore.CalculateFinalPrice(1000m, 10m, 20m));
        Console.WriteLine(ElectronicsStore.CalculateFinalPrice(1000m, 10m, 20m, 50m));

        Console.WriteLine("\n24. Оценивание студента");
        Console.WriteLine(GradingSystem.EvaluateStudent(5));
        Console.WriteLine(GradingSystem.EvaluateStudent(5, 4));
        Console.WriteLine(GradingSystem.EvaluateStudent(new[] { 5d, 4d, 5d }));

        Console.WriteLine("\n25. Универсальный помощник");
        Console.WriteLine(Helper.Calculate(2, 3, MathOperation.Add));
        Console.WriteLine(Helper.Calculate(2.5, 3.5, MathOperation.Multiply));
        Console.WriteLine(Helper.Format(1234.5m, 2));
        Console.WriteLine(Helper.Format("  пример строки  "));
        Console.WriteLine(Helper.Format(DateTime.Today));
        Console.WriteLine(Helper.Find(new[] { 1, 2, 3 }, 2));
        Console.WriteLine(Helper.Find(new[] { "один", "два" }, "два"));
        Console.WriteLine(Helper.Find("универсальный помощник", "помощник"));
        Helper.Display(car);
        Helper.Display(book);
        Helper.Display(employee);
        Helper.Display(DateTime.Today);
    }
}

internal sealed class Car(string brand, int year, decimal price)
{
    public void ShowInfo() => Console.WriteLine($"Марка: {brand}");
    public void ShowInfo(int releaseYear) => Console.WriteLine($"Марка: {brand}, год: {releaseYear}");
    public void ShowInfo(int releaseYear, decimal carPrice) => Console.WriteLine($"Марка: {brand}, год: {releaseYear}, цена: {carPrice:C}");
    public override string ToString() => $"{brand}, {year}, {price:C}";
}

internal sealed class Student
{
    public static double CalculateGrade(double score) => score;
    public static double CalculateGrade(double first, double second) => (first + second) / 2;
    public static double CalculateGrade(double first, double second, double third) => (first + second + third) / 3;
}

internal static class Discounts
{
    public static decimal CalculateDiscount(decimal price, double percentage)
    {
        if (percentage is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(percentage));
        return price * (decimal)(1 - percentage / 100);
    }

    public static decimal CalculateDiscount(decimal price, decimal fixedAmount) => Math.Max(0, price - fixedAmount);
}

internal static class Delivery
{
    public static decimal CalculateDelivery() => 300m;
    public static decimal CalculateDelivery(bool express) => express ? 700m : CalculateDelivery();
    public static decimal CalculateDelivery(double weightKg)
    {
        if (weightKg < 0) throw new ArgumentOutOfRangeException(nameof(weightKg));
        return 200m + (decimal)weightKg * 50m;
    }
}

internal sealed class Book(string title, string author, int year)
{
    public string Title { get; } = title;
    public string Author { get; } = author;
    public int Year { get; } = year;
    public void DisplayBook() => Console.WriteLine($"Название: {Title}");
    public void DisplayBook(string bookAuthor) => Console.WriteLine($"Название: {Title}, автор: {bookAuthor}");
    public void DisplayBook(string bookAuthor, int publicationYear) => Console.WriteLine($"Название: {Title}, автор: {bookAuthor}, год: {publicationYear}");
    public override string ToString() => $"{Title} — {Author} ({Year})";
}

internal readonly record struct BonusPoints(int Value);

internal static class GameScore
{
    public static int AddScore(int current, int points) => current + points;
    public static int AddScore(int current, BonusPoints bonus) => current + bonus.Value;
    public static int AddScore(int current, int points, double multiplier) => current + (int)Math.Round(points * multiplier);
}

internal static class FileSaver
{
    public static void SaveFile(string path, string text) => File.WriteAllText(path, text);
    public static void SaveFile(string path, string[] lines) => File.WriteAllLines(path, lines);
    public static void SaveFile(string path, string text, Encoding encoding) => File.WriteAllText(path, text, encoding);
}

internal static class Geometry
{
    public static double CalculateVolume(double cubeSide) => Math.Pow(cubeSide, 3);
    public static double CalculateVolume(double length, double width, double height) => length * width * height;
    public static double CalculateVolume(double radius, double cylinderHeight) => Math.PI * radius * radius * cylinderHeight;
}

internal enum VehicleClass { Economy, Comfort, Business }

internal static class Taxi
{
    public static decimal CalculateFare(double distanceKm) => 100m + (decimal)distanceKm * 20m;
    public static decimal CalculateFare(double distanceKm, double waitingMinutes) => CalculateFare(distanceKm) + (decimal)waitingMinutes * 5m;
    public static decimal CalculateFare(double distanceKm, VehicleClass vehicleClass)
    {
        var multiplier = vehicleClass switch { VehicleClass.Comfort => 1.5m, VehicleClass.Business => 2m, _ => 1m };
        return CalculateFare(distanceKm) * multiplier;
    }
}

internal readonly record struct AuthorQuery(string Value);

internal sealed class Library(IEnumerable<Book> books)
{
    private readonly Book[] _books = books.ToArray();
    public IEnumerable<Book> SearchBook(string title) => _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<Book> SearchBook(AuthorQuery author) => _books.Where(book => book.Author.Contains(author.Value, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<Book> SearchBook(string title, string author) => _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
}

internal static class ArrayTools
{
    public static int[] Sort(int[] values) => values.OrderBy(value => value).ToArray();
    public static double[] Sort(double[] values) => values.OrderBy(value => value).ToArray();
    public static string[] Sort(string[] values) => values.OrderBy(value => value, StringComparer.Ordinal).ToArray();
}

internal readonly record struct ArrayAnalysis(double Minimum, double Maximum, double Average);

internal static class ArrayStatistics
{
    public static ArrayAnalysis Analyze(int[] values) => Analyze(values.Select(value => (double)value));
    public static ArrayAnalysis Analyze(double[] values) => Analyze((IEnumerable<double>)values);
    public static ArrayAnalysis Analyze(IEnumerable<double> values)
    {
        var data = values.ToArray();
        if (data.Length == 0) throw new ArgumentException("Массив не должен быть пустым.", nameof(values));
        return new ArrayAnalysis(data.Min(), data.Max(), data.Average());
    }
}

internal static class PasswordValidator
{
    public static bool ValidatePassword(string password) => password.Length >= 6;
    public static bool ValidatePassword(string password, int minimumLength) => password.Length >= minimumLength && password.Any(char.IsDigit);
    public static bool ValidatePassword(string password, int minimumLength, bool requireSpecialCharacter) =>
        password.Length >= minimumLength && password.Any(char.IsDigit) &&
        (!requireSpecialCharacter || password.Any(character => !char.IsLetterOrDigit(character)));
}

internal static class CurrencyConverter
{
    private const decimal FixedRate = 90m;
    public static decimal ConvertCurrency(decimal amount) => amount * FixedRate;
    public static decimal ConvertCurrency(decimal amount, decimal rate, decimal commissionPercent)
    {
        if (rate < 0 || commissionPercent is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(rate));
        return amount * rate * (1 - commissionPercent / 100);
    }
}

internal static class DateFormatter
{
    public static string FormatDate(DateTime date) => date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    public static string FormatDate(string date) => DateTime.Parse(date, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    public static string FormatDate(DateTime date, TimeSpan time) => (date.Date + time).ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
}

internal static class NotificationService
{
    public static string SendNotification(string message) => message;
    public static string SendNotification(string title, string message) => $"{title}: {message}";
    public static string SendNotification(string title, string message, string recipient) => $"Для {recipient} | {title}: {message}";
}

internal sealed record Employee(string Name, string Position, decimal Salary)
{
    public override string ToString() => $"{Name}, {Position}, зарплата {Salary:C}";
}

internal static class EmployeeFactory
{
    public static Employee CreateEmployee(string name) => new(name, "Не указана", 0m);
    public static Employee CreateEmployee(string name, string position) => new(name, position, 0m);
    public static Employee CreateEmployee(string name, string position, decimal salary) => new(name, position, salary);
}

internal enum StockUpdateMode { Increase, Decrease }

internal static class Inventory
{
    public static int UpdateStock(int newQuantity) => ValidateQuantity(newQuantity);
    public static int UpdateStock(int currentQuantity, int amount, StockUpdateMode mode)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
        var updated = mode == StockUpdateMode.Increase ? currentQuantity + amount : currentQuantity - amount;
        return ValidateQuantity(updated);
    }

    private static int ValidateQuantity(int quantity) => quantity >= 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity));
}

internal enum MathOperation { Add, Subtract, Multiply, Divide }

internal static class MathLibrary
{
    public static int Calculate(int first, int second, MathOperation operation) => operation switch
    {
        MathOperation.Add => first + second,
        MathOperation.Subtract => first - second,
        MathOperation.Multiply => first * second,
        MathOperation.Divide when second != 0 => first / second,
        MathOperation.Divide => throw new DivideByZeroException(),
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };

    public static double Calculate(double first, double second, MathOperation operation) => (double)Calculate((decimal)first, (decimal)second, operation);
    public static decimal Calculate(decimal first, decimal second, MathOperation operation) => operation switch
    {
        MathOperation.Add => first + second,
        MathOperation.Subtract => first - second,
        MathOperation.Multiply => first * second,
        MathOperation.Divide when second != 0 => first / second,
        MathOperation.Divide => throw new DivideByZeroException(),
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };
}

internal readonly record struct EmailAddress(string Value);

internal static class Authentication
{
    public static bool Login(string username, string password) => !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
    public static bool Login(EmailAddress email, string password) => email.Value.Contains('@') && !string.IsNullOrWhiteSpace(password);
    public static bool Login(string username, string password, string verificationCode) => Login(username, password) && verificationCode.Length == 6 && verificationCode.All(char.IsDigit);
}

internal readonly record struct ImageSize(int Width, int Height)
{
    public override string ToString() => $"{Width} x {Height}";
}

internal static class ImageResizer
{
    public static ImageSize ResizeImage(ImageSize source, int width, int height)
    {
        ValidateSource(source);
        if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Размеры должны быть положительными.");
        return new ImageSize(width, height);
    }

    public static ImageSize ResizeImage(ImageSize source, double scale)
    {
        ValidateSource(source);
        if (!double.IsFinite(scale) || scale <= 0) throw new ArgumentOutOfRangeException(nameof(scale));
        return new ImageSize(Math.Max(1, (int)Math.Round(source.Width * scale)), Math.Max(1, (int)Math.Round(source.Height * scale)));
    }

    public static ImageSize ResizeImage(ImageSize source, int maxWidth, int maxHeight, bool preserveAspectRatio)
    {
        ValidateSource(source);
        if (maxWidth <= 0 || maxHeight <= 0) throw new ArgumentOutOfRangeException(nameof(maxWidth), "Границы должны быть положительными.");
        if (!preserveAspectRatio) return ResizeImage(source, maxWidth, maxHeight);
        var scale = Math.Min((double)maxWidth / source.Width, (double)maxHeight / source.Height);
        return ResizeImage(source, scale);
    }

    private static void ValidateSource(ImageSize source)
    {
        if (source.Width <= 0 || source.Height <= 0) throw new ArgumentOutOfRangeException(nameof(source));
    }
}

internal static class Transport
{
    public static decimal CalculateFuelCost(double distanceKm, double litersPer100Km) => (decimal)(distanceKm * litersPer100Km / 100);
    public static decimal CalculateFuelCost(double distanceKm, double litersPer100Km, decimal pricePerLiter)
    {
        if (distanceKm < 0 || litersPer100Km < 0 || pricePerLiter < 0) throw new ArgumentOutOfRangeException(nameof(distanceKm));
        return CalculateFuelCost(distanceKm, litersPer100Km) * pricePerLiter;
    }
}

internal static class ElectronicsStore
{
    public static decimal CalculateFinalPrice(decimal price, decimal discountPercent) => ApplyDiscount(price, discountPercent);
    public static decimal CalculateFinalPrice(decimal price, decimal discountPercent, decimal taxPercent) => ApplyDiscount(price, discountPercent) * (1 + taxPercent / 100);
    public static decimal CalculateFinalPrice(decimal price, decimal discountPercent, decimal taxPercent, decimal deliveryCost) =>
        CalculateFinalPrice(price, discountPercent, taxPercent) + deliveryCost;

    private static decimal ApplyDiscount(decimal price, decimal discountPercent)
    {
        if (price < 0 || discountPercent is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(discountPercent));
        return price * (1 - discountPercent / 100);
    }
}

internal static class GradingSystem
{
    public static double EvaluateStudent(double exam) => exam;
    public static double EvaluateStudent(double exam, double quiz) => (exam + quiz) / 2;
    public static double EvaluateStudent(double[] exams)
    {
        if (exams.Length == 0) throw new ArgumentException("Нужен хотя бы один экзамен.", nameof(exams));
        return exams.Average();
    }
}

internal static class Helper
{
    public static int Calculate(int first, int second, MathOperation operation) => MathLibrary.Calculate(first, second, operation);
    public static double Calculate(double first, double second, MathOperation operation) => MathLibrary.Calculate(first, second, operation);
    public static string Format(decimal value, int decimalPlaces) => value.ToString($"N{decimalPlaces}", CultureInfo.InvariantCulture);
    public static string Format(string value) => value.Trim();
    public static string Format(DateTime value) => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    public static int Find(int[] values, int target) => Array.IndexOf(values, target);
    public static int Find(string[] values, string target) => Array.FindIndex(values, value => string.Equals(value, target, StringComparison.OrdinalIgnoreCase));
    public static int Find(string text, string value) => text.IndexOf(value, StringComparison.OrdinalIgnoreCase);
    public static void Display(Car value) => Console.WriteLine(value);
    public static void Display(Book value) => Console.WriteLine(value);
    public static void Display(Employee value) => Console.WriteLine(value);
    public static void Display(DateTime value) => Console.WriteLine(Format(value));
}