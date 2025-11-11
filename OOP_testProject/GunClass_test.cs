//using Microsoft.VisualStudio.TestTools.UnitTesting;

using OOP_Lab1;
namespace TestProject1
{
    [TestClass]
    public sealed class GunClass_test
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        //#region reload tests
        //[TestMethod]
        //public void Test_ReloadToFull()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 20;
        //    test_item.Loaded_ammo = 10; test_item.Max_ammo = 20; test_item.Ammo_reserve = 20;

        //    test_item.reload();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_ReloadPartial()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 15;
        //    test_item.Loaded_ammo = 0; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.reload();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_ReloadAlreadyFull()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 20;
        //    test_item.Loaded_ammo = 20; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.reload();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]    
        //public void Test_ReloadNoReserve()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 15;
        //    test_item.Loaded_ammo = 15; test_item.Max_ammo = 20; test_item.Ammo_reserve = 0;

        //    test_item.reload();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //#endregion
        //#region Firing tests
        //[TestMethod]
        //public void Test_FireOneRound()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 14;
        //    test_item.Loaded_ammo = 15; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.Fire();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireOneRoundFailed()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 0;
        //    test_item.Loaded_ammo = 0; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.Fire();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireTenRounds()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 10;
        //    test_item.Loaded_ammo = 20; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.FireTenRounds();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireTenRoundsStoppedShort()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 0;
        //    test_item.Loaded_ammo = 5; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.FireTenRounds();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireTenRoundsFailed()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 0;
        //    test_item.Loaded_ammo = 0; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.FireTenRounds();
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireSome()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 15;
        //    test_item.Loaded_ammo = 20; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.Fire(5);
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Test_FireSomeStoppedShort()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 0;
        //    test_item.Loaded_ammo = 5; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.Fire(10);
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_FireSomeRoundsFailed()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 0;
        //    test_item.Loaded_ammo = 0; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;

        //    test_item.Fire(10);
        //    int actual = test_item.Loaded_ammo;

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_TotalShotsCHeck()
        //{
        //    GunBase_Class test_item = new();
        //    int expected = 20;
        //    test_item.Loaded_ammo = 25; test_item.Max_ammo = 25; test_item.Ammo_reserve = 25;

        //    test_item.Fire(20);
        //    int actual = GunBase_Class.total_amount_of_shots;

        //    Assert.AreEqual(expected, actual);
        //}
        //#endregion 

    }
}
