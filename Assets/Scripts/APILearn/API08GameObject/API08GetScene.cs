using UnityEngine;
using UnityEngine.SceneManagement;

public class API08GetScene : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Scene scene = GameObject.GetScene(player.GetInstanceID());
            Debug.Log("场景名称：" + scene.name);
        }
    }
}
