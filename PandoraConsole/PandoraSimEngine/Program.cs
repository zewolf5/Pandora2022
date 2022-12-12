using PandoraSimEngine;

internal class Program
{
    private static void Main(string[] args)
    {
        var populationData = GetPopulationData();

        var sim = new SimEngine(populationData);

        sim.Start();
    }

    private static object GetPopulationData()
    {
        return null;
    }
}