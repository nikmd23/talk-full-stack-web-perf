namespace MiLB.Web.Models
{
    public class NavigationTiming
    {
        public double DomComplete { get; set; }
        public double DomContentLoadedEventEnd { get; set; }
        public double DomContentLoadedEventStart { get; set; }
        public double DomInteractive { get; set; }
        public double DomLoading { get; set; }
        public double ResponseEnd { get; set; }
        public double ResponseStart { get; set; }
        public double RequestStart { get; set; }
        public double SecureConnectionStart { get; set; }
        public double FetchStart { get; set; }
        public double NavigationStart { get; set; }
    }
}