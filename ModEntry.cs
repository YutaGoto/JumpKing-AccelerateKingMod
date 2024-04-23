using EntityComponent;
using HarmonyLib;
using JumpKing.Level;
using JumpKing.Mods;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.PauseMenu;
using JumpKing.Player;
using System.Reflection;
using System.IO;

namespace JumpKing_AccelerateKingMod
{
    [JumpKingMod("YutaGoto.JumpKing_AccelerateKingMod")]
    public static class ModEntry
    {

        public static bool isEnabled;
        public static readonly string harmonyId = "YutaGoto.JumpKing_AccelerateKingMod";
        public static Harmony harmony = new Harmony(harmonyId);

        [MainMenuItemSetting]
        public static ITextToggle AddToggleEnabled(object factory, GuiFormat format)
        {
            return new NodeToggleEnabled(isEnabled);
        }

        /// <summary>
        /// Called by Jump King before the level loads
        /// </summary>
        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            isEnabled = false;
            LevelManager.RegisterBlockFactory(new BlockFactory());
        }

        /// <summary>
        /// Called by Jump King when the level unloads
        /// </summary>
        [OnLevelUnload]
        public static void OnLevelUnload() { }

        /// <summary>
        /// Called by Jump King when the Level Starts
        /// </summary>
        [OnLevelStart]
        public static void OnLevelStart()
        {
            if (!isEnabled) return;

            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();
            PatchWithHarmony();

            if (player != null)
            {
                player.m_body.RegisterBlockBehaviour(typeof(DummyAccelerateBlock), new DummyAccelerateBlockBehaviour());
            }
        }

        /// <summary>
        /// Called by Jump King when the Level Ends
        /// </summary>
        [OnLevelEnd]
        public static void OnLevelEnd() 
        {
            harmony.UnpatchAll(harmonyId);
        }

        /// <summary>
        /// Setups the Harmony patching
        /// </summary>
        private static void PatchWithHarmony()
        {
            new GameLoopDraw(harmony);

            MethodInfo isGetMultipliers = typeof(BodyComp).GetMethod("GetMultipliers");
            MethodInfo postfixGetMultipliers = typeof(ModEntry).GetMethod("GetMultipliersPostfix");
            harmony.Patch(isGetMultipliers, postfix: new HarmonyMethod(postfixGetMultipliers));
        }

        public static void GetMultipliersPostfix(ref float __result)
        {
            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();

            if (player != null) __result *= 2.0f;
        }
    }
}
