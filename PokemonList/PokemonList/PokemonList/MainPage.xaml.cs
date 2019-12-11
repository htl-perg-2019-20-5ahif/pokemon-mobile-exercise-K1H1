using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Text.Json;
using PokemonList.Model;
using System.Net.Http;
using System.Collections.ObjectModel;

using System.Text.Json.Serialization;
namespace PokemonList
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewerS
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{

		private readonly HttpClient client =
			new HttpClient();

		ObservableCollection<Pokemon> PokemonListValue = new ObservableCollection<Pokemon>();
		ObservableCollection<Pokemon> PokemonList
		{
			get => PokemonListValue;
			set
			{
				PokemonListValue = value;
				OnPropertyChanged(nameof(PokemonList));
			}
		}


		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
			GetPokemon();
			
		}

		public async void GetPokemon()
		{

			var pokemonResponse = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/?offset=0&limit=20");
			pokemonResponse.EnsureSuccessStatusCode();
			var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
			var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody);
			PokemonList = pokemons.Results;

		}

		async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			await Navigation.PushModalAsync(new PokemonDetails(e.Item as Pokemon));
		}

	


	}
}
