using UnityEngine;
using UnityEngine.InputSystem;

public class IPS01InputActionAsset : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    void Start()
    {
        if (inputActionAsset != null)
        {
            inputActionAsset.Enable();
        }

        InputActionMap actionMap = inputActionAsset.FindActionMap("Player");
        Debug.Log("Action Map Name: " + actionMap.name);

        InputAction action = inputActionAsset.FindAction("Player/Move");
        Debug.Log("Action Name: " + action.ToString());

        InputAction action2 = inputActionAsset.FindAction("Scene/Move");
        Debug.Log("Action Name: " + action2.ToString());
    }
}
