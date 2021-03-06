﻿using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response.Scrobble {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktScrobbleMovieResponse {

		/// <summary>The action associated with this scrobble</summary>
		[JsonIgnore]
		public TraktScrobbleAction Action { get; set; }

		[JsonProperty(PropertyName = "action")]
		private string ActionString { get { return TraktEnumHelper.GetDescription(Action); } }

		/// <summary>The user's current playback progress through this item as a percentage between 0 and 100</summary>
		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		/// <summary>Indicators showing which connected social networks the action was published to</summary>
		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}