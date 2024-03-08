using UnityEngine;
using UnityEngine.Events;

public class FieldController : MonoBehaviour
{
    [SerializeField] private FieldRaycastersController _raycasters;
    [SerializeField] private CellsDisabler _cellsDisabler;
    [SerializeField] private LineCrosserController _lineCrosser;
    [SerializeField] private GameObject _crossSign;
    [SerializeField] private GameObject _circleSign;
    [SerializeField] private UnityEvent<Side> OnTurningSideChange;
    [SerializeField] private UnityEvent<Side> OnWin;
    [SerializeField] private UnityEvent OnDraw;

    public GameObject CurrentSign
    {
        get
        {
            if (_currentSide == Side.Cross) return _crossSign;
            return _circleSign;
        }
    }

    private Side _currentSide = Side.Cross;
    private int _cellsClosed;

    private void UpdateState() => _cellsClosed++;

    private void ChangeTurningSide()
    {
        if (_currentSide == Side.Cross) _currentSide = Side.Circle;
        else _currentSide = Side.Cross;
        OnTurningSideChange?.Invoke(_currentSide);
    }

    private bool CheckForWin(out CrossedLine line) => _raycasters.CheckComplitedLines(out line);

    private void SetWin(CrossedLine line)
    {
        _lineCrosser.CrossLine(line);
        _cellsDisabler.DisableCells();
        OnWin?.Invoke(_currentSide);
    }

    private bool CheckForDraw() => _cellsClosed == 9;

    private void SetDraw()
    {
        _cellsDisabler.DisableCells();
        OnDraw?.Invoke();
    }

    public void CellActivated(Vector2 coords)
    {
        UpdateState();
        if (CheckForWin(out CrossedLine line))
        {
            SetWin(line);
            return;
        }
        if (CheckForDraw())
        {
            SetDraw();
            return;
        }
        ChangeTurningSide();
    }
}

public enum Side
{
    Neutral = 0,
    Cross = 1,
    Circle = 2
}