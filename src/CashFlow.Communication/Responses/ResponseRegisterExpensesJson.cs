namespace CashFlow.Communication.Responses
{
    public class ResponseRegisterExpensesJson
    {
        public string Title { get; set; } = string.Empty;

        public ResponseRegisterExpensesJson(string Title)
        {
            this.Title = Title;
        }
    }

}
