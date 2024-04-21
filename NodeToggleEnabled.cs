using JumpKing.PauseMenu.BT.Actions;

namespace JumpKing_AccelerateKingMod
{
    public class NodeToggleEnabled: ITextToggle
    {
        public NodeToggleEnabled(bool p_start_value) : base(p_start_value) { }

        protected override string GetName()
        {
            return "Acceretate";
        }

        protected override void OnToggle()
        {
            ModEntry.isEnabled = toggle;
        }
    }
}
