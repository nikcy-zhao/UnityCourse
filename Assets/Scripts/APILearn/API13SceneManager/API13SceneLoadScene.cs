using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class API13SceneLoadScene : MonoBehaviour
{
  private PlayerInputs inputs;

  private void Awake()
  {
    inputs ??= new PlayerInputs();
  }

  private void OnEnable()
  {
    inputs.Enable();
    inputs.Mouse.Click.performed += OnClick;
  }

  private void OnDisable()
  {
    inputs.Mouse.Click.performed -= OnClick;
    inputs.Disable();
  }

  private void OnClick(InputAction.CallbackContext context)
  {
    SceneManager.LoadScene(1, LoadSceneMode.Additive);
  }
}
