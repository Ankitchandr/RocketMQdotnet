//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using ons;

//namespace ConsoleApplication3
//{
//        public class OnscSharp
//        {
//             private static string Ons_Topic = "xxxxxxxxxxx";
//            private static string Ons_ProducerID = "xxxxxxxxxxx";
//            private static string Ons_AccessKey = "xxxxxxxxxxxx";
//            private static string Ons_SecretKey = "xxxxxxxxxxxxxxx";
//            private static string Ons_ConsumerId = "xxxxxxxxxxxx";
//            public static void SendOrderMessage(string msgBody, String tag = "RegisterLog", String key = "test")
//            {
//                Message msg = new Message(Ons_Topic, tag, msgBody);
//                msg.setKey(Guid.NewGuid().ToString());
//                try
//                {
//                string shardingKey = "i am from bizruntime";
//                SendResultONS sendResult = _orderproducer.send(msg, shardingKey);
//                    Console.WriteLine("send success {0}", sendResult.getMessageId());
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("send failure{0}", ex.ToString());
//                }
//            }
//            public static void StartOrderProducer()
//            {
//                _orderproducer.start();
//            }
//            public static void ShutdownOrderProducer()
//            {
//                _orderproducer.shutdown();
//            }
//        private static ONSFactoryProperty getFactoryProperty()
//        {

//            ONSFactoryProperty factoryInfo = new ONSFactoryProperty();
//            factoryInfo.setFactoryProperty("Ons_AccessKey", Ons_AccessKey);
//            factoryInfo.setFactoryProperty("SecretKey", Ons_SecretKey);
//            factoryInfo.setFactoryProperty("ConsumerId", Ons_ConsumerId);
//            factoryInfo.setFactoryProperty("ProducerId", Ons_ProducerID);
//            factoryInfo.setFactoryProperty("PublishTopics", Ons_Topic);
//            return factoryInfo;
//        }
//        public static void CreateOrderProducer()
//        {
//            ONSFactory a = new ONSFactory();
//            _orderproducer = a.getInstance().createOrderProducer(getFactoryProperty());
//        }
//    }

//   class OrderProducerForEx
//    {
//        static void Main(string[] args)
//        {

//            OnscSharp.CreateOrderProducer();
//            OnscSharp.StartOrderProducer();
//            OnscSharp.StartOrderProducer();
//            System.DateTime beforDt = System.DateTime.Now;
//            for (int i = 0; i < 1000; ++i)
//            {
//                OnscSharp.SendOrderMessage("Test", "Tag", "key");
//            }
//            System.DateTime endDt = System.DateTime.Now;
//            System.TimeSpan ts = endDt.Subtract(beforDt);
//            Console.WriteLine("per message:{0}ms.", ts.TotalMilliseconds / 10000);
//            OnscSharp.ShutdownOrderProducer();

//        }
//    }
//}
