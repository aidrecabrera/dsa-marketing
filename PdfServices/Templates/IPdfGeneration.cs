using QuestPDF.Fluent;
namespace Aneta.PdfServices.Templates;
public interface IPdfGeneration
{
    Document RenderPdf();
}