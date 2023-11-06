

public class RandomStringGenerate
{

    private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public static string Generate(int length)
    {
        string randomstr = "";
        for(int i = 0; i < length; i++)
        {
            randomstr += chars[ UnityEngine.Random.Range(0,chars.Length)];

        }
        return randomstr;   
    }

}
