using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);

     for (int i = 1; i < nameChars.Length; i++)
        {
            char code = GetSoundexCode(nameChars[i]);
            if (code != '0' && code != prevCode && soundex.Length < 4)
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
        return soundex.ToString().padRight(4, '0').SubString(0,4);
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return switch (c)
        {
            'B' or 'F' or 'p' or 'V' => '1',
            'C' or 'G' or 'J' or 'K' or 'Q' or 'S' or 'X' or 'Z' => '2',
            'D' or 'T' => '3',
            'L' => '4',
            'M' or 'N' => '5',
            'R' => '6',
            => '0'
            };
        }
    }
}
