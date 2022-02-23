using System;
using System.Collections.Generic;

internal static class RobotFactory
{

    private static Random seed = new Random();

    private static HashSet<string> NamedRobots = new HashSet<string>();

    public static string GetUnusedRobotName()
    {
        string name = GetName();
        while (NamedRobots.Contains(name))
        {
            name = GetName();
        }
        NamedRobots.Add(name);
        return name;
    }

    private static char GetLetter() => (char)('a' + seed.Next(0, 26));

    public static void DeprecateName(string name) => NamedRobots.Remove(name);

    private static string GetName() => $"{GetAlphaStamp()}{GetNumericStamp()}";

    private static string GetAlphaStamp() => $"{GetLetter()}{GetLetter()}".ToUpper();

    private static string GetNumericStamp() => $"{seed.Next(1, 9)}{seed.Next(1, 9)}{seed.Next(1, 9)}";
}

public class Robot
{
    public string Name { get; private set; }


    public Robot()
    {
        Name = RobotFactory.GetUnusedRobotName();
    }

    public void Reset()
    {
        string oldName = Name;
        Name = RobotFactory.GetUnusedRobotName();
        RobotFactory.DeprecateName(oldName);
    }
}