class Lasagna
{
    private int preparationTimePerLayer = 2;

    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int minutesInOven)
    {
        return ExpectedMinutesInOven() - minutesInOven;
    }

    public int PreparationTimeInMinutes(int numberOfLayers)
    {
        return preparationTimePerLayer * numberOfLayers;
    }

    public int ElapsedTimeInMinutes(int numberOfLayers, int minutesInOven)
    {
        return PreparationTimeInMinutes(numberOfLayers) + minutesInOven;
    }
}
