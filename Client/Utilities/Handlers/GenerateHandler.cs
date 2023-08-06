namespace Client.Utilities.Handlers;

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

    public static int RandomVa()
    {
        Random random = new Random();
        HashSet<int> uniqueDigits = new HashSet<int>();
        while (uniqueDigits.Count < 5)
        {
            int digit = random.Next(0, 9);
            uniqueDigits.Add(digit);
        }

        int generatedOtp = uniqueDigits.Aggregate(0, (acc, digit) => acc * 10 + digit);

        return generatedOtp;
    }
}
