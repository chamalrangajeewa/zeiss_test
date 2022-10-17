namespace zeiss.machine.monitoring
{
    using System;

    public struct DateRange
    {
        public static readonly DateRange Default = new DateRange(DateTime.UtcNow.Date, DateTime.UtcNow);
 
        public DateRange(DateTime from, DateTime to)
        {
            DateTime _UtcTimeNow = DateTime.UtcNow;
            if (from > _UtcTimeNow || to > _UtcTimeNow)
            {
                throw new ArgumentException("date should be in the past");
            }

            if (from >= to)
            {
                throw new ArgumentException("the from date should fall before to date");
            }

            From = from;
            To = to;
        }

        public DateTime From { get; private set; }

        public DateTime To { get; private set; }
    }
}
