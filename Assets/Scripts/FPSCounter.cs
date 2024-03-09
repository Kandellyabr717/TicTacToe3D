using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Update() => _text.text = Mathf.Round(1f / Time.deltaTime).ToString();
}