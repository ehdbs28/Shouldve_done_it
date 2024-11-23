using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private List<BaseScene> _scenes;
    private BaseScene _currentScene;
    
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Image _blackPanelPrefab;

    [SerializeField] private RectTransform _topLetterBox;
    [SerializeField] private RectTransform _bottomLetterBox;
    
    private Image _blackPanel;
    
    private void Awake()
    {
        InitManager();
    }
    
    public override void InitManager()
    {
        TextManager.Instance.InitManager();
    }

    public async Task LoadSceneWithFade(Scenes nextScene, Action callback = null)
    {
        await ShowBlackAsync(true);
        Destroy(_currentScene.gameObject);
        _currentScene = Instantiate(_scenes[(int)nextScene]);
        await ShowBlackAsync(false);
        callback?.Invoke();
    }
    
    public async Task ShowBlackAsync(bool value)
    {
        if (_blackPanel == null)
        {
            _blackPanel = Instantiate(_blackPanelPrefab, _uiCanvas.transform);
            _blackPanel.transform.SetAsLastSibling();
        }
        
        // todo fade 넣기
    }

    public void SetLetterBoxSize(float newSize, float timer = 0.3f)
    {
        _topLetterBox.DOSizeDelta(new Vector2(0, newSize), timer);
    }

}
