using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurningSideUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _crossSprite;
    [SerializeField] private Sprite _circleSprite;

    public void UpdateState(Side side)
    {
        if (side == Side.Cross)
        {
            _text.text = "Cross";
            _text.color = Color.black;
            _image.sprite = _crossSprite;
            return;
        }
        _text.text = "Circle";
        _text.color = Color.white;
        _image.sprite = _circleSprite;
    }
}