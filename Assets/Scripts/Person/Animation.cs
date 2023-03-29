using UnityEngine;

public class Animation : MonoBehaviour
{
    const string JumpTrigger = "Jump";
    const string IsWalk = "IsWalk";

    [SerializeField] private Animator _animator;

    public void Jump()
    {
        _animator.SetTrigger(JumpTrigger);
    }

    public void Walk()
    {
        _animator.SetBool(IsWalk, true);
    }

    public void Idle()
    {
        _animator.SetBool(IsWalk, false);
    }
}
