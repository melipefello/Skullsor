using States;

namespace Enemies
{
    public abstract class EnemyState : IState
    {
        protected readonly EnemyController Controller;
        protected readonly EnemyModel Model;
        protected readonly EnemyView View;

        protected EnemyState(EnemyModel model, EnemyController controller, EnemyView view)
        {
            Model = model;
            Controller = controller;
            View = view;
        }

        public abstract void Enter();
        public abstract void Exit();
    }
}