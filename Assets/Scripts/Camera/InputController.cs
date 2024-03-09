using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputActions _input;

    private void Awake() => _input = new InputActions();

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public float GetRotationAngle()
    {
        if (_input.Camera.Holded.ReadValue<float>() > 0)
        {
            return _input.Camera.Rotation.ReadValue<float>();
        }
        return 0;
    }

    public float GetScaleDelta() => _input.Camera.Scale.ReadValue<float>();
}