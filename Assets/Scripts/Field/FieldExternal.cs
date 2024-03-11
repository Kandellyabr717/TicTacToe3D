using UnityEngine;
using UnityEngine.Events;

public class FieldExternal : MonoBehaviour
{
    [SerializeField] private UnityEvent<Side> OnTurningSideChange;
    [SerializeField] private UnityEvent<Side> OnWin;
    [SerializeField] private UnityEvent OnDraw;

    public void TurningSideChange(Side side) => OnTurningSideChange?.Invoke(side);
    public void Win(Side side) => OnWin?.Invoke(side);

    public void Draw() => OnDraw?.Invoke();
}