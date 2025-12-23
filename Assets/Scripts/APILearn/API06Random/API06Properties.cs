using UnityEngine;

public class API06Properties : MonoBehaviour
{
    private float randomValue;
    private Vector2 randomCircle;
    private Vector3 randomInsideUnitSphere;
    private Vector3 randomOnUnitSphere;
    private Vector3 center = Vector3.zero;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        randomValue = Random.value;
        Debug.Log("Random.value: " + randomValue);

        // Random.insideUnitCircle: 生成一个在单位圆内的随机二维向量
        randomCircle = Random.insideUnitCircle * 5;
        transform.position = center + new Vector3(randomCircle.x, 0, randomCircle.y);
        Debug.DrawLine(center, transform.position, Color.red);

        // Random.insideUnitSphere: 生成一个在单位球内的随机三维向量
        randomInsideUnitSphere = Random.insideUnitSphere * 5;
        transform.position = center + randomInsideUnitSphere;
        Debug.DrawLine(center, transform.position, Color.blue);

        // Random.onUnitSphere: 生成一个在单位球面上的随机三维向量
        randomOnUnitSphere = Random.onUnitSphere * 5;
        transform.position = center + randomOnUnitSphere;
        Debug.DrawLine(center, transform.position, Color.green);

    }
}
