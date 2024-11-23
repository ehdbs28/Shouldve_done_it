using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroTitleUI : MonoBehaviourUI
{

    public override void Hide()
    {
        GetComponent<Text>().DOFade(0f, 1f).OnComplete(base.Hide);
    }
}
