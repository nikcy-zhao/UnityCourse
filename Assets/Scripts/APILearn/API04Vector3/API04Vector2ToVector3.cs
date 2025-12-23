using UnityEngine;

public class API04Vector2ToVector3 : MonoBehaviour
{
    private Vector2 vector2 = Vector2.zero;
    private Vector3 vector3 = Vector3.zero;

    void Start()
    {
        vector2 = new Vector2(1, 1);
        // 将Vector2转换为Vector3，z轴设为0
        vector3 = new Vector3(vector2.x, 0, vector2.y);

        // 设置位置
        transform.position = vector3;
    }

    void Update()
    {
        // 每帧移动Vector2
        transform.position += new Vector3(vector2.x, 0, vector2.y) * Time.deltaTime;
    }
}
