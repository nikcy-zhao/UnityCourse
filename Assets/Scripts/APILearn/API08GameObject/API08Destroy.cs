using UnityEngine;

public class API08Destroy : MonoBehaviour
{
    void Start()
    {
        API02Time time = this.gameObject.AddComponent<API02Time>();
        Destroy(time);
    }
}
