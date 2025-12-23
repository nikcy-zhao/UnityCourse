using UnityEngine;

public class API03SmoothStep : MonoBehaviour
{
    public float from = 0f;
    public float to = 10;
    public float t;

    void Update()
    {
        t += 0.1f;
        float value = Mathf.SmoothStep(from, to, t);
        Debug.Log(value);
    }

}
