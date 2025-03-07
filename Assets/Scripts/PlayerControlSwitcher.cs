using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerControlSwitcher : MonoBehaviour
{
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // ตรวจสอบอุปกรณ์ของ Player นี้เท่านั้น
        InputDevice currentDevice = playerInput.devices.Count > 0 ? playerInput.devices[0] : null;

        // ถ้า Player ใช้ Keyboard อยู่ และกดปุ่มจากจอย  สลับไปใช้ Gamepad
        if (currentDevice is Keyboard && Gamepad.all.Count > playerInput.playerIndex)
        {
            foreach (var control in Gamepad.all[playerInput.playerIndex].allControls)
            {
                if (control is ButtonControl button && button.wasPressedThisFrame)
                {
                    playerInput.SwitchCurrentControlScheme("Gamepad", Gamepad.all[playerInput.playerIndex]);
                    break;
                }
            }
        }

        // ถ้า Player ใช้ Gamepad อยู่ และกดปุ่มจาก Keyboard  สลับไปใช้ Keyboard
        if (currentDevice is Gamepad && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current);
        }
    }
}
