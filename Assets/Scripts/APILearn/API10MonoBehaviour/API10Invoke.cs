using UnityEngine;

public class API10Invoke : MonoBehaviour
{
    void Start()
    {
        // 调用方式1：直接调用一个方法
        CallPrintMessage();
        // 调用方式2：使用SendMessage方法调用一个方法
        gameObject.SendMessage("SentMessage");

        // 调用方式3：使用Invoke方法调用一个方法
        Invoke(nameof(PrintMessage), 1f);

        // 使用InvokeRepeating方法重复调用一个方法,2秒后开始调用PrintMessage方法，每隔1秒调用一次
        InvokeRepeating(nameof(PrintMessage2), 2f, 1f);

        // 使用CancelInvoke方法取消Invoke方法
        CancelInvoke(nameof(PrintMessage)); // 取消PrintMessage方法的调用

    }

    public void CallPrintMessage()
    {
        Debug.Log("CallPrintMessage方法被调用");
    }

    public void SentMessage()
    {
        Debug.Log("SendMessage方法被调用");
    }

    public void PrintMessage()
    {
        Debug.Log("Invoke方法调用的消息");
    }

    public void PrintMessage2()
    {
        Debug.Log("InvokeRepeating方法调用的消息");
    }
}
