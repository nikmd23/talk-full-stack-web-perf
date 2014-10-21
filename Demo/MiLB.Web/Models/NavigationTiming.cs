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
        public double FirstPaintTime { get; set; }
        public double FirstPaint { get; set; }
        public double LoadTime { get; set; }
        public double DomReadyTime { get; set; }
        public double ReadyStart { get; set; }
        public double RedirectTime { get; set; }
        public double AppcacheTime { get; set; }
        public double UnloadEventTime { get; set; }
        public double LookupDomainTime { get; set; }
        public double ConnectTime { get; set; }
        public double RequestTime { get; set; }
        public double InitDomTreeTime { get; set; }
        public double LoadEventTime { get; set; }
    }
}