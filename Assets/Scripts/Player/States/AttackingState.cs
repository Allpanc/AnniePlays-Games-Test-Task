using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Player.States
{
    public class AttackingState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isRunning", false);
        }
    }
}
