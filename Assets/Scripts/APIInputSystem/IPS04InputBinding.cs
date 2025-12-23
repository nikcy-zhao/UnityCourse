using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;  // 引入增强触摸支持

public class IPS04InputBinding : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    private InputAction action;

    void Start()
    {
        // 启用 Enhanced Touch Support
        EnhancedTouchSupport.Enable();

        if (inputActionAsset == null)
        {
            Debug.LogError("InputActionAsset is null");
            return;
        }

        action = inputActionAsset.FindAction("Player/Test");
        action.performed += OnActionPerformed;
    }

    void OnActionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Test Action Performed");
        Debug.Log($"Device: {context.control.device}");
    }
}
