using System.Collections;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _crossWinScreen;
    [SerializeField] private GameObject _circleWinScreen;
    [SerializeField] private GameObject _drawScreen;
    [SerializeField] private TurningSideUpdater _turningSide;

    public void UpdateTruningSideText(Side side) => _turningSide.UpdateState(side);

    public void ActivateWinScreen(Side side) => StartCoroutine(ActivateWinScreenDelay(side));

    private IEnumerator ActivateWinScreenDelay(Side side)
    {
        yield return new WaitForSeconds(1);
        if (side == Side.Cross) Instantiate(_crossWinScreen, _transform);
        if (side == Side.Circle) Instantiate(_circleWinScreen, _transform);
    }

    public void ActivateDrawScreen() => StartCoroutine(ActivateDrawScreenDelay());

    private IEnumerator ActivateDrawScreenDelay()
    {
        yield return new WaitForSeconds(1);
        Instantiate(_drawScreen, _transform);
    }
}