﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;
using TraktSharp.Factories;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule {

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByMovieIdAsync(string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) {
			return await MarkUnwatchedAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByMovieIdAsync(int movieId, IntMovieIdType movieIdType) {
			return await MarkUnwatchedAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByShowIdAsync(string showId, StringShowIdType showIdType = StringShowIdType.Auto) {
			return await MarkUnwatchedAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByShowIdAsync(int showId, IntShowIdType showIdType) {
			return await MarkUnwatchedAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByEpisodeIdAsync(string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) {
			return await MarkUnwatchedAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedByEpisodeIdAsync(int episodeId, IntEpisodeIdType episodeIdType) {
			return await MarkUnwatchedAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(TraktMovie movie) {
			return await MarkUnwatchedAsync(new List<TraktMovie> { movie }, null, null);
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(TraktShow show) {
			return await MarkUnwatchedAsync(null, new List<TraktShow> { show }, null);
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(TraktEpisode episode) {
			return await MarkUnwatchedAsync(null, null, new List<TraktEpisode> { episode });
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktMovie> movies) {
			return await MarkUnwatchedAsync(movies, null, null);
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktShow> shows) {
			return await MarkUnwatchedAsync(null, shows, null);
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktEpisode> episodes) {
			return await MarkUnwatchedAsync(null, null, episodes);
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await MarkUnwatchedAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		/// <summary>Remove items from a user's watch history including all watches, scrobbles, and checkins</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await SendAsync(new TraktSyncWatchedRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}