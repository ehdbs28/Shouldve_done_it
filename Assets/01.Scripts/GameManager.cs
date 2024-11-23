using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private List<BaseScene> _scenes;
    private BaseScene _currentScene;
    
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Image _blackPanelPrefab;
    
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

}
