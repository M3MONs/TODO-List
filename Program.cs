bool canExitGame = false;
List<string> todoList = new List<string>();
todoList.Add("Learn C#");
todoList.Add("Get notes for CCNA");

Console.WriteLine("Hello!");
do
{
    OptionsPrompt();
    string userChoice = Console.ReadLine();
    CheckUserOption(userChoice);
}
while (!canExitGame);

void CheckUserOption(string option)
{
    switch (option)
    {
        case "s":
        case "S":
            SeeAllTodosOption();
            break;
        case "a":
        case "A":
            AddTodoOption();
            break;
        case "r":
        case "R":
            RemoveTodoOption();
            break;
        case "e":
        case "E":
            SelectedOptionPrompt("Exit");
            canExitGame = true;
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }
}

void RemoveTodoOption()
{
    SelectedOptionPrompt("Remove a TODO");
    if (IsTodoListEmpty()) { return; }

    Console.WriteLine("Select the index of the TODO you want to remove:");
    PrintAllElementsFromList(todoList);

    var canParseToInt = int.TryParse(Console.ReadLine(), out int todoIndex);
    if (!CanRemoveTodoFromList(todoIndex, canParseToInt)) { return; }

    string todoValue = GetTodo(todoIndex - 1);
    RemoveTodoFromList(todoIndex - 1);
    Console.WriteLine($"TODO removed: {todoIndex}. {todoValue}");
}

string GetTodo(int index) {
    return todoList[index];
}

bool CanRemoveTodoFromList(int index, bool canParse)
{
    if (index == 0)
    {
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }

    if (!canParse || !IsValidTodoIndex(index))
    {
        Console.WriteLine("The given index is not valid.");
        return false;
    }
    return true;
}

bool IsValidTodoIndex(int index)
{
    return index >= 0 && index <= todoList.Count;
}

void RemoveTodoFromList(int index)
{
    todoList.RemoveAt(index);
}

void AddTodoOption()
{
    SelectedOptionPrompt("Add a TODO");
    Console.WriteLine("Enter the TODO description:");
    string userInputTodo = Console.ReadLine();

    if (CanAddTodo(userInputTodo))
    {
        AddTodoToList(userInputTodo);
        NewTodoAddedPrompt(userInputTodo);
    }
}

bool CanAddTodo(string newTodo)
{
    if (newTodo == null)
    {
        Console.WriteLine("The description the user provided is empty.");
        return false;
    }

    if (todoList.Contains(newTodo))
    {
        Console.WriteLine("There is already a TODO with the same description as the user provided.");
        return false;
    }
    return true;
}

void AddTodoToList(string todo)
{
    todoList.Add(todo);
}

void SeeAllTodosOption()
{
    SelectedOptionPrompt("See all TODOs");
    if (!IsTodoListEmpty())
    {
        PrintAllElementsFromList(todoList);
    }
}

bool IsTodoListEmpty()
{
    bool isTodoListEmpty = IsListEmpty(todoList);
    if (isTodoListEmpty)
    {
        NoTodoPrompt();
    }
    return isTodoListEmpty;
}

void PrintAllElementsFromList(List<string> list)
{
    int index = 1;
    foreach (var element in list)
    {
        Console.WriteLine($"{index}. {element}");
        index++;
    }
}

bool IsListEmpty(List<string> list)
{
    return list.Count < 1;
}

void NoTodoPrompt()
{
    Console.WriteLine("No TODOs have been added yet.");
}

void NewTodoAddedPrompt(string todo)
{
    Console.WriteLine($"TODO successfully added: {todo}");
}

void OptionsPrompt()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

void SelectedOptionPrompt(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

Console.ReadKey();
