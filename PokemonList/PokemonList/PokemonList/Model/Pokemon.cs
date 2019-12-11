using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;

namespace PokemonList.Model
{
	public class Pokemon
	{
		[JsonPropertyName("name")]

		public string Name { get; set; }

		[JsonPropertyName("front_default")]
		public string FrontUrl { get; set; }

		[JsonPropertyName("back_default")]
		public string BackUrl { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("weight")]
		public int Weight { get; set; }

		[JsonPropertyName("abilities")]
		public List<Ability> Abilities { get; set; }

		

	}

	public class Pokemons
	{
		[JsonPropertyName("results")]
		public ObservableCollection<Pokemon> Results { get; set; }
	}
}
