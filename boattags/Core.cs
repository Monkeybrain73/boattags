#nullable enable
using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace boattags
{
    public sealed class Core : ModSystem
    {
        private Harmony? _harmony;

        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {
            _harmony = new Harmony("boattags_deconstruct_protect");
            _harmony.PatchAll(typeof(Core).Assembly);
            base.Start(api);
        }

        public override void Dispose()
        {
            _harmony?.UnpatchAll("boattags_deconstruct_protect");
            base.Dispose();
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.Logger.Notification("Server Loaded " + Lang.Get("boattags:hello"));
             base.StartServerSide(api);
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            api.Logger.Notification("Client Loaded: " + Lang.Get("boattags:hello"));
            base.StartClientSide(api);
        }

    }
}
