namespace Translator.Repository.Interface
{
    public interface ITranslatorRepository
    {
        string Translate(string words, string languageTranslateTo);
    }
}