using UnityEngine;

public class API03Repeat : MonoBehaviour
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
        if (t > 3 * length) return;
        float value = Mathf.Repeat(t, length);
        transform.position = startPos + Vector3.forward * value;
        t += Time.deltaTime * speed;
    }
}
