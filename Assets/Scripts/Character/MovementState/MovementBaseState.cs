using Unity.VisualScripting;
using UnityEngine.Video;

public abstract class MovementBaseState 
{
    public abstract void EnterState(MovementStateController movement);


    public abstract void UpdateState(MovementStateController movement);
}
