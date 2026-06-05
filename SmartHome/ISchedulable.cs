using System;

public interface ISchedulable
{
    DateTime NextRun { get; set; }
    void Schedule(DateTime time);
}