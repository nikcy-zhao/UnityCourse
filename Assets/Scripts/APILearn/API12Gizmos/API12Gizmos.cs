using UnityEngine;

public class API12Gizmos : MonoBehaviour
{
    public Vector3 center = Vector3.zero;
    public Vector3 size = Vector3.one;
    public Color gizmosColor = Color.green;

    void OnDrawGizmos()
    {
        center = transform.position;
        Gizmos.color = gizmosColor;
        Gizmos.DrawCube(center, size);
    }
}
