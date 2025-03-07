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
        // ��Ǩ�ͺ�ػ�ó�ͧ Player �����ҹ��
        InputDevice currentDevice = playerInput.devices.Count > 0 ? playerInput.devices[0] : null;

        // ��� Player �� Keyboard ���� ��С������ҡ���  ��Ѻ��� Gamepad
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

        // ��� Player �� Gamepad ���� ��С������ҡ Keyboard  ��Ѻ��� Keyboard
        if (currentDevice is Gamepad && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current);
        }
    }
}
