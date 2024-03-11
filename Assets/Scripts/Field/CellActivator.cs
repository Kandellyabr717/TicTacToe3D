using UnityEngine;
using UnityEngine.EventSystems;

public class CellActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private FieldController _field;
    [SerializeField] private Transform _transform;

    public void OnPointerClick(PointerEventData eventData) => Activate();

    private void Activate()
    {
        Instantiate(_field.CurrentSign, _transform.position, Quaternion.identity, _transform);
        _field.CellActivated();
        enabled = false;
    }
}