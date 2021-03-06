﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCollectionMoviesResponseItem {

		/// <summary>The UTC date when the item was collected</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}