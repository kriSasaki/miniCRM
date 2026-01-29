namespace miniCRM
{
    internal class ClientOrdersReportFactory : ReportGeneratorFactory
    {
        public override BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader)
        {
            return new ClientOrdersReport(clientReader, orderReader);
        }
    }
}