class Program

{


    static string CaesarCipher(string input, int shift)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (char.IsLetter(currentChar))
            {

                char baseChar = char.IsUpper(currentChar)
                                ? (char)(char.IsLetter(currentChar) && currentChar >= 'А' && currentChar <= 'я' ? 'А' : 'A')
                                : (char)(char.IsLetter(currentChar) && currentChar >= 'а' && currentChar <= 'я' ? 'а' : 'a');


                int Size = (baseChar == 'А' || baseChar == 'а') ? 32 : 26;
                int offset = (currentChar - baseChar + shift) % Size;
                if (offset < 0) offset += Size;

                result[i] = (char)(baseChar + offset);
            }
            else
            {

                result[i] = currentChar;
            }
        }

        return new string(result);
    }
    static void Main()
    {
        Console.WriteLine("Введите строку (для шифрования)");
        string input = Console.ReadLine();

        Console.WriteLine("Введите сдвиг (целое число):");
        int shift = int.Parse(Console.ReadLine());


        string encrypted = CaesarCipher(input, shift);
        Console.WriteLine("Зашифрованный текст:");
        Console.WriteLine(encrypted);


        string decrypted = CaesarCipher(encrypted, -shift);
        Console.WriteLine("Дешифрованный текст:");
        Console.WriteLine(decrypted);

        Console.ReadLine();
    }
}