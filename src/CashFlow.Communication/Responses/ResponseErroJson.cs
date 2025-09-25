namespace CashFlow.Communication.Responses
{
    public class ResponseErroJson
    {
        public List<string> ErroMessage { get; set; }

        public ResponseErroJson(string ErroMessage)
        {
            this.ErroMessage = [ErroMessage];
        }

        public ResponseErroJson(List<string> erroMessage)
        {
            ErroMessage = erroMessage;
        }
    }
}
