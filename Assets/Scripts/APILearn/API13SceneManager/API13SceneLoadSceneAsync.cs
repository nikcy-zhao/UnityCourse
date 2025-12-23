using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class API13SceneLoadSceneAsync : MonoBehaviour
{
  private PlayerInputs playerInputs;
  private AsyncOperation asyncOperation;

  void Awake()
  {
    playerInputs ??= new PlayerInputs();
  }

  void OnEnable()
  {
    playerInputs.Enable();
    playerInputs.Mouse.Space.performed += OnClick;
  }

  void OnDisable()
  {
    playerInputs.Mouse.Space.performed -= OnClick;
    playerInputs.Disable();
  }

  void OnClick(InputAction.CallbackContext context)
  {
    Debug.Log("Start Loading Scene Asynchronously");
    StartCoroutine(LoadMyAsyncScene());
  }


  private IEnumerator LoadMyAsyncScene(int sceneIndex = 1)
  {
    asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    asyncOperation.allowSceneActivation = false;

    while (!asyncOperation.isDone)
    {
      // progress 在 allowSceneActivation=false 时最多为 0.9
      float rawProgress = asyncOperation.progress; // 0.0 ~ 0.9
      float normalized = Mathf.Clamp01(rawProgress / 0.9f); // 归一化到 0..1
      // 每帧打印加载进度,F1表示保留一位小数
      Debug.Log($"【第{Time.frameCount}帧】场景加载进度: {normalized * 100f:F1}%");

      // 当达到 0.9（加载完成但未激活）时激活场景
      if (rawProgress >= 0.9f)
      {
        asyncOperation.allowSceneActivation = true;
      }

      yield return null;
    }

    Debug.Log("Scene load finished and activated.");
  }
}
