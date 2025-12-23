using UnityEngine;

public class API04Nomalized : MonoBehaviour
{
    public Transform target;
    public Vector3 vector1 = Vector3.zero;
    public Vector3 vector2 = Vector3.zero;
    public Vector3 vector3 = Vector3.zero;

    void Start()
    {
        vector1 = target.position - transform.position;
        vector2 = transform.forward;
        vector3 = transform.up;

        // Vector3.OrthoNormalize(ref vector1, ref vector2);
        Vector3.OrthoNormalize(ref vector1, ref vector2, ref vector3);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, vector1 * 10, Color.green);
        Debug.DrawRay(transform.position, vector2 * 10, Color.blue);
        Debug.DrawRay(transform.position, vector3 * 10, Color.red);
    }
}
