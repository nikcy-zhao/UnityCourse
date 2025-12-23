using UnityEngine;
using UnityEngine.SceneManagement;

public class API13SceneSetActiveScene : MonoBehaviour
{
  void Start()
  {
    // 获取激活场景
    Debug.Log(SceneManager.GetActiveScene().name);

    // 加载新场景
    SceneManager.LoadScene(1, LoadSceneMode.Additive);

    // 注册场景加载完成事件
    SceneManager.sceneLoaded += OnSceneLoaded;

    this.enabled = false;
  }

  void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    // 获取激活前场景
    Debug.Log(SceneManager.GetActiveScene().name);
    Debug.Log("加载新场景：" + scene.name);
    Debug.Log("加载模式：" + mode);

    // 设置激活场景
    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    Debug.Log(SceneManager.GetActiveScene().name);
  }
}
