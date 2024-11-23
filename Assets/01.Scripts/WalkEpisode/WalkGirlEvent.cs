using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class WalkGirlEvent : WalkEpisodeEvent
{
    public GameObject girlPrefab;
    private GameObject _girl;
    
    public override void OnProcess()
    {
        base.OnProcess();
        
        if (GameManager.Instance.CurrentScene is not Scene_WalkEpisode walk)
        {
            return;
        }

        var girlPos = walk.maleParent.transform.position + new Vector3(5, 0, -2); 
        
        _girl = Instantiate(girlPrefab, walk.transform);
        _girl.transform.position = girlPos;
        _girl.transform.DOMove(new Vector3(-5, 0, 0), 25f);
 
        walk.maleAnimator.transform.localRotation = quaternion.Euler(0, 160, 0);
        // walk.maleAnimator.SetTrigger(walk.male_left_walk_hash);
    }

    public override void OnResult(bool success)
    {
        if (GameManager.Instance.CurrentScene is not Scene_WalkEpisode walk)
        {
            return;
        }
        
        base.OnResult(success);
        
        walk.maleAnimator.transform.localRotation = quaternion.Euler(0, 90, 0);
    }
}