using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }
        
        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        ProcessSoundex(name.Substring(1), soundex);
        
        return FormatSoundex(soundex.ToString());
    }

    private static void ProcessSoundex(string name, StringBuilder soundex)
    {
        char previousCode = GetSoundexCode(name[0]);

        for (int i = 1; i < name.Length; i++)
        {
            char currentCode = GetSoundexCode(name[i]);
            if (CanAppendSoundex(currentCode, previousCode, soundex.Length))
            {
                soundex.Append(currentCode);
                previousCode = currentCode;
            }
        }
    }

    private static bool CanAppendSoundex(char currentCode, char previousCode, int soundexLength)
    {
        return currentCode != '0' && currentCode != previousCode && soundexLength < 4;
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return c switch
        {
            'B' or 'F' or 'P' or 'V' => '1',
            'C' or 'G' or 'J' or 'K' or 'Q' or 'S' or 'X' or 'Z' => '2',
            'D' or 'T' => '3',
            'L' => '4',
            'M' or 'N' => '5',
            'R' => '6',
            _ => '0'
        };
    }

    private static string FormatSoundex(string soundex)
    {
        return soundex.PadRight(4, '0').Substring(0, 4);
    }
}
