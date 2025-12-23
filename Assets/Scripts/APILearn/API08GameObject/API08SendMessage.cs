using UnityEngine;

public class API08SendMessage : MonoBehaviour
{
    void Start()
    {
        gameObject.SendMessage("MessageReceiver");
        gameObject.SendMessage("MessageReceiver2", "世界");
    }
}
