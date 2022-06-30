namespace Labb1_Implementera;

public class BigPackage : ISpeakerPackage
{
    public string GetPackageName()
    {
        return "Big Speaker package";
    }

    public int GetPrice()
    {
        return 1000;
    }

    public int GetAudienceCoverage()
    {
        return 600;
    }
}