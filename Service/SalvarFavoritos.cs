using ProjetoFavoritos.Models;

namespace ProjetoFavoritos.Service
{
	public static void SalvarFavoritos(string caminhoArquivo, List<Favorito> favoritos)
	{
		using (var arquivo = new StreamWriter(caminhoArquivo))
		{
			arquivo.WriteLine("<!DOCTYPE NETSCAPE-Bookmark-file-1>");
			arquivo.WriteLine("<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=UTF-8\">");
			arquivo.WriteLine("<TITLE>Bookmarks</TITLE>");
			arquivo.WriteLine("<H1>Bookmarks</H1>");
			arquivo.WriteLine("<DL><p>");
			arquivo.WriteLine("    <DT><H3 ADD_DATE=\"0\" LAST_MODIFIED=\"0\" PERSONAL_TOOLBAR_FOLDER=\"true\" PROHIBITED=\"false\" CONTENT=\"Bookmarks\" ID=\"1\">");
			arquivo.WriteLine("    <DL><p>");

			foreach (var favorito in favoritos)
			{
				arquivo.WriteLine($"        <DT><A HREF=\"{favorito.Url}\" ADD_DATE=\"0\">{favorito.Nome}</A>");
			}

			arquivo.WriteLine("    </DL><p>");
			arquivo.WriteLine("</DL><p>");
		}
	}
}
