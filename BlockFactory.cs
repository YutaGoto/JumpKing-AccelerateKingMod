using JumpKing.API;
using JumpKing.Level;
using JumpKing.Level.Sampler;
using JumpKing.Workshop;
using Microsoft.Xna.Framework;
using System;

namespace JumpKing_AccelerateKingMod
{
    class BlockFactory : IBlockFactory
    {
        private static readonly Color CODE_DUMMY_ACCELERATE = new Color(255, 255, 254);

        public bool CanMakeBlock(Color blockCode, Level level)
        {
            if (blockCode == CODE_DUMMY_ACCELERATE)
            {
                return true;
            }
            return false;
        }

        public bool IsSolidBlock(Color blockCode)
        {
            return false;
        }

        public IBlock GetBlock(Color blockCode, Rectangle blockRect, JumpKing.Workshop.Level level, LevelTexture textureSrc, int currentScreem, int x, int y)
        {
            if (blockCode == CODE_DUMMY_ACCELERATE)
            {
                return new DummyAccelerateBlock(blockRect);
            }
            else
            {
                throw new InvalidOperationException($"{typeof(BlockFactory).Name} is unable to create a block of Color code ({blockCode.R}, {blockCode.G}, {blockCode.B})");
            }
        }
    }
}
