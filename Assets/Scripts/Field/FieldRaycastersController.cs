using System.Collections.Generic;
using UnityEngine;

public class FieldRaycastersController : MonoBehaviour
{
    private List<FieldRaycaster> _raycasters;

    private void Awake()
    {
        _raycasters = new();
        for (var i = 0; i < transform.childCount; i++)
        {
            _raycasters.Add(transform.GetChild(i).GetComponent<FieldRaycaster>());
        }
    }

    public bool CheckComplitedLines(out CrossedLine line)
    {
        line = new ();
        var result = false;
        foreach (var raycaster in _raycasters) result = result || raycaster.CheckLine(out line);
        return result;
    }
}