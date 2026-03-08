using UnityEngine;

public class Player_Jump_State : Player_AiredState
{
    public Player_Jump_State(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

       player.SetVelocity(rb.linearVelocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if(rb.linearVelocity.y < 0 && stateMachine.currentState != player.jumpAttackState)
        stateMachine.ChangeState(player.fallState);
    }
}
