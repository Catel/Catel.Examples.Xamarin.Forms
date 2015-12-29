// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceLocatorInitializer.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitMeet
{
    using Catel.IoC;
    using Services;
    using Services.Interfaces;

    /// <summary>
    /// The service locator initializer.
    /// </summary>
    public class ServiceLocatorInitializer : IServiceLocatorInitializer
    {
        /// <summary>
        /// The current <see cref="IServiceLocatorInitializer"/>.
        /// </summary>
        private static IServiceLocatorInitializer _current;

        /// <summary>
        /// 
        /// </summary>
        private ServiceLocatorInitializer()
        {
        }

        /// <summary>
        /// Gets the current <see cref="IServiceLocatorInitializer"/>.
        /// </summary>
        public static IServiceLocatorInitializer Current => _current ?? (_current = new ServiceLocatorInitializer());

        /// <summary>
        /// The initialize method.
        /// </summary>
        /// <param name="serviceLocator">
        /// The service locator.
        /// </param>
        public void Initialize(IServiceLocator serviceLocator)
        {
            serviceLocator.RegisterType<ICredentialStore, CredentialStore>();
            serviceLocator.RegisterType<IGitterService, GitterService>();
        }
    }
}