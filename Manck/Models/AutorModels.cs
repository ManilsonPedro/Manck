using System.Text.Json.Serialization;

namespace Manck.Models
{
	public class AutorModels
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string SobreNome { get; set; }
		[JsonIgnore]
		public ICollection<LivroModels> Livro {  get; set; }	
	
	}
}
