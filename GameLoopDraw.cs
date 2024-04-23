using HarmonyLib;
using JumpKing;
using JumpKing.GameManager;
using JumpKing.Util;
using Microsoft.Xna.Framework;

namespace JumpKing_AccelerateKingMod
{
    internal class GameLoopDraw
    {
        public GameLoopDraw(Harmony harmony)
        {
            harmony.Patch(typeof(GameLoop).GetMethod("Draw"), null, new HarmonyMethod(AccessTools.Method(typeof(GameLoopDraw), "Draw")));
        }

        private static void Draw(GameLoop __instance)
        {
            if (ModEntry.isEnabled)
            {
                TextHelper.DrawString(Game1.instance.contentManager.font.MenuFont, "Accelerate Mode", new Vector2(12f, 300f), Color.Yellow, new Vector2(0f, 0f), p_is_outlined: true);
            }
        }
    }
}
