namespace AnniePlaysGamesTestTask.Core.Character.States.Player
{
    public class IdleState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isInCombat", false);
            _animator.SetBool("isRunning", false);
        }
    }
}
