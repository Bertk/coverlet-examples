using NUnit.Framework;

namespace Issue1334.Tests
{
  public class Repo1334Tests
  {
    [Test]
    public void ExecuteWithCondition2_FullBranchCoverage()
    {
      // Arrange
      Repo1334 sut = new();

      // Act
      // Shall create full branch coverage
      sut.ExecuteWithCondition2(1);
      sut.ExecuteWithCondition2(2);
    }

    [Test]
    public void ExecuteWithCondition3_FullBranchCoverage()
    {
      // Arrange
      Repo1334 sut = new();

      // Act
      // Shall create full branch coverage
      sut.ExecuteWithCondition3(1);
      sut.ExecuteWithCondition3(2);
      sut.ExecuteWithCondition3(3);
    }
  }

  public class RepoValues1334Tests
  {
    [Test]
    public void ExecuteWithAndCondition_FullBranchCoverage()
    {
      // Arrange


      // Act
      // Shall create full branch coverage
      Assert.IsTrue(RepoValues1334.ExecuteWithAndCondition(1, 1, 2, 2));
      Assert.IsFalse(RepoValues1334.ExecuteWithAndCondition(1, 2, 3, 4));
    }

    [Test]
    public void ExecuteWithOrCondition_FullBranchCoverage()
    {
      // Arrange

      // Act
      // Shall create full branch coverage
      Assert.IsTrue(RepoValues1334.ExecuteWithOrCondition(1, 1, 3, 4));
      Assert.IsTrue(RepoValues1334.ExecuteWithOrCondition(1, 2, 3, 3));
      Assert.IsFalse(RepoValues1334.ExecuteWithOrCondition(1, 2, 3, 4));
    }
  }
}
