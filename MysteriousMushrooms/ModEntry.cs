using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewModdingAPI.Utilities;
using HarmonyLib;

namespace kotae.MysteriousMushrooms
{
    public class ModEntry : Mod
    {
        IModHelper _Helper;

        public override void Entry(IModHelper helper)
        {
            _Helper = helper;
            MineShaft_Patched.Initialize(this.Monitor);

            var harmony = new Harmony(this.ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(StardewValley.Locations.MineShaft), nameof(StardewValley.Locations.MineShaft.chooseLevelType)),
                postfix: new HarmonyMethod(typeof(MysteriousMushrooms.MineShaft_Patched), nameof(MysteriousMushrooms.MineShaft_Patched.chooseLevelType_Postfix)));
        }
    }
}
