using System.Collections.Generic;
using UnityEngine;

public class CellsDisabler : MonoBehaviour
{
    private List<CellActivator> _activators;

    private void Awake()
    {
        _activators = new();
        for (var i = 0;  i < transform.childCount; i++)
        {
            _activators.Add(transform.GetChild(i).GetComponent<CellActivator>());
        }
    }

    public void DisableCells()
    {
        foreach (var cell in _activators) cell.enabled = false;
    }
}