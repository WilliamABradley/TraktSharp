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

		/// <summary>Rate one or more items</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByMovieIdAsync(string movieId, StringMovieIdType movieIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, movieIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByMovieIdAsync(int movieId, IntMovieIdType movieIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, movieIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByShowIdAsync(string showId, StringShowIdType showIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, showIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByShowIdAsync(int showId, IntShowIdType showIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, showIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByEpisodeIdAsync(string episodeId, StringEpisodeIdType episodeIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, episodeIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsByEpisodeIdAsync(int episodeId, IntEpisodeIdType episodeIdType, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, episodeIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktMovieWithRatingsMetadata movie) {
			return await AddRatingsAsync(new List<TraktMovieWithRatingsMetadata> { movie }, null, null);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktShowWithRatingsMetadata show) {
			return await AddRatingsAsync(null, new List<TraktShowWithRatingsMetadata> { show }, null);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktEpisodeWithRatingsMetadata episode) {
			return await AddRatingsAsync(null, null, new List<TraktEpisodeWithRatingsMetadata> { episode });
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies) {
			return await AddRatingsAsync(movies, null, null);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktShowWithRatingsMetadata> shows) {
			return await AddRatingsAsync(null, shows, null);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) {
			return await AddRatingsAsync(null, null, episodes);
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddRatingsAsync(
				TraktMovieFactory.FromIds<TraktMovieWithRatingsMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithRatingsMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithRatingsMetadata>(episodeIds));
		}

		/// <summary>Rate one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies, IEnumerable<TraktShowWithRatingsMetadata> shows, IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) {
			return await SendAsync(new TraktSyncRatingsAddRequest(Client) {
				RequestBody = new TraktSyncRatingsAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}