namespace miniCRM
{
    internal class ClientListReportFactory : ReportGeneratorFactory
    {
        public override BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader)
        {
            return new ClientListReport(clientReader, orderReader);
        }
    }
}