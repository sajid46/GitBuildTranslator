namespace Translator.Service.Interface
{
    public interface ITranslatorService
    {
        string Translate(string words, string languageTranslateTo);
    }
}