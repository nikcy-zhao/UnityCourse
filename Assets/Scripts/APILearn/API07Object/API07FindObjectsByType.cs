using UnityEngine;

public class API07FindObjectsByType : MonoBehaviour
{
    void Start()
    {
        API07Instantiate[] targets = FindObjectsByType<API07Instantiate>(FindObjectsSortMode.InstanceID);

        foreach (API07Instantiate target in targets)
        {
            Debug.Log("找到目标" + target.GetInstanceID() + ":" + target.name);
        }
    }

}
