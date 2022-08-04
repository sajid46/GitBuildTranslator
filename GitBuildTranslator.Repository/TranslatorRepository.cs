using Translator.Repository.Interface;
using Translator.Service.Interface;

namespace Translator.Repository
{
    public class TranslatorRepository: ITranslatorRepository
    {
        private ITranslatorService _service;

        public TranslatorRepository(ITranslatorService service)
        {
            this._service = service;
        }

        public string Translate(string words, string languageTranslateTo)
        {
            return this._service.Translate(words, languageTranslateTo);
        }
    }
}