using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class API13SceneUnloadSceneAsync : MonoBehaviour
{
  private PlayerInputs myInputs;
  private bool scneneIsLoaded = false;
  private AsyncOperation async;

  void Awake()
  {
    myInputs ??= new PlayerInputs();
  }

  void OnEnable()
  {
    myInputs.Enable();
    myInputs.Mouse.Space.performed += OnSpaceClick;
  }

  void OnDisable()
  {
    myInputs.Mouse.Space.performed -= OnSpaceClick;
    myInputs.Disable();
  }

  void OnSpaceClick(InputAction.CallbackContext context)
  {
    if (scneneIsLoaded)
    {
      StartCoroutine(UnloadSceneAsync());
    }
    else
    {
      StartCoroutine(LoadSceneAsync());
    }
  }

  IEnumerator UnloadSceneAsync(int sceneIndex = 1)
  {
    async = SceneManager.UnloadSceneAsync(sceneIndex);
    yield return async;
    // 卸载完成
    scneneIsLoaded = false;
  }

  IEnumerator LoadSceneAsync(int sceneIndex = 1)
  {
    async = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    while (!async.isDone)
    {
      yield return null;
    }
    // 加载完成
    scneneIsLoaded = true;
  }
}
