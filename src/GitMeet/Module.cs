using Catel.IoC;
using GitMeet.Services;
using GitMeet.Services.Interfaces;

namespace GitMeet
{
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