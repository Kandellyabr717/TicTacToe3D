using UnityEngine;

public class CameraScale : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputController _controller;
    [SerializeField] private float _scaleMax;
    [SerializeField] private float _scaleMin;
    [SerializeField] private float _speed;

    private void Update()
    {
        var scale = _camera.orthographicSize + _controller.GetScaleDelta() * _speed * -0.001f;
        scale = Mathf.Clamp(scale, _scaleMin, _scaleMax);
        _camera.orthographicSize = scale;
    }
}