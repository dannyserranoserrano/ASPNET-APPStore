using AppStore.Models.Domain;
using AppStore.Models.DTO;

namespace AppStore.Repositories.Abstract;

public interface ILibroService
{
    bool Add(Libro libro);

    bool Update(Libro libro);

    Libro GetById(int id);

    bool Delete(int id);

    LibroListVm List(int currentPage = 0, string term = "", bool paging = false);

    List<int> GetCategoriaByLibroId(int libroId);
}
