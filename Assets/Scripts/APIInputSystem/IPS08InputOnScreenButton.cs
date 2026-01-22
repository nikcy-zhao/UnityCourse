using UnityEngine;
using UnityEngine.InputSystem;

public class IPS08InputOnScreenButton : MonoBehaviour
{
  private PlayerInputs myInput;

  void Awake()
  {
    myInput ??= new PlayerInputs();
  }

  void OnEnable()
  {
    myInput.Enable();
    myInput.Player.Point.performed += OnPointPerformed;
  }

  void OnDisable()
  {
    myInput.Player.Point.performed -= OnPointPerformed;
    myInput.Disable();
  }

  private void OnPointPerformed(InputAction.CallbackContext context)
  {
    Debug.Log("hello world");
  }

}
