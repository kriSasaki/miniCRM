namespace miniCRM
{
    public abstract class ReportGeneratorFactory
    {
        public abstract BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader);
    }
}