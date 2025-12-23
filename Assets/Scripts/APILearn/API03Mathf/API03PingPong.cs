using UnityEngine;

public class API03PingPong : MonoBehaviour
{
    public float t = 0f;
    public float length = 10f;
    public float speed = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (t > 6 * length) return;
        float value = Mathf.PingPong(t, length);
        transform.position = startPos + Vector3.forward * value;
        t += Time.deltaTime * speed;
    }
}
