﻿using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IUserAccountDAO : IBaseEntityDAO <UserAccount>
	{
		/// <summary>
		/// Obtiene una cuenta de usuario por su Email
		/// </summary>
		/// <param name="email">Email.</param>
		/// <returns>La cuenta de usuario.</returns>
		UserAccount FindByEmail (string email);

	}
}

