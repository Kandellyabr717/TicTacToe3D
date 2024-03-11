using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _fieldSize;
    [SerializeField] private int _sceneIndex;

    public int FieldSize { get => _fieldSize; }
    public int SceneIndex { get => _sceneIndex; }

    private void Awake()
    {
        Application.targetFrameRate = 100;
        var data = FindFirstObjectByType<GameData>();
        if (data == null) return;
        _fieldSize = data.FieldSize;
    }
}