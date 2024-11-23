using DG.Tweening;
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

        var taipanPos = walk.maleParent.transform.position + new Vector3(2, 0, 0); 
        
        _taipan = Instantiate(taipanPrefab, walk.transform);
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
            if (_taipan)
            {
                var initScale = _taipan.transform.localScale;
                _taipan.transform.DOScale(initScale * 1.1f, 2f)
                    .OnComplete(() =>
                    {
                        _taipan.transform.DOScale(Vector3.zero, 0.5f)
                            .OnComplete(() =>
                            {
                                Destroy(_taipan.gameObject);
                            });
                    });
            }
            
            walk.maleAnimator.SetTrigger(walk.male_battlecry);
        }
        else
        {
            walk.maleAnimator.SetTrigger(walk.male_terrified);
        }

    }
}