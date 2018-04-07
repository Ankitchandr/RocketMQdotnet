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

    public class MyMsgListener : MessageOrderListener
    {
        public MyMsgListener()
        {
        }

        ~MyMsgListener()
        {
        }

        public override OrderAction consume(ref Message value)
        {
            byte[] bbody = value.getBody();
            string body = Encoding.UTF8.GetString(bbody);
            Console.WriteLine(body);
            return ons.OrderAction.Success;
        }
    }

    class Consumer
    {
        static void Main(string[] args)
        {

            ONSFactoryProperty factoryInfo = new ONSFactoryProperty();

            factoryInfo.setFactoryProperty(factoryInfo.getConsumerIdName(), "CID_5678");

            Console.WriteLine("ProducerId:{0}, \nConsumerId:{1},\nPublishTopics:{2},\nMsgContent:{3},\nAccessKey::{4},\nSecretKey::{5} ",
                factoryInfo.getProducerId(), factoryInfo.getConsumerId(), factoryInfo.getPublishTopics(),
                factoryInfo.getMessageContent(), factoryInfo.getAccessKey(), factoryInfo.getSecretKey());

            ONSFactory onsfactory = new ONSFactory();

            OrderConsumer pConsumer = onsfactory.getInstance().createOrderConsumer(factoryInfo);

            MessageOrderListener msgListener = new MyMsgListener();

            pConsumer.subscribe("Ram_Topic_2", "*", ref msgListener);

            pConsumer.start();

            Thread.Sleep(10000 * 100);

            pConsumer.shutdown();
        }

    }
}
