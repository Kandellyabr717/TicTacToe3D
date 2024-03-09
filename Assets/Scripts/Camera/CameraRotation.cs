using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private InputController _controller;
    [SerializeField] private float _speed;

    private void Update() =>
        _transform.Rotate(Vector3.up, _controller.GetRotationAngle() * _speed * 0.01f);
}