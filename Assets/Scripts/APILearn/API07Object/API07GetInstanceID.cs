using UnityEngine;

public class API07GetInstanceID : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }

        // 判断是否是同一个实例
        if (target.GetInstanceID() == GetInstanceID())
        {
            Debug.Log("是同一个实例,ID:" + GetInstanceID());
        }
        else
        {
            Debug.Log(GetInstanceID() + "与" + target.GetInstanceID() + "不是同一个实例");
        }
    }
}
