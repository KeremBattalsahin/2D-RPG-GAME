using UnityEngine;

public class Enemy_Skeleton : Enemy , ICounterable
{
    public bool CanBeCountered { get => canBeStunned; }

    protected override void Awake()
    {
        base.Awake();

        IdleState = new Enemy_IdleState(this, stateMachine,"idle");
        MoveState = new Enemy_MoveState(this,stateMachine,"move");
        attackState = new Enemy_AttackState(this,stateMachine,"attack");
        battleState = new Enemy_BattleState(this,stateMachine,"battle");
        deathState = new Enemy_DeathState(this,stateMachine,"idle");
        stunnedState = new Enemy_StunnedState(this,stateMachine,"stunned");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(IdleState);
    }

    public void HandleCounter()
    {
        if(CanBeCountered == false)
        return;
        
        stateMachine.ChangeState(stunnedState);
    }
}
