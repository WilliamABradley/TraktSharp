﻿using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersRequestsApproveRequest : TraktBodylessPostByIdRequest<TraktUsersFollowResponseItem> {

		internal TraktUsersRequestsApproveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/requests/{id}"; } }

	}

}