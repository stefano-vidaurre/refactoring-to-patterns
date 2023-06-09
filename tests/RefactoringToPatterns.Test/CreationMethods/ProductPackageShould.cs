using RefactoringToPatterns.CreationMethods;

namespace RefactoringToPatterns.Test.CreationMethods;

public class ProductPackageShould
{
    [Fact]
    public void CreateAProductPackageWithOnlyInternet()
    {
        var productPackage = ProductPackage.CreateWithInternet("100MB");

        Assert.True(productPackage.HasInternet());
        Assert.False(productPackage.HasVOIP());
        Assert.False(productPackage.HasTv());
    }

    [Fact]
    public void CreateWithInternetAndVoip()
    {
        var productPackage = ProductPackage.CreateWithInternetAndVoip("100MB", 91233788);

        Assert.True(productPackage.HasInternet());
        Assert.True(productPackage.HasVOIP());
        Assert.False(productPackage.HasTv());
    }

    [Fact]
    public void CreateWithInternetAndTv()
    {
        var productPackage = ProductPackage.CreateWithInternetAndTv("100MB", new[] { "LaLiga", "Estrenos" });

        Assert.True(productPackage.HasInternet());
        Assert.False(productPackage.HasVOIP());
        Assert.True(productPackage.HasTv());
    }

    [Fact]
    public void CreateWithInternetVoipAndTv()
    {
        var productPackage = ProductPackage.CreateWithInternetVoipAndTv("100MB", 91233788, new[] { "LaLiga", "Estrenos" });

        Assert.True(productPackage.HasInternet());
        Assert.True(productPackage.HasVOIP());
        Assert.True(productPackage.HasTv());
    }
}