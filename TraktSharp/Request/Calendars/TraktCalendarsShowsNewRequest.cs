﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Calendars {

	internal class TraktCalendarsShowsNewRequest : TraktGetRequest<TraktCalendarsShowsResponse> {

		internal TraktCalendarsShowsNewRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "calendars/shows/new/{start_date}/{days}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Optional; } }

		internal DateTime? StartDate { get; set; }

		internal int? Days { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()},
				{"days", Days.ToString()}
			};
		}

	}

}