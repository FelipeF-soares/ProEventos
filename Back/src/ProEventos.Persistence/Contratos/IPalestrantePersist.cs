using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        // Palestrantes

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includePalestrante);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrante);
        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includePalestrante);
    }
}