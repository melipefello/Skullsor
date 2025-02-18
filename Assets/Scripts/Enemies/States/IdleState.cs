namespace Enemies
{
    class IdleState : EnemyState
    {
        public IdleState(EnemyModel model, EnemyController controller, EnemyView view)
            : base(model, controller, view) { }

        public override void Enter()
        {
            Controller.Interacted += OnInteracted;
            View.HitAnimationFinished += OnHitAnimationFinished;
            Model.ResetHealth(20);
            View.PlayAnimation("Idle", 0.15f);
        }

        public override void Exit()
        {
            Controller.Interacted -= OnInteracted;
            View.HitAnimationFinished -= OnHitAnimationFinished;
        }

        void OnInteracted()
        {
            const int amount = 1;
            Model.TakeDamage(amount);
            Controller.HandleDamageTaken(amount);
            if (Model.Health <= 0)
                Controller.StateMachine.SetState(Controller.DeadState);
        }

        void OnHitAnimationFinished()
        {
            View.PlayAnimation("Idle", 0.15f);
        }
    }
}