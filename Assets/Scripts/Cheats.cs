using UnityEngine;

public class Cheats : MonoBehaviour
{
    [SerializeField] private GameObject _crossSing;

    public void Activate()
    {
        var arr = GameObject.FindGameObjectsWithTag("Sign");
        foreach (var obj in arr)
        {
            var parent = obj.transform.parent;
            var position = obj.transform.position;
            Destroy(obj);
            Instantiate(_crossSing, position, Quaternion.identity, parent);
        }
    }
}