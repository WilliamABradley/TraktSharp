﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktEpisode"/> instances</summary>
	public static class TraktEpisodeFactory {

		/// <summary>Create an instance of <see cref="TraktEpisode"/> from an ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static TraktEpisode FromId(string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) { return FromId<TraktEpisode>(episodeId, episodeIdType); }

		/// <summary>Create an instance of a <see cref="TraktEpisode"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) where T : TraktEpisode {
			if (string.IsNullOrEmpty(episodeId)) {
				throw new ArgumentException("episodeId not set", "episodeId");
			}

			if (episodeIdType == StringEpisodeIdType.Auto) {
				if (episodeId.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase)) {
					episodeIdType = StringEpisodeIdType.Imdb;
				} else {
					throw new ArgumentException("Unable to detect id type", "episodeIdType");
				}
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktEpisodeIds();

			switch (episodeIdType) {
				case StringEpisodeIdType.Imdb:
					ret.Ids.Imdb = episodeId;
					break;
				default:
					throw new ArgumentOutOfRangeException("episodeIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktEpisode"/> from an ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static TraktEpisode FromId(int episodeId, IntEpisodeIdType episodeIdType) { return FromId<TraktEpisode>(episodeId, episodeIdType); }

		/// <summary>Create an instance of a <see cref="TraktEpisode"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int episodeId, IntEpisodeIdType episodeIdType) where T : TraktEpisode {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktEpisodeIds();

			switch (episodeIdType) {
				case IntEpisodeIdType.Trakt:
					ret.Ids.Trakt = episodeId;
					break;
				case IntEpisodeIdType.Tvdb:
					ret.Ids.Tvdb = episodeId;
					break;
				case IntEpisodeIdType.Tmdb:
					ret.Ids.Tmdb = episodeId;
					break;
				case IntEpisodeIdType.TvRage:
					ret.Ids.TvRage = episodeId;
					break;
				default:
					throw new ArgumentOutOfRangeException("episodeIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktEpisode"/> from a season number and episode number</summary>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <returns>See summary</returns>
		public static TraktEpisode FromSeasonAndEpisodeNumber(int seasonNumber, int episodeNumber) { return FromSeasonAndEpisodeNumber<TraktEpisode>(seasonNumber, episodeNumber); }

		/// <summary>Create an instance of a <see cref="TraktEpisode"/> subclass from a season number and episode number</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <returns>See summary</returns>
		public static T FromSeasonAndEpisodeNumber<T>(int seasonNumber, int episodeNumber) where T : TraktEpisode {
			var ret = Activator.CreateInstance<T>();
			ret.Season = seasonNumber;
			ret.Number = episodeNumber;
			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> instances from a collecion of IDs</summary>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktEpisode> FromIds(IEnumerable<string> episodeIds, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) {
			return episodeIds == null ? null : episodeIds.Select(episodeId => FromId<TraktEpisode>(episodeId, episodeIdType));
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<string> episodeIds, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) where T : TraktEpisode {
			return episodeIds == null ? null : episodeIds.Select(episodeId => FromId<T>(episodeId, episodeIdType));
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> instances from a collecion of IDs</summary>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktEpisode> FromIds(IEnumerable<int> episodeIds, IntEpisodeIdType episodeIdType) {
			return episodeIds == null ? null : episodeIds.Select(episodeId => FromId<TraktEpisode>(episodeId, episodeIdType));
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <param name="episodeIdType">the episode ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> episodeIds, IntEpisodeIdType episodeIdType) where T : TraktEpisode {
			return episodeIds == null ? null : episodeIds.Select(episodeId => FromId<T>(episodeId, episodeIdType));
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> instances from a season number and a collecion of episode numbers</summary>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumbers">A collection of episode numbers</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktEpisode> FromSeasonAndEpisodeNumbers(int seasonNumber, IEnumerable<int> episodeNumbers) {
			return episodeNumbers == null ? null : episodeNumbers.Select(number => FromSeasonAndEpisodeNumber<TraktEpisode>(seasonNumber, number));
		}

		/// <summary>Create an collection of <see cref="TraktEpisode"/> subclass instances from a season number and a collecion of episode numbers</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktEpisode"/> to be created</typeparam>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumbers">A collection of episode numbers</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromSeasonAndNumbers<T>(int seasonNumber, IEnumerable<int> episodeNumbers) where T : TraktEpisode {
			return episodeNumbers == null ? null : episodeNumbers.Select(number => FromSeasonAndEpisodeNumber<T>(seasonNumber, number));
		}

	}

}