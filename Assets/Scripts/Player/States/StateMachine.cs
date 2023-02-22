using UnityEngine;

namespace AnniePlaysGamesTestTask.Player.States
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] PlayerController _player;
        private RunningState _runningState = new RunningState();
        private AttackingState _attackingState = new AttackingState();

        public BaseState _currentState { get; private set; }

        void Start()
        {
            InitializeStates();
        }

        void Update()
        {
            if (_currentState != null)
                _currentState.Tick();
        }

        public void SetState(State state)
        {

            switch (state)
            {
                case State.Attack:
                    _currentState = _attackingState;
                    
                    break;
                case State.Run:
                    _currentState = _runningState;
                    break;
                default:
                    _currentState = _attackingState;
                    break;
            }
            _currentState.Enter();
        }

        private bool IsInState(State state)
        {
            BaseState stateToCheck;

            switch (state)
            {
                case State.Attack:
                    stateToCheck = _attackingState;
                    break;
                case State.Run:
                    stateToCheck = _runningState;
                    break;
                default:
                    stateToCheck = _attackingState;
                    break;
            }

            return _currentState == stateToCheck;
        }

        private void InitializeStates()
        {
            _runningState.Initialize(_player);
            _attackingState.Initialize(_player);
        }
    }

}
