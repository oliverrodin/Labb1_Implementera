namespace Labb1_Implementera;

public class SmallPackage : ISpeakerPackage
{
    public string GetPackageName()
    {
        return "Small Speaker package";
    }

    public int GetPrice()
    {
        return 500;
    }

    public int GetAudienceCoverage()
    {
        return 200;
    }
}