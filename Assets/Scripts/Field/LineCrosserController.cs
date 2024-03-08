using System.Collections;
using UnityEngine;

public class LineCrosserController : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _crosser;

    public void CrossLine(CrossedLine line) => StartCoroutine(CrossLineDelay(line));

    private IEnumerator CrossLineDelay(CrossedLine line)
    {
        _transform.position = line.Start + new Vector3(0, _transform.position.y, 0);
        _transform.rotation = line.Rotation;
        _transform.localScale = new Vector3(line.Length, 1, 1);
        yield return new WaitForSeconds(1);
        Instantiate(_crosser, _transform);
        enabled = false;
    }
}

public struct CrossedLine
{
    public Vector3 Start => _start;
    public Quaternion Rotation => _rotation;
    public float Length => _length;

    private readonly Vector3 _start;
    private readonly Quaternion _rotation;
    private readonly float _length;

    public CrossedLine(Vector3 start, Quaternion rotation, float length)
    {
        _start = start;
        _rotation = rotation;
        _length = length;
    }
}