using UnityEngine;
using UnityEngine.SceneManagement;

public class API13SceneProperties : MonoBehaviour
{
  void Start()
  {
    Debug.Log("加载的场景：" + SceneManager.loadedSceneCount);
    Debug.Log("当前场景：" + SceneManager.sceneCount);
    Debug.Log("构建的场景：" + SceneManager.sceneCountInBuildSettings);
  }
}
