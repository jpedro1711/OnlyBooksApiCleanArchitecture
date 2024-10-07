namespace OnlyBooksApi.Core.Constants
{
    public static class QueueNames
    {
        public static string EmprestimosQueue { get; set; } = "sb://onlybooksservicebus.servicebus.windows.net/emprestimos-queue";
    }
}
