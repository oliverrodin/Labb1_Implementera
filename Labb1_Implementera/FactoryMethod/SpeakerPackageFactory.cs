namespace Labb1_Implementera;

public class SpeakerPackageFactory
{
    public static ISpeakerPackage GetSpeakerPackage(int packageType)
    {
        ISpeakerPackage speakerPackage = null;
        //Based of the CreditCard Type we are creating the
        //appropriate type instance using if else condition
        if (packageType == 1)
        {
            speakerPackage = new BigPackage();
        }
        else if (packageType == 2)
        {
            speakerPackage = new MediumPackage();
        }
        else if (packageType == 3)
        {
            speakerPackage = new SmallPackage();
        }

        return speakerPackage;

    }
}