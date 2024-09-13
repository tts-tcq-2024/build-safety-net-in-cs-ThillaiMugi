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
        ProcessCharSoundex(name, soundex);
        return soundex.ToString().padRight(4, '0').SubString(0,4);
    }

    private static void ProcessCharSoundex(string name, StringBuilder soundex)
    {
        char prevCode = GetSoundexCode(name[0]);
        for (int i = 1; i < name.Length; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (AppendSoundex(code, prevCode, soundex.Length))
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
    }

    private static bool AppendSoundex(char code, char prevCode, int soundexLength)
    {
        return code != '0' && code != prevCode && soundexLength < 4;
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
