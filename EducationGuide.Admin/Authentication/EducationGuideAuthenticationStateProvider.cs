using Core.Models.Domain;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace EducationGuide.Admin.Authentication
{
	public class EducationGuideAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
	{
		private readonly UserService _userService;
		private UserAuth CurrentUser { get; set; }
		public EducationGuideAuthenticationStateProvider(UserService userService)
		{
			_userService = userService;
			AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
		}
		public async Task LoginAsync(string username, string password)
		{
			var principal = new ClaimsPrincipal();
			var user = await _userService.FindUserFromDatabaseAsync(username, password);
			CurrentUser = user;

			if (user is not null)
			{
				principal = user.ToClaimsPrincipal();
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var principal = new ClaimsPrincipal();
			var user = await _userService.FetchUserFromBrowserAsync();

			if (user is not null)
			{
				var authenticatedUser = await _userService.FindUserFromDatabaseAsync(user.Username, user.Password);

				CurrentUser = authenticatedUser;
				if (authenticatedUser is not null)
				{
					principal = authenticatedUser.ToClaimsPrincipal();

				}
			}

			return new(principal);
		}

		public async Task LogoutAsync()
		{
			await _userService.ClearBrowserUserDataAsync();
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
		}


		private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
		{
			var authenticationState = await task;

			if (authenticationState is not null)
			{
				CurrentUser = UserAuth.FromClaimsPrincipal(authenticationState.User);
			}
		}

		public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

	}
}
