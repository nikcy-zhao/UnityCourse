using UnityEngine;
using UnityEngine.SceneManagement;

public class API13SceneGetActiveScene : MonoBehaviour
{
  void Start()
  {
    // 获取当前活动场景
    Scene activeScene = SceneManager.GetActiveScene();
    Debug.Log("Active Scene: " + activeScene.name);
  }
}
