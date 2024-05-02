using UnityEngine;

public class CommandHandler : MonoBehaviour
{
    public Command CurrentCommand;
    private ICommandHandler _characterMoveHandler;

    private void Awake()
    {
        _characterMoveHandler = GetComponent<MovementStateController>();
    }

    public void SetCommand(Command newCommand)
    {
        CurrentCommand = newCommand;
    }

    private void Update()
    {
        if (CurrentCommand == null)
        {
            return;
        }

        ProcessCommand();
    }

    private void ProcessCommand()
    {
        switch (CurrentCommand.CommandType)
        {
            case CommandType.None:
                break;
            case CommandType.Move:
                ProcessMoveCommand();
                break;
            case CommandType.Jump:
                break;
            case CommandType.Fire:
                break;
            case CommandType.Reload:
                break;
            default:
                break;
        }

        if (CurrentCommand.IsComplete == true)
        {
            CompleteComand();
        }
    }

    private void CompleteComand()
    {
        CurrentCommand = null;
    }

    private void ProcessMoveCommand()
    {
        _characterMoveHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessJumpCommand()
    {
        //moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessFireCommand()
    {
        //moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessReloadommand()
    {
        //moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    public CommandType GetCurrentCommandType()
    {
        if (CurrentCommand == null)
        {
            return CommandType.None;
        }

        return CurrentCommand.CommandType;
    }
}
