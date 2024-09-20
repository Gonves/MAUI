using Kotlin.Properties;
using System.Collections.ObjectModel;

namespace MAUI
{
    public partial class MainPage : ContentPage
    {
       public ObservableCollection<TaskItem> TaskList { get; set; } = new ObservableCollection<TaskItem> ();

        public MainPage() 
        { 
            InitializeComponent ();
            TaskListView.ItemsSource = TaskList;

          
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TaskEntry.Text)) 
            {
                TaskList.Add(new TaskItem{ TaskName = TaskEntry.Text});
                
                TaskEntry.Text = string.Empty;

            }

        }

        private void OnCompleteTaskClicked(object sender, EventArgs e) 
        { 
            var button =sender as Button;
            var Task = button.BindingContext as TaskItem;
            if (Task != null) 
            {
                Task.TaskName += "(Concluido)";
                DisplayAlert("Tarefas Finalizadas", "A tarefa" + Task.TaskName, "Ok");
            }
        }
    }

}
