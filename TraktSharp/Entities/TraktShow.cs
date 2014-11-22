﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShow {

		public TraktShow() {
			Airs = new TraktShowAirs();
			AvailableTranslations = new List<string>();
			Genres = new List<string>();
			Ids = new TraktShowIds();
			Images = new TraktShowImages();
		}

		[JsonProperty(PropertyName = "airs")]
		public TraktShowAirs Airs { get; set; }

		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslations { get; set; }

		[JsonProperty(PropertyName = "certification")]
		public string Certification { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[JsonProperty(PropertyName = "first_aired")]
		public DateTime? FirstAired { get; set; }

		[JsonProperty(PropertyName = "genres")]
		public IEnumerable<string> Genres { get; set; }

		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktShowIds Ids { get; set; }

		[JsonProperty(PropertyName = "images")]
		public TraktShowImages Images { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

		[JsonProperty(PropertyName = "network")]
		public string Network { get; set; }

		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		[JsonProperty(PropertyName = "runtime")]
		public int? Runtime { get; set; }

		[JsonProperty(PropertyName = "status")]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "trailer")]
		public string Trailer { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		public bool IsPostable() { return !string.IsNullOrEmpty(Title) || (Ids != null && Ids.HasAnyValuesSet()); }

	}

}