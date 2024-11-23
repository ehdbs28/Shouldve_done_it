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
    
    public Canvas uiCanvas;
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

    public async void LoadSceneWithFade<T>(Scenes nextScene, Action<T> callback = null) where T : BaseScene
    {
        int sceneIndex = (int)nextScene;
        if(_scenes.Count <= sceneIndex || sceneIndex < 0)
            return;

        await ShowBlackAsync(true);
        
        if(_currentScene != null)
        {
            _currentScene.Release();
            Destroy(_currentScene.gameObject);
        }

        _currentScene = Instantiate(_scenes[sceneIndex]);

        await ShowBlackAsync(false);

        _currentScene.Initialize();
        callback?.Invoke(_currentScene as T);
    }

    public void LoadSceneWithFade(Scenes nextScene, Action<BaseScene> callback = null)
        => LoadSceneWithFade<BaseScene>(nextScene, callback);
    
    public async Task ShowBlackAsync(bool value)
    {
        if (_blackPanel == null)
        {
            _blackPanel = Instantiate(_blackPanelPrefab, uiCanvas.transform);
            _blackPanel.transform.SetAsLastSibling();
        }
        
        // todo fade 넣기
    }

    public void SetLetterBoxSize(float newSize, float timer = 0.3f)
    {
        _topLetterBox.DOSizeDelta(new Vector2(0, newSize), timer);
    }

}
