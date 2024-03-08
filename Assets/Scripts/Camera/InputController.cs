using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputActions _input;

    private void Awake() => _input = new InputActions();

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private float _previousDistance;

    public float GetRotationAngle()
    {
        if (_input.Camera.Holded.ReadValue<float>() > 0)
        {
            var delta = _input.Camera.Rotation.ReadValue<Vector2>();
            delta.y = 0;
            return delta.x;
        }
        return 0;
    }

    public float GetScaleDelta()
    {
        return _input.Camera.Scale.ReadValue<float>();
        /*if (_input.Camera.SecondTouch.ReadValue<float>() > 0 && _input.Camera.SecondTouch.ReadValue<float>() > 0)
        {
            var firstPos = _input.Camera.FirstPosition.ReadValue<Vector2>();
            var secondPos = _input.Camera.SecondPosition.ReadValue<Vector2>();
            var distance = Vector2.Distance(firstPos, secondPos);
            if (_previousDistance == 0) distance = _previousDistance;
            var delta = distance - _previousDistance;
            _previousDistance = distance;
            return delta;

        }
        return 0;*/
    }
}