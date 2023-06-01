namespace RefactoringToPatterns.CreationMethods;

public class ProductPackage
{
    private readonly string? _internetLabel;
    private readonly int? _telephoneNumber;
    private readonly string[]? _tvChannels;

    private ProductPackage(string internetLabel, int? telephoneNumber, string[]? tvChannels)
    {
        _internetLabel = internetLabel;
        _telephoneNumber = telephoneNumber;
        _tvChannels = tvChannels;
    }
    
    public static ProductPackage CreateWithInternet(string internet)
    {
        var productPackage = new ProductPackage(internet, null, null);
        return productPackage;
    }
    
    public static ProductPackage CreateWithInternetAndVoip(string internet, int telephone)
    {
        var productPackage = new ProductPackage(internet, telephone, null);
        return productPackage;
    }
    
    public static ProductPackage CreateWithInternetAndTv(string internet, string[] tvChannels)
    {
        var productPackage = new ProductPackage(internet, null, tvChannels);
        return productPackage;
    }
    
    public static ProductPackage CreateWithInternetVoipAndTv(string internet, int telephone, string[] tvChannels)
    {
        var productPackage = new ProductPackage(internet, telephone, tvChannels);
        return productPackage;
    }

    public bool HasInternet()
    {
        return _internetLabel != null;
    }


    public bool HasVOIP()
    {
        return _telephoneNumber != null;
    }

    public bool HasTv()
    {
        return _tvChannels != null;
    }
}