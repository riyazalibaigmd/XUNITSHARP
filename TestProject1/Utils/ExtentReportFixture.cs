using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject1
{   
public class ExtentReportFixture : IDisposable
{
    private static ExtentReports _extent;
    private static ExtentHtmlReporter _htmlReporter;

    public ExtentReportFixture()
    {
        // Set up Extent Report configuration
        string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtentReport.html");
        _htmlReporter = new ExtentHtmlReporter(reportPath);
        _extent = new ExtentReports();
        _extent.AttachReporter(_htmlReporter);
    }

    public void Dispose()
    {
        // Flush the Extent Report after all tests are executed
        _extent.Flush();
    }
}
}