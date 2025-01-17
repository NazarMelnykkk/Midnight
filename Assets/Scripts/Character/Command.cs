using UnityEngine;

public class Command
{
    public CommandType CommandType;
    public Vector2 Direction;

    public GameObject Target;

    public bool IsComplete;

    public Command(CommandType commandType, Vector2 direction)
    {
        CommandType = commandType;
        Direction = direction;
    }

    public Command(CommandType commandType, GameObject target)
    {
        CommandType = commandType;
        Target = target;
    }

    public Command(CommandType commandType)
    {
        CommandType = commandType;
    }
}