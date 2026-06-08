namespace Issue1417.Tests;

public class Issue1417Test
{

  [Fact]
  public void WhenValueIsA_ThenActionAIsPerformed()
  {
    Class1417.SetValue(E.A);

    Class1417.M();

    Assert.Equal("ActionA", Class1417._actionName);
  }

  [Fact]
  public void WhenValueIsB_ThenActionBIsPerformed()
  {
    Class1417.SetValue(E.B);

    Class1417.M();

    Assert.Equal("ActionB", Class1417._actionName);
  }

  [Fact]
  public void WhenValueIsC_ThenActionCIsPerformed()
  {
    Class1417.SetValue(E.C);

    Class1417.M();

    Assert.Equal("ActionC", Class1417._actionName);
  }

  [Fact]
  public void WhenValueIsOutOfRange_ThenThrowsUnreachableException()
  {
    Class1417.SetValue((E)999);

    _ = Assert.Throws<global::System.Diagnostics.UnreachableException>(Class1417.M);
  }
}
