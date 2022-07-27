using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;

namespace kotae.MysteriousMushrooms
{
    public class MineShaft_Patched
    {
        private static IMonitor Monitor;

        public static void Initialize(IMonitor monitor)
        {
            Monitor = monitor;
        }

        public static void chooseLevelType_Postfix()
        {
            try
            {
                if (MineShaft.mushroomLevelsGeneratedToday != null)
                {
                    MineShaft.mushroomLevelsGeneratedToday.Clear();
                }
                else
                {
                    if (MineShaft_Patched.Monitor != null)
                        MineShaft_Patched.Monitor.Log("mushroomLevelsGeneratedToday hashset is null, cannot perform.", LogLevel.Error);
                }
            }
            catch (Exception ex)
            {
                if (MineShaft_Patched.Monitor != null)
                    MineShaft_Patched.Monitor.Log("Failed in chooseLevelType_Postfix:\n" + ex.Message, LogLevel.Error);
            }
        }
    }
}
