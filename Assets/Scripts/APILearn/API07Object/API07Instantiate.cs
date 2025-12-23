using UnityEngine;

public class API07Instantiate : MonoBehaviour
{
    // 要动态实例化的对象
    public Object target;
    // 实例化的数量
    public int count = 5;
    // 半径范围
    public float radius = 10f;
    // 实例化的位置
    private Vector3 targetPosition = Vector3.zero;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            // 随机生成一个点
            Vector2 randomPosition = Random.insideUnitCircle * radius;
            // 随机生成一个旋转角度
            Quaternion randomRotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
            // 以当前物体位置为中心，生成目标位置
            targetPosition = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);
            // 实例化对象
            Object instance = Instantiate<Object>(target, targetPosition, randomRotation, transform);
            instance.name = "Instance " + i;
        }
    }
}
