using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    private static int[] lastWeeksCount = new int[7] { 0, 2, 5, 3, 7, 8, 4 };

    public BirdCount(int[] birdsPerDay) => this.birdsPerDay = birdsPerDay;
    
    public static int[] LastWeek() => lastWeeksCount;

    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => birdsPerDay.Contains(0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => birdsPerDay.Count(day => day >= 5);
}
