using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animControler;

    public void CallAnim(int num)
    {
        animControler.SetInteger("choice",num);
    }
}
