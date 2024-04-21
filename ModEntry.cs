using EntityComponent;
using HarmonyLib;
using JumpKing.Level;
using JumpKing.Mods;
using JumpKing.Player;
using System.Reflection;

namespace JumpKing_AccelerateKingMod
{
    [JumpKingMod("YutaGoto.JumpKing_AccelerateKingMod")]
    public static class ModEntry
    {
        /// <summary>
        /// Called by Jump King before the level loads
        /// </summary>
        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            LevelManager.RegisterBlockFactory(new BlockFactory());
            Harmony harmony = new Harmony("YutaGoto.JumpKing_Expansion_Blocks");
            PatchWithHarmony(harmony);
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
            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();
            if (player != null)
            {
                player.m_body.RegisterBlockBehaviour(typeof(DummyAccelerateBlock), new DummyAccelerateBlockBehaviour());
            }
        }

        /// <summary>
        /// Called by Jump King when the Level Ends
        /// </summary>
        [OnLevelEnd]
        public static void OnLevelEnd() { }

        /// <summary>
        /// Setups the Harmony patching
        /// </summary>
        private static void PatchWithHarmony(Harmony harmony)
        {
            MethodInfo isGetMultipliers = typeof(BodyComp).GetMethod("GetMultipliers");
            MethodInfo postfixGetMultipliers = typeof(ModEntry).GetMethod("GetMultipliersPostfix");
            harmony.Patch(isGetMultipliers, postfix: new HarmonyMethod(postfixGetMultipliers));
        }

        public static void GetMultipliersPostfix(ref float __result)
        {
            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();

            if (player != null)
            {
                __result *= 2.0f;
            }
        }
    }
}
