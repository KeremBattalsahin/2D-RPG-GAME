using UnityEngine;

public abstract class EntityState 
{
    protected StateMachine stateMachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
     protected float stateTimer;
    protected bool triggerCalled;

    public EntityState(StateMachine stateMachine, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()//Everytime state will be changed , enter will called
    {
       anim.SetBool(animBoolName,true); 
       triggerCalled = false;
    }

    public virtual void Update() //we going to run logic of the state here
    {
        stateTimer -= Time.deltaTime;
        UpdateAnimationParameters();
        
    }

    public virtual void Exit()//this will be called, everytime we exit state and change to a new one
    {
        anim.SetBool(animBoolName,false);
    }

    public void AnimationTrigger()
    {
        triggerCalled = true;
    }

    public virtual void UpdateAnimationParameters()
    {
        
    }
}
