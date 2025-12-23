using UnityEngine;

public class API05FromToRotation : MonoBehaviour
{
    void Update()
    {
        //从游戏对象的正前方向到目标方向的旋转
        transform.rotation *= Quaternion.FromToRotation(transform.forward, Vector3.back);
    }
}
