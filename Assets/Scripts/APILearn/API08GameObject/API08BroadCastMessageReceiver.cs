using UnityEngine;

public class API08BraodCastMessageReceiver : MonoBehaviour
{
    // 接收BroadCastMessage发送的消息
    public void MessageReceiver()
    {
        Debug.Log(gameObject.name + "收到消息：你好，中国");
    }

    public void MessageReceiver2(string name)
    {
        Debug.Log(gameObject.name + "收到消息：你好，" + name);
    }
}
