using Commom.Providers;

namespace Business.Validators
{
    public interface IDocValidator
    {
        bool ValidateDoc(IDocumentProvider documentProvider);
    }
}
