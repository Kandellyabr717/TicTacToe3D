using UnityEngine;

public class FieldRaycaster : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _length;
    [SerializeField] private LayerMask _layerMask;

    public bool CheckLine(out CrossedLine line)
    {
        line = new ();
        var ray = new Ray(_transform.position, _transform.rotation * Vector3.right * _length);
        var hits = Physics.RaycastAll(ray, _length, _layerMask);
        if (hits.Length != _controller.FieldSize) return false;
        var first = hits[0].collider.gameObject.GetComponent<SignData>().Side;
        var second = hits[1].collider.gameObject.GetComponent<SignData>().Side;
        var third = hits[2].collider.gameObject.GetComponent<SignData>().Side;
        line = new (_transform.position, _transform.rotation, _length);
        return first == second && second == third;
    }
}