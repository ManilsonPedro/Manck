using Manck.Models;
using Manck.Dto.Autor;

namespace Manck.Services.Autor
{
	public interface IAutorInterface
	{

		Task<ResponseModels<List<AutorModels>>> ListarAutores();
		Task<ResponseModels<AutorModels>> BuscarAutorPorId(int IdAutor);
		Task<ResponseModels<AutorModels>> BuscarAutorPorIdLivro(int IdLivro);
		Task<ResponseModels<List<AutorModels>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);

		Task<ResponseModels<List<AutorModels>>> EditarAutor(AutorEditarDto autorEdicaoDto);
		Task<ResponseModels<List<AutorModels>>> EliminarAutor(int idAutor);

	}
}
