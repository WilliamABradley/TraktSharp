﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsUpdatesRequest : TraktGetRequest<IEnumerable<TraktShowsUpdatesResponseItem>> {

		internal TraktShowsUpdatesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/updates/{start_date}"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

		internal DateTime? StartDate { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()}
			};
		}

		protected override bool SupportsPagination { get { return true; } }

	}

}