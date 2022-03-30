using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTest;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //无重性添加测试
        [TestMethod]
        public void TestMethod1()
        {
            Client client1 = new Client("aaa", 111111);
            Client client2 = new Client("aaa", 222222);
            Order order1 = new Order(client1);
            Order order2 = new Order(client2);
            OrderService.add_order(order1);
            Assert.IsFalse( OrderService.add_order(order2));
        }
        //计算金额测试
        [TestMethod]
        public void TestMethod2()
        {
            Client client1 = new Client("aaa", 111111);
            Order order1 = new Order(client1);
            order1.add(Goods.goods1,1);
            order1.add(Goods.goods2, 2);
            order1.add(Goods.goods3, 3);
            order1.add(Goods.goods4, 5);
            order1.reduce(Goods.goods4, 1);
            order1.delete(Goods.goods2);
            Assert.IsTrue(order1.sum_money==45.0);
        }
        //存储、导入xml测试
        [TestMethod]
        public void TestMethod3()
        {
            Client client1 = new Client("aaa", 111111);
            Client client2 = new Client("bbb", 222222);
            Client client3 = new Client("ccc", 333333);

            Order order1 = new Order(client1);
            Order order2 = new Order(client2);
            Order order3 = new Order(client3);

            order1.add(Goods.goods2);
            order1.add(Goods.goods1, 2);
            order1.add(Goods.goods3);
            order1.add(Goods.goods4);
            order1.add(Goods.goods5);
            order2.add(Goods.goods4);
            order2.add(Goods.goods5);
            order3.add(Goods.goods3, 2);
            order3.add(Goods.goods4, 3);
            order3.add(Goods.goods5);
            OrderService.add_order(order1);
            OrderService.add_order(order2);
            OrderService.add_order(order3);
            OrderService.export("D:\\test\\test");

            OrderService.orders.Clear();
            OrderService.import("D:\\test\\test\\orders.xml");
            List<Order> ords = new List<Order>();
            ords.Add(order1);
            ords.Add(order2);
            ords.Add(order3);
            CollectionAssert.Equals(OrderService.orders,ords);
        }

    }
}
