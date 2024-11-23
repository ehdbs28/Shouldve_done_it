using UnityEngine;
using UnityEngine.AI;
public class Walk_Character : MonoBehaviour
{
    [field:SerializeField] public Walk_TargetPosSO TargetPosSO { get; private set; }
    private Walk_Animator _animator;
    private NavMeshAgent _agent;
    private Scene_WalkEpisode _walkEpisode;
    public virtual void Setting(Scene_WalkEpisode walkEpisode)
    {
        _agent    ??=            GetComponent<NavMeshAgent>();
        _animator ??=            GetComponentInChildren<Walk_Animator>();
        _animator.               Setting();
        
        _walkEpisode             = walkEpisode;

        _agent.                  SetDestination(TargetPosSO.targetPos);
        _animator.               SetSpeed(1f);
    }
}
