﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	internal abstract class TraktDeleteByUsernameRequest : TraktDeleteRequest {

		protected TraktDeleteByUsernameRequest(TraktClient client) : base(client) { }

		internal string Username { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"username", Username}
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
		}

	}

}