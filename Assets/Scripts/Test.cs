using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{

    [Inject] private MessageBroker broker;

    private void Start()
    {
        Test1();
    }

    private void Test1()
    {
        broker.Publish(new PointMessage(transform));
        broker.Publish(new OctopusSpawnMessage());
        broker.Publish(new StartInputMessage());
    }
}
