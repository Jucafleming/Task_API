namespace Task_API.Model
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Boolean IsCompleted  { get; set; }
    }
}
