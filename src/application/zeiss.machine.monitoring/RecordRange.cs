namespace zeiss.machine.monitoring
{
    using System;

    public struct RecordRange
    {
        
        public static readonly RecordRange Default = new RecordRange();

        public RecordRange(int from = 0, int to = 10)
        {
            if (from < 0)
            {
                throw new ArgumentOutOfRangeException("from should be 0 or more");
            }

            if (from >= to)
            {
                throw new ArgumentException("to must be greater than from");
            }

            From = from;
            To = to;
        }

        public int From { get; private set; }

        public int To { get; private set; }
    }
}
