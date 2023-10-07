using UnityEngine;
using VContainer;

namespace Game.BootStarters
{
    public class BootStarterGame : BootStarter
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            Debug.Log("Init injects  - BootStarterGame.");
        }
    }
}