using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private CinemachineInputAxisController inputController;

    void Update()
    {
        bool isRightClickHeld = Mouse.current != null && Mouse.current.rightButton.isPressed;

        inputController.enabled = isRightClickHeld;
    }
}
