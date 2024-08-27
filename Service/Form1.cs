// Form1.cs
using ProjetoFavoritos.Models;
using ProjetoFavoritos.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class Form1 : Form
{
	public List<Favorito> favoritos;
	public string caminhoArquivoFavoritos = @"C:\Users\samue\Desktop\PythonProj\Projeto\favoritosDoChrome.html"; // Atualize este caminho

	public Form1()
	{
		InitializeComponent();
		favoritos = FavoritosManager.LerFavoritosChrome(caminhoArquivoFavoritos);
		CarregarFavoritos();
	}

	public void CarregarFavoritos()
	{
		listBoxFavoritos.Items.Clear();
		foreach (var favorito in favoritos)
		{
			listBoxFavoritos.Items.Add($"{favorito.Nome} ({favorito.Url})");
		}
	}

	public void btnEditarFavorito_Click(object sender, EventArgs e)
	{
		if (listBoxFavoritos.SelectedIndex >= 0)
		{
			var index = listBoxFavoritos.SelectedIndex;
			var favorito = favoritos[index];

			var novoNome = Microsoft.VisualBasic.Interaction.InputBox("Novo nome para o favorito:", "Editar Nome", favorito.Nome);
			if (!string.IsNullOrEmpty(novoNome))
			{
				var novaUrl = Microsoft.VisualBasic.Interaction.InputBox("Nova URL para o favorito:", "Editar URL", favorito.Url);
				if (!string.IsNullOrEmpty(novaUrl))
				{
					favoritos[index] = new Favorito { Nome = novoNome, Url = novaUrl };
					CarregarFavoritos();
				}
			}
		}
	}

	public void btnSalvarAlteracoes_Click(object sender, EventArgs e)
	{
		FavoritosManager.SalvarFavoritos("favoritos_atualizados.html", favoritos);
		MessageBox.Show("Alterações salvas com sucesso!");
	}
}
