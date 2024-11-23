using UnityEngine;

public class WalkTaipanEvent : WalkEpisodeEvent
{
    public Walk_Taipan taipanPrefab;
    private Walk_Taipan _taipan;
    
    public override void OnProcess()
    {
        base.OnProcess();

        if (GameManager.Instance.CurrentScene is not Scene_WalkEpisode walk)
        {
            return;
        }

        var taipanPos = walk.maleParent.transform.position + new Vector3(3, 0, 0); 
        
        _taipan = Instantiate(taipanPrefab);
        _taipan.Set(taipanPos);
        
        walk.femaleAnimator.SetTrigger(walk.female_terrified);
        
        CameraManager.Instance.Shake(0.3f);
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
            walk.maleAnimator.SetTrigger(walk.male_battlecry);
        }
        else
        {
            walk.maleAnimator.SetTrigger(walk.male_terrified);
        }

        if (_taipan)
        {
            Destroy(_taipan.gameObject);
        }
    }
}