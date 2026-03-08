using UnityEngine;

public class Player_Fall_State : Player_AiredState
{
    public Player_Fall_State(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.groundDetected)
        stateMachine.ChangeState(player.idleState);

        if(player.wallDetected)
        stateMachine.ChangeState(player.wallSlideState);
    }
}
