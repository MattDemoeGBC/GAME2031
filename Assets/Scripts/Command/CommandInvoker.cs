using System.Collections.Generic;

public class CommandInvoker
{
    private static Stack<ICommand> undoStack = new();

    private static Stack<ICommand> redoStack = new();

    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }

    public static void UndoCommand()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
        }
    }

    public static void RedoCommand()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
        }
    }
}
