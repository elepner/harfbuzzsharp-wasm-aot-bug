using System.Linq;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace blazor9;

public class FontRuler : IFontRuler
{
    private static IFontRuler? _instance = null;

    /// <summary>
    /// An external font ruler can be set here to override the default.
    /// </summary>
    public static IFontRuler Instance
    {
        get => _instance ??= new FontRuler();

        set => _instance = value;
    }



    public string[] AvailableFonts { get; } = SKFontManager.Default.FontFamilies.Where(x =>
        {
            using (var typeFace = SKTypeface.FromFamilyName(x))
            using (var shaper = new SKShaper(typeFace))
                return shaper.Typeface.GetType().Name != null;
        })
        .OrderBy(x => x)
        .ToArray();
}


public interface IFontRuler
{
    string[] AvailableFonts { get; }
}

public class Hello
{
    string World = "Hello World!";
}