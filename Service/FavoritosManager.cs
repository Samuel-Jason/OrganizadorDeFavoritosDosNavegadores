using ProjetoFavoritos.Models;
using System.Text.RegularExpressions;

namespace ProjetoFavoritos.Service
{
	public class FavoritosManager
	{

		public static List<Favorito> LerFavoritosChrome(string caminhoArquivo)
		{
			var favoritos = new List<Favorito>();
			try
			{
				var html = File.ReadAllText(caminhoArquivo);
				var regex = new Regex(@"<A HREF=""(.*?)"">(.*?)</A>", RegexOptions.IgnoreCase);
				var matches = regex.Matches(html);

				foreach (Match match in matches)
				{
					if (match.Groups.Count >= 3)
					{
						var url = match.Groups[1].Value;
						var nome = match.Groups[2].Value;

						favoritos.Add(new Favorito { Nome = nome, Url = url });
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine($"Arquivo não encontrado: {caminhoArquivo}");
			}
			catch (Exception e)
			{
				Console.WriteLine($"Erro ao ler o arquivo: {e.Message}");
			}

			return favoritos;
		}
	}
}
