using Manck.Data;
using Manck.Dto.Autor;
using Manck.Dto.Livro;
using Manck.Models;

namespace Manck.Services.Livro
{
	public interface ILivroInterface
	{
		Task<ResponseModels<List<LivroModels>>> ListarLivros();
		Task<ResponseModels<LivroModels>> BuscarLivroPorId(int IdLivro);
		Task<ResponseModels<List<LivroModels>>> BuscarLivroPorIdAutor(int IdLivroAutor);
		Task<ResponseModels<List<LivroModels>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);

		Task<ResponseModels<List<LivroModels>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
		Task<ResponseModels<List<LivroModels>>> EliminarLivro(int idLivro);
	}

}
