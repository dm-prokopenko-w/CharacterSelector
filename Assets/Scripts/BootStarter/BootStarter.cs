using VContainer.Unity;
using VContainer;
using Game.Character;
using Game.Configs;
using Game.Core;
using Core.UI;

namespace Game.BootStarters
{
    public class BootStarter : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Scoped).As<GameManager, IStartable>();
            builder.Register<UIController>(Lifetime.Scoped);
            builder.Register<SaveManager>(Lifetime.Scoped);
            builder.Register<ConfigsLoader>(Lifetime.Scoped);
            builder.Register<CharacterGenerator>(Lifetime.Scoped).As<CharacterGenerator, IStartable>();
            builder.Register<SceneLoader>(Lifetime.Scoped);
        }
    }
}