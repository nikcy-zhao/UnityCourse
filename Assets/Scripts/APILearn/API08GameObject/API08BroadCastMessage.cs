using UnityEngine;

public class API08BroadCastMessage : MonoBehaviour
{
    void Start()
    {
        // 发送消息
        gameObject.BroadcastMessage("MessageReceiver");
        gameObject.BroadcastMessage("MessageReceiver2", "世界");
    }
}
