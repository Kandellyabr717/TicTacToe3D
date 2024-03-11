using UnityEngine;

public abstract class FieldRaycaster : MonoBehaviour
{
    public abstract bool CheckLine(out CrossedLine line);
}