using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Life : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Destroy(){
        animator.SetTrigger("Destroy");
    }
}
