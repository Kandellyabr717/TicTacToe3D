using UnityEngine;

public class GameData : MonoBehaviour
{
    public int FieldSize { get; private set; }

    private void Awake() => DontDestroyOnLoad(gameObject);

    public void SetFieldSize(int field) => FieldSize = field;
}