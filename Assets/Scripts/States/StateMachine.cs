namespace States
{
    public class StateMachine<TState> where TState : IState
    {
        TState CurrentState { get; set; }

        public void SetState(TState state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}