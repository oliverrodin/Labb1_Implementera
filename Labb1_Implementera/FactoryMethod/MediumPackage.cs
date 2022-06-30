namespace Labb1_Implementera;

public class MediumPackage : ISpeakerPackage
{
    public string GetPackageName()
    {
        return "Medium Speaker package";
    }

    public int GetPrice()
    {
        return 7000;
    }

    public int GetAudienceCoverage()
    {
        return 400;
    }
}