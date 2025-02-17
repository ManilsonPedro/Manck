using Manck.Dto.Autor;
using Manck.Models;
using Manck.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manck.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutorController : ControllerBase
	{
		private readonly IAutorInterface _autorInterface;
		public AutorController(IAutorInterface autorInterface)
		{
			_autorInterface = autorInterface;	
		}

		[HttpGet("ListarAutores")]
		public async Task<ActionResult<ResponseModels<List<AutorModels>>>> ListarAutores()
		{
			var autores= await _autorInterface.ListarAutores();
			return autores;
		}

		[HttpGet("BuscarAutorPorId")]
		public async Task<ActionResult<ResponseModels<AutorModels>>> BuscarAutorPorId( int IdAutor)
		{
			var autor = await _autorInterface.BuscarAutorPorId(IdAutor);
			return autor;
		}

		[HttpGet("BuscarAutorPorIdLivro{IdLivro}")]
		public async Task<ActionResult<ResponseModels<AutorModels>>> BuscarAutorPorIdLivro(int IdLivro)
		{
			var autor = await _autorInterface.BuscarAutorPorIdLivro(IdLivro);
			return Ok(autor);
		}

		[HttpPost("CriarAutor")]
		public async Task<ActionResult<ResponseModels<List<AutorModels>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto) 
		{
			var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
			return Ok(autores);
		}

		[HttpPut("EditarAutor")]
		public async Task<ActionResult<ResponseModels<List<AutorModels>>>> EditarAutor(AutorEditarDto autorEditarDto)
		{
			var autores = await _autorInterface.EditarAutor(autorEditarDto);
			return Ok(autores);
		}

		[HttpDelete("EliminarAutor")]
		public async Task<ActionResult<ResponseModels<List<AutorModels>>>> EliminarAutor(int Idautor)
		{
			var autores = await _autorInterface.EliminarAutor(Idautor);
			return Ok(autores);
		}



	}
}
