using System.Linq;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace blazor9
{

    public class FontRuler : IFontRuler
    {
        /// <summary>
        /// An external font ruler can be set here to override the default.
        /// </summary>
        public static IFontRuler Instance { get; set; } = new FontRuler();



        public string[] AvailableFonts { get; } = SKFontManager.Default.FontFamilies.Where(x =>
            {
                using (var typeFace = SKTypeface.FromFamilyName(x))
                using (var shaper = new SKShaper(typeFace))
                {
                    shaper.Shape("ABCDEFGHIJKLMNOPQRSTUWXYZ", new SKPaint());
                    return true;
                }
                
            })
            .OrderBy(x => x)
            .ToArray();
    }


    public interface IFontRuler
    {

        string[] AvailableFonts { get; }
    }
}
