using Exiled.API.Features;
using SCPSLplugin;

using Handlers = Exiled.Events.Handlers;

namespace exiledPlugin
{
    public class Plugin : Plugin<Exiled.CreditTags.Config>
    {
        public string generateSeed()
        {
            return GetType().Assembly.ManifestModule.ModuleVersionId.ToString();
        }
        private EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            base.OnEnabled();
            string seed = generateSeed();

            Log.Info(string.Format("the server is based, restart seed: {0}", seed));

            EventHandlers = new EventHandlers(this);

            Handlers.Player.Joined += EventHandlers.OnPlayerJoin;
            Handlers.Player.Died += EventHandlers.OnPlayerDied;
            Handlers.Map.Decontaminating += EventHandlers.OnDecontamination;
            Handlers.Map.GeneratorActivated += EventHandlers.OnGeneratorActivated;
            Handlers.Warhead.Detonating += EventHandlers.OnWarheadDetonation;
            Handlers.Warhead.Starting += EventHandlers.OnStartingWarhead;
            Handlers.Warhead.Stopping += EventHandlers.OnStoppingWarhead;

        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Log.Info("the plugin is no more based");

            Handlers.Player.Joined -= EventHandlers.OnPlayerJoin;
        }
    }
}