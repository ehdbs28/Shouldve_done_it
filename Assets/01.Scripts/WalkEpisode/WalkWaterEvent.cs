using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class WalkWaterEvent : WalkEpisodeEvent
{
    public GameObject waterPrefab;
    private GameObject _water;
    
    public override void OnProcess()
    {
        base.OnProcess();
        
        if (GameManager.Instance.CurrentScene is not Scene_WalkEpisode walk)
        {
            return;
        }

        var waterPos = walk.femaleParent.position + new Vector3(1.5f, 0, 0); 
        
        _water = Instantiate(waterPrefab, walk.transform);
        _water.transform.position = waterPos;
    }

    public override void OnResult(bool success)
    {
        if (GameManager.Instance.CurrentScene is not Scene_WalkEpisode walk)
        {
            return;
        }
        
        base.OnResult(success);

        if (success)
        {
            var temp = walk.maleParent.position;
            walk.maleParent.DOJump(walk.femaleParent.position, 0.1f, 1, 1f);
            walk.femaleParent.DOJump(temp, 0.1f, 1, 1f);
        }
        else
        {
            walk.femaleAnimator.SetBool(walk.idleHash, false);
            walk.femaleParent.DOMove(walk.femaleParent.position + new Vector3(1.5f, 0, 0), 3f)
                .OnComplete(() =>
                {
                    walk.femaleAnimator.SetTrigger(walk.female_terrified);
                });
        }
    }
}