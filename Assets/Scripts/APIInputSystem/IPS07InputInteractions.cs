using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class IPS07InputInteractions : MonoBehaviour
{
  // 用于使用Input System
  private PlayerInputs myInput;
  private Camera mainCamera;
  private Color intialColor;
  private Transform target;

  // private Renderer targetRenderer;

  void Awake()
  {
    myInput ??= new PlayerInputs();
    mainCamera = Camera.main;
  }

  void OnEnable()
  {
    // 启用输入系统
    myInput.Enable();

    // 取消订阅事件,防止重复订阅
    myInput.Mouse.Click.started -= OnMouseClick;
    myInput.Mouse.Click.performed -= OnMouseClick;
    myInput.Mouse.Click.canceled -= OnMouseClick;

    // 订阅鼠标点击事件
    myInput.Mouse.Click.started += OnMouseClick;
    myInput.Mouse.Click.performed += OnMouseClick;
    myInput.Mouse.Click.canceled += OnMouseClick;
  }

  void OnDisable()
  {
    // 取消订阅事件
    myInput.Mouse.Click.started -= OnMouseClick;
    myInput.Mouse.Click.performed -= OnMouseClick;
    myInput.Mouse.Click.canceled -= OnMouseClick;
    // 禁用输入系统
    myInput.Disable();
  }

  private void OnMouseClick(InputAction.CallbackContext context)
  {
    if (context.interaction is HoldInteraction hold)
      OnHoldInteraction(context, hold);
  }

  void OnHoldInteraction(InputAction.CallbackContext context, HoldInteraction hold)
  {
    Debug.Log($"Press Interaction: {context.phase}, time={context.time}, duration={hold.duration}");
  }

  // 通过鼠标选择目标物体
  private void SelectTarget()
  {
    Vector2 mousePosition = Mouse.current.position.ReadValue();
    Ray ray = mainCamera.ScreenPointToRay(mousePosition);
    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~LayerMask.GetMask("Plane")))
    {
      if (hitInfo.transform != null)
      {
        target = hitInfo.transform;
        intialColor = target.GetComponent<Renderer>().material.color;
      }
    }
  }
}

