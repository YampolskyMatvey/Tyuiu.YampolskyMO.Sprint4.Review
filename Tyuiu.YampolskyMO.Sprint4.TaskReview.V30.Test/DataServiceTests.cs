using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.YampolskyMO.Sprint4.TaskReview.V30.Lib;

namespace Tyuiu.YampolskyMO.Sprint4.TaskReview.V30.Test;

[TestClass]
public class DataServiceTests
{
    private readonly DataService ds = new();

    [TestMethod]
    public void GetMatrix_Variant30_FillsAllCellsInRowOrder()
    {
        int[,] expected = { { 6, 8, 4 }, { 2, 5, 9 }, { 1, 3, 7 }, { 1, 5, 9 }, { 6, 4, 8 } };
        int[,] actual = ds.GetMatrix("684259137159648", 5, 3);
        Assert.AreEqual(5, actual.GetLength(0));
        Assert.AreEqual(3, actual.GetLength(1));
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 3; j++)
                Assert.AreEqual(expected[i, j], actual[i, j]);
    }

    [TestMethod]
    public void Calculate_Variant30_Returns73728()
        => Assert.AreEqual(73728L, ds.Calculate(ds.GetMatrix("684259137159648", 5, 3)));

    [TestMethod]
    public void Calculate_ZeroEvenElement_ReturnsZero()
        => Assert.AreEqual(0L, ds.Calculate(new int[,] { { 2, 0, 4 } }));

    [TestMethod]
    public void Calculate_IgnoresOddElements()
        => Assert.AreEqual(8L, ds.Calculate(new int[,] { { 2, 3, 4 }, { 1, 5, 9 } }));

    [TestMethod]
    public void GetMatrix_WrongLength_Throws()
        => Assert.ThrowsExactly<ArgumentException>(() => ds.GetMatrix("123", 5, 3));

    [TestMethod]
    public void GetMatrix_NonDigit_Throws()
        => Assert.ThrowsExactly<ArgumentException>(() => ds.GetMatrix("12a", 1, 3));
}
