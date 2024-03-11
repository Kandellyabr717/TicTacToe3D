using UnityEngine;

public class FullFieldRaycaster : FieldRaycaster
{
    [SerializeField] private FieldController _controller;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _length;
    [SerializeField] private LayerMask _layerMask;

    public override bool CheckLine(out CrossedLine line)
    {
        line = new ();
        var ray = new Ray(_transform.position, _transform.rotation * Vector3.right * _length);
        var hits = Physics.RaycastAll(ray, _length, _layerMask);
        if (hits.Length != _controller.FieldSize) return false;
        var sides = new Side[hits.Length];
        for (var i = 0; i < sides.Length; i++)
        {
            sides[i] = hits[i].collider.gameObject.GetComponent<SignData>().Side;
        }
        line = new (_transform.position, _transform.rotation, _length);
        var result = true;
        for (var i = 1; i < sides.Length; i++)
        {
            if (sides[i - 1] != sides[i]) result = false;
        }
        return result;
    }
}