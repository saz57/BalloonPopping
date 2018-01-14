
using UnityEngine;

public class AfterPoppingEffectBehaviour : StateMachineBehaviour {


   public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        GameObject.Destroy(animator.gameObject);
    }
}
