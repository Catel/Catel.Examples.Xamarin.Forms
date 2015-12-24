// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Module.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitMeet
{
    using Catel.IoC;
    using Services;
    using Services.Interfaces;

    /// <summary>
    /// The module
    /// </summary>
    public class Module : IServiceLocatorInitializer
    {
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