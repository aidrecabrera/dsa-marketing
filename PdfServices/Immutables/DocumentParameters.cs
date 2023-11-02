using System.Globalization;

namespace Aneta.PdfServices.Immutables;

public struct DocumentParameters
{
    public CultureInfo PhilippinesCulture => new("en-PH");
    public int Margin { get; set; }
    public int FontSize { get; set; }
    public string Font { get; set; }
    public float LineHeight { get; set; }
    public float Border { get; set; }
}