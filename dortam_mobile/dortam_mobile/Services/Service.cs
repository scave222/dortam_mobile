using dortam_mobile.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.Services
{
	public static class Service
	{
		private static IStorageService _storageService;
		public static IStorageService StorageService
		{
			get { return DependencyService.Get<StorageService>(); }

		}


		private static ILocalDatabaseService _localDatabaseService;
		public static ILocalDatabaseService LocalDatabaseService
		{
			get { return DependencyService.Get<LocalDatabaseService>(); }

		}

		private static Interface.IServiceProvider _serviceProvider;
		public static Interface.IServiceProvider serviceProvider
		{
			get { return DependencyService.Get<ServiceProvider>(); }

		}
	}
}
