using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ons;
using std;
using System.Threading;

namespace ConsoleApplication1
{
    class Producer
    {
        static void Main(string[] args)
        {
            ONSFactoryProperty factoryInfo = new ONSFactoryProperty();
            factoryInfo.setFactoryProperty(factoryInfo.getProducerIdName(), "PID_1234");
            Console.WriteLine("ProducerId:{0}, \nConsumerId:{1},\nPublishTopics:{2},\nMsgContent:{3},\nAccessKey::{4},\nSecretKey::{5} ",
                factoryInfo.getProducerId(), factoryInfo.getConsumerId(), factoryInfo.getPublishTopics(),
                factoryInfo.getMessageContent(), factoryInfo.getAccessKey(), factoryInfo.getSecretKey());

            ONSFactory onsfactory = new ONSFactory();

            OrderProducer pProducer = onsfactory.getInstance().createOrderProducer(factoryInfo);

            pProducer.start();

            string key = "abc";
            for (int i = 0; i < 20; ++i)
            {
                Message msg = new Message("Ram_Topic_2", "TagA", "msg from for loop => " + i);
                try
                {
                    SendResultONS sendResult = pProducer.send(msg, key);
                    Console.WriteLine("=> send success : {0} ", sendResult.getMessageId());
                }
                catch (ONSClientException e)
                {
                    Console.WriteLine("\nexception of sendmsg:{0}", e.what());
                }
            }

            Thread.Sleep(1000 * 100);
            pProducer.shutdown();


        }
    }
}
