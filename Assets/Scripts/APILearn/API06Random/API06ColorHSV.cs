using UnityEngine;

public class API06ColorHSV : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Color color = Random.ColorHSV();
        Debug.DrawLine(transform.position, target.position, color);
    }

}
