using JumpKing.Level;
using Microsoft.Xna.Framework;

namespace JumpKing_AccelerateKingMod
{
    public class DummyAccelerateBlock : BoxBlock
    {
        protected override bool canBlockPlayer => false;
        public DummyAccelerateBlock(Rectangle p_collider) : base(p_collider) { }
    }
}
