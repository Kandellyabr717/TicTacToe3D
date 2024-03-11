using UnityEngine;

public class FieldBuilder : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private FieldExternal _external;
    [SerializeField] private GameObject _field3x3;
    [SerializeField] private GameObject _field4x4;
    [SerializeField] private GameObject _field5x5;

    private void Start()
    {
        if (_controller.FieldSize == 3) BuildField(_field3x3);
        if (_controller.FieldSize == 4) BuildField(_field4x4);
        if (_controller.FieldSize == 5) BuildField(_field5x5);
    }

    private void BuildField(GameObject prefab)
    {
        var field = Instantiate(prefab);
        var contoller = field.GetComponent<FieldController>();
        contoller.SetLinks(_controller, _external);
    }
}