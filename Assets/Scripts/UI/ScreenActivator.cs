using UnityEngine;

public class ScreenActivator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Activate() => _animator.enabled = true;
}