namespace Akb_Bootcamp_Week1.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Metni küçük harfe çevir
            input = input.ToLower();

            // Boşluklara göre kelimelere ayır
            string[] words = input.Split(' ');

            // Her kelimenin ilk harfini büyük yap
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    char[] letters = words[i].ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    words[i] = new string(letters);
                }
            }

            // Büyük harf yapılmış kelimeleri birleştir
            return string.Join(" ", words);
        }
    }

}
