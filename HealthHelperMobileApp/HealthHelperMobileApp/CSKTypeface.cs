using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp
{
    static class CSKTypeface
    {
        public static SKTypeface ToSKTypeface(this string text)
        {
            for (int i = 0; i <= text.Length - 1; i++)
            {
                if (char.IsWhiteSpace(text[i])) continue;
                if (char.IsNumber(text[i])) continue;
                if (char.IsSymbol(text[i])) continue;
                return SKFontManager.Default.MatchCharacter(text[i]);
            }
            return SKFontManager.Default.MatchCharacter(text[0]);
        }
    }
}
