using UnityEngine;

public abstract class InteractionState
{
    protected BigFormBehavior context;

    public InteractionState(BigFormBehavior context)
    {
        this.context = context;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void Interact() { }
}
