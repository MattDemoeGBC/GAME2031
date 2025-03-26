using UnityEngine;

public class MoveCommand : ICommand 
{
    BadPlayerMover playerMover;
    Vector3 direction;

    public MoveCommand(BadPlayerMover playerMover, Vector3 direction)
    {
        this.playerMover = playerMover;
        this.direction = direction;
    }
    public void Execute()
    {
        playerMover.Move(direction);
    }

    public void Undo()
    {
        playerMover.Move(-direction);
    }
}
