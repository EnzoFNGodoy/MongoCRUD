namespace MongoCRUD.Domain.Helpers;

public static class StringHelper
{
    public static bool HasUpperCase(this string text)
    => text.Any(char.IsUpper);

    public static bool HasLowerCase(this string text)
        => text.Any(char.IsLower);

    public static bool HasNumber(this string text)
        => text.Any(char.IsNumber);

    public static bool HasSpecialChar(this string text)
        => text.Any(char.IsSymbol) ||
        text.Any(char.IsPunctuation);

    public static bool IsEmpty(this string text) =>
        string.IsNullOrEmpty(text) ||
            string.IsNullOrWhiteSpace(text);
}
