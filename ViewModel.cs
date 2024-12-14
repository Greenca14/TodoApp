using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TodoApp
{
    public class TodoListViewModel : BindableObject
    {
        private string newTaskTitle;
        private ObservableCollection<TodoTask> tasks;

        public TodoListViewModel()
        {
            Tasks = new ObservableCollection<TodoTask>();
            AddTaskCommand = new Command(AddTask, CanAddTask);//Всопользоваться перегрузкой и сделать кнопку на можно/нельзя выполнить команду
            DeleteTaskCommand = new Command<TodoTask>(DeleteTask);
        }//comm

        public string NewTaskTitle
        {
            get => newTaskTitle;
            set
            {
                if (newTaskTitle != value)
                {
                    newTaskTitle = value;
                    OnPropertyChanged();

                    ((Command)AddTaskCommand).ChangeCanExecute();
                }
            }
        }

        public ObservableCollection<TodoTask> Tasks
        {
            get => tasks;
            set
            {
                if (tasks != value)
                {
                    tasks = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        private void AddTask()
        {
            if (!string.IsNullOrEmpty(NewTaskTitle))
            {
                Tasks.Add(new TodoTask { Title = NewTaskTitle });
                NewTaskTitle = string.Empty;
            }
        }

        private bool CanAddTask()
        {
            return !string.IsNullOrEmpty(NewTaskTitle);
        }

        private void DeleteTask(TodoTask task)
        {
            Tasks.Remove(task);
            OnPropertyChanged(nameof(Tasks));
        }
    }
}
