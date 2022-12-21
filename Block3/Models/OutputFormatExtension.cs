using System;
using Microsoft.CodeAnalysis;

namespace Block3.Models;

public enum OutputFormat
{
    Months_Weeks_Days_Hours_Minutes_Seconds,
    Weeks_Days_Hours_Minutes_Seconds,
    Days_Hours_Minutes_Seconds,
    Hours_Minutes_Seconds,
    Minutes_Seconds,
    Years,
    Months,
    Days,
    Hours,
    Minutes,
    Seconds
}

public static class OutputFormatExtension
{
    private const uint MinutesInSec = 60;
    private const uint HoursInSec = MinutesInSec * 60;
    private const uint DayInSec = HoursInSec * 24;
    private const uint WeekInSec = DayInSec * 7;
    private const uint MonthInSec = DayInSec * 31;
    private const uint DaysInYear = 365;

    public static string ConvertToFormat(this OutputFormat format, TimeSpan printDate)
    {
        DateTime time = new DateTime(printDate.Ticks);
        
        switch (format)
        {
            case OutputFormat.Months_Weeks_Days_Hours_Minutes_Seconds:
                uint months = (uint) (printDate.TotalSeconds / MonthInSec);
                uint weeks = (uint) (printDate.TotalSeconds % (months * MonthInSec) / WeekInSec);
                uint days = (uint) (printDate.TotalSeconds % (months * MonthInSec) % (weeks * WeekInSec) / DayInSec);
                uint hours = (uint) (printDate.TotalSeconds % (months * MonthInSec) % (weeks * WeekInSec) % (days * DayInSec) / HoursInSec);
                uint minutes = (uint) (printDate.TotalSeconds % (months * MonthInSec) % (weeks * WeekInSec) % (days * DayInSec) % (hours * HoursInSec) / MinutesInSec);
                uint seconds = (uint) (printDate.TotalSeconds % (months * MonthInSec) % (weeks * WeekInSec) % (days * DayInSec) % (hours * HoursInSec) % (minutes * MinutesInSec));
                return $"{months} months, {weeks} weeks, {days} days, {hours} hours, {minutes} minutes, {seconds} seconds";
            case OutputFormat.Weeks_Days_Hours_Minutes_Seconds:
                uint weeks_ = (uint) (printDate.TotalSeconds / WeekInSec);
                uint days_ = (uint) (printDate.TotalSeconds % (weeks_ * WeekInSec) / DayInSec);
                uint hours_ = (uint) (printDate.TotalSeconds % (weeks_ * WeekInSec) % (days_ * DayInSec) / HoursInSec);
                uint minutes_ = (uint) (printDate.TotalSeconds % (weeks_ * WeekInSec) % (days_ * DayInSec) % (hours_ * HoursInSec) / MinutesInSec);
                uint seconds_ = (uint) (printDate.TotalSeconds % (weeks_ * WeekInSec) % (days_ * DayInSec) % (hours_ * HoursInSec) % (minutes_ * MinutesInSec));
                return $"{weeks_} weeks, {days_} days, {hours_} hours, {minutes_} minutes, {seconds_} seconds";
            case OutputFormat.Days_Hours_Minutes_Seconds:
                uint days__ = (uint) (printDate.TotalSeconds / DayInSec);
                uint hours__ = (uint) (printDate.TotalSeconds %  (days__ * DayInSec) / HoursInSec);
                uint minutes__ = (uint) (printDate.TotalSeconds % (days__ * DayInSec) % (hours__ * HoursInSec) / MinutesInSec);
                uint seconds__ = (uint) (printDate.TotalSeconds % (days__ * DayInSec) % (hours__ * HoursInSec) % (minutes__ * MinutesInSec));
                return $"{days__} days, {hours__} hours, {minutes__} minutes, {seconds__} seconds";
            case OutputFormat.Hours_Minutes_Seconds:
                uint hours___ = (uint) (printDate.TotalSeconds / HoursInSec);
                uint minutes___ = (uint) (printDate.TotalSeconds % (hours___ * HoursInSec) / MinutesInSec);
                uint seconds___ = (uint) (printDate.TotalSeconds % (hours___ * HoursInSec) % (minutes___ * MinutesInSec));
                return $"{hours___} hours, {minutes___} minutes, {seconds___} seconds";
            case OutputFormat.Minutes_Seconds:
                uint minutes____ = (uint) (printDate.TotalSeconds / MinutesInSec);
                uint seconds____ = (uint) (printDate.TotalSeconds % (minutes____ * MinutesInSec));
                return $"{minutes____} minutes, {seconds____} seconds";
            case OutputFormat.Years:
                return $"{Math.Floor(printDate.TotalDays / DaysInYear)} years";
            case OutputFormat.Months:
                return $"{Math.Floor(printDate.TotalSeconds / MonthInSec)}";
            case OutputFormat.Days:
                return $"{Math.Floor(printDate.TotalDays)} days";
            case OutputFormat.Hours:
                return $"{Math.Floor(printDate.TotalHours)} hours";
            case OutputFormat.Minutes:
                return $"{Math.Floor(printDate.TotalMinutes)} minutes";
            case OutputFormat.Seconds:
                return $"{Math.Floor(printDate.TotalSeconds)} seconds";
        }

        return "Error!";
    }

    public static string ToComboBoxString(this OutputFormat format)
        => Enum.GetName(typeof(OutputFormat), format).Replace('_', ' ');
    
    public static OutputFormat FromComboBoxString(this string comboString) 
        => Enum.Parse<OutputFormat>(comboString.Replace(' ', '_'));
}