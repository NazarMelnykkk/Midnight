using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void Horizontal(float hzInput)
    {
        _animator.SetFloat("hzInput", hzInput);
    }

    public void Vertical(float vInput)
    {
        _animator.SetFloat("vInput", vInput);
    }

    public void Walk(bool value)
    {
        _animator.SetBool("Walking", value);
    }

    public void Run(bool value)
    {
        _animator.SetBool("Running", value);
    }

    public void Jump(bool value)
    {
        _animator.SetBool("Jumping", value);
        
    }

    public void Aim(bool value)
    {
        _animator.SetBool("Aiming", value);
    }

    public void Reload()
    {
        _animator.SetTrigger("Reload");
    }
}
