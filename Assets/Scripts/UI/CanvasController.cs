using System.Collections;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Animator _crossWinScreen;
    [SerializeField] private Animator _circleWinScreen;
    [SerializeField] private Animator _drawScreen;
    [SerializeField] private TurningSideUpdater _turningSide;

    public void UpdateTruningSideText(Side side) => _turningSide.UpdateState(side);

    public void ActivateWinScreen(Side side) => StartCoroutine(ActivateWinScreenDelay(side));

    private IEnumerator ActivateWinScreenDelay(Side side)
    {
        yield return new WaitForSeconds(1);
        if (side == Side.Cross) _crossWinScreen.enabled = true;
        if (side == Side.Circle) _circleWinScreen.enabled = true;
    }

    public void ActivateDrawScreen() => StartCoroutine(ActivateDrawScreenDelay());

    private IEnumerator ActivateDrawScreenDelay()
    {
        yield return new WaitForSeconds(1);
        _drawScreen.enabled = true;
    }
}