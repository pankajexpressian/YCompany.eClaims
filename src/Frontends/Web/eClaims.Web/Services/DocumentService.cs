using System.Net.Http;

namespace eClaims.Web.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _httpClient;

        public DocumentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
