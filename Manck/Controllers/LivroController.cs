using Manck.Dto.Autor;
using Manck.Dto.Livro;
using Manck.Models;
using Manck.Services.Autor;
using Manck.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manck.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LivroController : ControllerBase
	{

		private readonly ILivroInterface _livroInterface;
		public LivroController(ILivroInterface autorInterface)
		{
			_livroInterface = autorInterface;
		}

		[HttpGet("ListarLivros")]
		public async Task<ActionResult<ResponseModels<List<LivroModels>>>> ListarLivros()
		{
			var autores = await _livroInterface.ListarLivros();
			return autores;
		}

		[HttpGet("BuscarLivroPorId")]
		public async Task<ActionResult<ResponseModels<LivroModels>>> BuscarLivroPorId(int IdLivro)
		{
			var livro = await _livroInterface.BuscarLivroPorId(IdLivro);
			return livro;
		}

		[HttpGet("BuscarLivroPorIdAutor{IdLivroAutor}")]
		public async Task<ActionResult<ResponseModels<LivroModels>>> BuscarLivroPorIdAutor(int IdLivroAutor)
		{
			var livro = await _livroInterface.BuscarLivroPorIdAutor(IdLivroAutor);
			return Ok(livro);
		}

		[HttpPost("CriarLivro")]
		public async Task<ActionResult<ResponseModels<List<LivroModels>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
		{
			var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
			return Ok(livro);
		}

		[HttpPut("EditarLivro")]
		public async Task<ActionResult<ResponseModels<List<LivroModels>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
		{
			var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
			return Ok(livros);
		}

		[HttpDelete("EliminarLivro")]
		public async Task<ActionResult<ResponseModels<List<LivroModels>>>> EliminarLivro(int Idlivro)
		{
			var livros = await _livroInterface.EliminarLivro(Idlivro);
			return Ok(livros);
		}
	}
}
