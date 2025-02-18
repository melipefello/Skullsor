namespace Enemies
{
    class CrawlingState : EnemyState
    {
        public CrawlingState(EnemyModel model, EnemyController controller, EnemyView view)
            : base(model, controller, view) { }

        public override void Enter()
        {
            View.CrawlingAnimationFinished += OnCrawlingAnimationFinished;
            View.PlayAnimation("Crawl");
        }

        public override void Exit()
        {
            View.CrawlingAnimationFinished -= OnCrawlingAnimationFinished;
        }

        void OnCrawlingAnimationFinished()
        {
            Controller.StateMachine.SetState(Controller.IdleState);
        }
    }
}