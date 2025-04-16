using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RacoonsAnimation : MonoBehaviour
{
  private Animator _animator;
  
  private const string ATTACK_ANIM = "IsAttacking";
  private const string DEATH_ANIM = "Death";

  private void Start()
  {
    _animator = GetComponent<Animator>();
  }
  public void PlayAttackAnimation(bool isAttacking)
  {
    _animator.SetBool(ATTACK_ANIM,isAttacking);
  }

  public void PlayDeathAnimation()
  {
    _animator.SetTrigger("Death");
  }

  
}
