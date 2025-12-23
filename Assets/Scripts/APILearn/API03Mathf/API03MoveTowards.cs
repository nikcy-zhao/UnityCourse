using UnityEngine;

public class API03MoveTowards : MonoBehaviour
{
    public float current = 0f;
    public float target = 100f;
    public float maxDelta = 10f;

    void Update()
    {
        if (current == target) return;
        current = Mathf.MoveTowards(current, target, maxDelta);
        Debug.Log(current);
    }
}
