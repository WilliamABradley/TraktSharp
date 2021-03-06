﻿using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	internal abstract class TraktPostRequest<TResponse, TRequestBody> : TraktRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPostRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Post; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

		protected override void ValidateParameters() {
			if (RequestBody == null) {
				throw new ArgumentException("Request body not set.");
			}
		}

	}

}