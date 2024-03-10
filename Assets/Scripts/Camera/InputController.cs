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
            var rotation = _input.Camera.Rotation.ReadValue<Vector2>();
            if (Mathf.Abs(rotation.x) > Mathf.Abs(rotation.y)) return rotation.x;
        }
        return 0;
    }

    public float GetScaleDelta()
    {
        var scale = _input.Camera.Scale.ReadValue<Vector2>();
        if (Mathf.Abs(scale.y) > Mathf.Abs(scale.x)) return scale.y;
        return 0;
    }
}