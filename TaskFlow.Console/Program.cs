using TaskFlow.Console;

var manager = new TaskManager();
bool running = true;

while (running)
{
    System.Console.Clear();
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("         TASKFLOW CLI         ");
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("1. Adicionar Tarefa");
    System.Console.WriteLine("2. Listar Tarefas");
    System.Console.WriteLine("3. Concluir Tarefa");
    System.Console.WriteLine("0. Sair");
    System.Console.WriteLine("==============================");
    System.Console.Write("Escolha uma opção: ");

    var option = System.Console.ReadLine();

    switch (option)
    {
        case "1":
            System.Console.Write("\nDigite o título da tarefa: ");
            var title = System.Console.ReadLine();
            try
            {
                var created = manager.AddTask(title ?? string.Empty);
                System.Console.WriteLine($"\n[OK] Tarefa adicionada com sucesso! ID: {created.Id}");
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"\n[ERRO] {ex.Message}");
            }
            break;

        case "2":
            System.Console.WriteLine("\n--- LISTA DE TAREFAS ---");
            if (manager.Tasks.Count == 0)
            {
                System.Console.WriteLine("Nenhuma tarefa cadastrada.");
            }
            else
            {
                foreach (var task in manager.Tasks)
                {
                    string status = task.IsCompleted ? "[X]" : "[ ]";
                    System.Console.WriteLine($"{status} {task.Title} (ID: {task.Id})");
                }
            }
            break;

        case "3":
            System.Console.Write("\nInforme o GUID da tarefa a concluir: ");
            var idInput = System.Console.ReadLine();
            if (Guid.TryParse(idInput, out var id))
            {
                if (manager.CompleteTask(id))
                {
                    System.Console.WriteLine("\n[OK] Tarefa marcada como concluída!");
                }
                else
                {
                    System.Console.WriteLine("\n[ERRO] Tarefa não encontrada.");
                }
            }
            else
            {
                System.Console.WriteLine("\n[ERRO] Formato de GUID inválido.");
            }
            break;

        case "0":
            running = false;
            System.Console.WriteLine("\nEncerrando aplicação...");
            continue;

        default:
            System.Console.WriteLine("\nOpção inválida.");
            break;
    }

    System.Console.WriteLine("\nPressione qualquer tecla para continuar...");
    System.Console.ReadKey();
}