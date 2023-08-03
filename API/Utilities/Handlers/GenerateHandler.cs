namespace API.Utilities.Handlers;

public static class GenerateHandler
{
    public static string GenerateRandomString(int length = 20)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
    }

    public static int GenerateVa()
    {
        Random random = new Random();
        int va = 0;

        for (int i = 0; i < 10; i++)
        {
            int digit = random.Next(0, 10);
            va = va * 10 + digit;
        }

        return Math.Abs(va);
    }

    public static int GenerateToken()
    {
        Random random = new Random();
        HashSet<int> uniqueDigits = new HashSet<int>();
        while (uniqueDigits.Count < 9)
        {
            int digit = random.Next(0, 9);
            uniqueDigits.Add(digit);
        }

        int generatedOtp = uniqueDigits.Aggregate(0, (acc, digit) => acc * 10 + digit);

        return generatedOtp;
    }
}
