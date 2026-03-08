using UnityEngine;

public class Player_Grounded_State : PlayerState
{
    public Player_Grounded_State(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if(rb.linearVelocity.y < 0 && player.groundDetected == false)
        stateMachine.ChangeState(player.fallState);

        if(input.Player.jump.WasPressedThisFrame())
        stateMachine.ChangeState(player.jumpState);

        if(input.Player.Attack.WasPressedThisFrame())
        stateMachine.ChangeState(player.basicAttackState);

        if(input.Player.CounterAttack.WasPressedThisFrame())
        stateMachine.ChangeState(player.counterAttackState);
    }
}
