namespace TaskFlow.Console;

public class TaskManager
{
    private readonly List<TaskItem> _tasks = new();

    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem(title);
        _tasks.Add(task);
        return task;
    }

    public TaskItem? GetById(Guid id)
    {
        // Versao inicial que lanca excecao quando o ID nao existe
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return task ?? throw new KeyNotFoundException("Tarefa nao encontrada.");
    }

    public bool CompleteTask(Guid id)
    {
        try
        {
            var task = GetById(id);
            if (task == null) return false;
            task.Complete();
            return true;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
    }
}