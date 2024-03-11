using UnityEngine;

public class FieldController : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private FieldExternal _external;
    [SerializeField] private FieldRaycastersController _raycasters;
    [SerializeField] private CellsDisabler _cellsDisabler;
    [SerializeField] private LineCrosserController _lineCrosser;
    [SerializeField] private GameObject _crossSign;
    [SerializeField] private GameObject _circleSign;

    public GameObject CurrentSign
    {
        get
        {
            if (_currentSide == Side.Cross) return _crossSign;
            return _circleSign;
        }
    }
    public int FieldSize => _controller.FieldSize;

    private Side _currentSide = Side.Cross;
    private int _cellsClosed;

    public void SetLinks(GameController controller, FieldExternal external)
    {
        _controller = controller;
        _external = external;
    }

    private void UpdateState() => _cellsClosed++;

    private void ChangeTurningSide()
    {
        if (_currentSide == Side.Cross) _currentSide = Side.Circle;
        else _currentSide = Side.Cross;
        _external.TurningSideChange(_currentSide);
    }

    private bool CheckForWin(out CrossedLine line) => _raycasters.CheckComplitedLines(out line);

    private void SetWin(CrossedLine line)
    {
        _lineCrosser.CrossLine(line);
        _cellsDisabler.DisableCells();
        _external.Win(_currentSide);
    }

    private bool CheckForDraw() => _cellsClosed == _controller.FieldSize * _controller.FieldSize;

    private void SetDraw()
    {
        _cellsDisabler.DisableCells();
        _external.Draw();
    }

    public void CellActivated()
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