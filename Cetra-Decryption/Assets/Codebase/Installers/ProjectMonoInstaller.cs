using Zenject;

namespace Codebase.Installers
{
    public class ProjectMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<ServicesInstaller>();
        }
    }
}