using Core.Models.Domain;
using Core.Models.Repository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EducationGuide.Admin.Authentication
{
	public class UserService
	{
		private readonly ProtectedLocalStorage _protectedLocalStorage;
		private readonly PageContext _pageContext;
        private readonly string _storageKey = "blazorSchoolIdentity";

		public UserService(ProtectedLocalStorage protectedLocalStorage, PageContext pageContext)
		{
			_protectedLocalStorage = protectedLocalStorage;
			_pageContext = pageContext;
        }

		public async Task<UserAuth?> FindUserFromDatabaseAsync(string username, string password)
		{
            var userInDatabase = await _pageContext.Users
                .Where(p => p.Password == password && p.Username == username)
                .FirstOrDefaultAsync();

            var userAuth = new UserAuth();
            if (userInDatabase != null)
            {
                userAuth.Username = userInDatabase.Username;
                userAuth.Password = userInDatabase.Password;
                userAuth.Email = userInDatabase.Email;

				// Convert the comma-separated roles string to a list
				userAuth.Roles = userInDatabase.Roles;

                await PersistUserToBrowserAsync(userAuth);
            }

            return userAuth;

        }

        public async Task PersistUserToBrowserAsync(UserAuth user)
		{
			string userJson = JsonConvert.SerializeObject(user);
			await _protectedLocalStorage.SetAsync(_storageKey, userJson);
		}
		public async Task<UserAuth?> FetchUserFromBrowserAsync()
		{
			try // When Blazor Server is rendering at server side, there is no local storage. Therefore, put an empty try catch to avoid error
			{
				var fetchedUserResult = await _protectedLocalStorage.GetAsync<string>(_storageKey);

				if (fetchedUserResult.Success && !string.IsNullOrEmpty(fetchedUserResult.Value))
				{
					var user = JsonConvert.DeserializeObject<UserAuth>(fetchedUserResult.Value);

					return user;
				}
			}
			catch
			{
			}

			return null;
		}


		public async Task ClearBrowserUserDataAsync() => await _protectedLocalStorage.DeleteAsync(_storageKey);
	}
}
