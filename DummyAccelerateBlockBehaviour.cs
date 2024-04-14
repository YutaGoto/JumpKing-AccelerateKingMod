using JumpKing.API;
using JumpKing.BodyCompBehaviours;
using JumpKing.Level;

namespace JumpKing_AccelerateKingMod
{
    public class DummyAccelerateBlockBehaviour: IBlockBehaviour
    {
        public float BlockPriority => 1f;

        public bool IsPlayerOnBlock { get; set; }

        public bool AdditionalXCollisionCheck(AdvCollisionInfo info, BehaviourContext behaviourContext)
        {
            return false;
        }

        public bool AdditionalYCollisionCheck(AdvCollisionInfo info, BehaviourContext behaviourContext)
        {
            return false;
        }

        public bool ExecuteBlockBehaviour(BehaviourContext behaviourContext)
        {
            return true;
        }

        public float ModifyXVelocity(float inputXVelocity, BehaviourContext behaviourContext)
        {
            return inputXVelocity * GetDeepWaterMultiplier();
        }

        public float ModifyYVelocity(float inputYVelocity, BehaviourContext behaviourContext)
        {
            return inputYVelocity * GetDeepWaterMultiplier();
        }

        public float ModifyGravity(float inputGravity, BehaviourContext behaviourContext)
        {
            return inputGravity * GetDeepWaterMultiplier();
        }

        public float GetDeepWaterMultiplier()
        {
            return 2.0f;
        }
    }
}
