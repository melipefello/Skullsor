namespace Enemies
{
    class DeadState : EnemyState
    {
        public DeadState(EnemyModel model, EnemyController controller, EnemyView view)
            : base(model, controller, view) { }

        public override void Enter()
        {
            View.DiedAnimationFinished += OnDiedAnimationFinished;
            Controller.HandleDied();
        }

        public override void Exit()
        {
            View.DiedAnimationFinished -= OnDiedAnimationFinished;
        }

        void OnDiedAnimationFinished()
        {
            Controller.StateMachine.SetState(Controller.CrawlingState);
        }
    }
}