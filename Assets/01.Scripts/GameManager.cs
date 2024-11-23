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

    private Scenes _currentSceneType;
    public Scenes CurrentSceneType => _currentSceneType;
    
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
        SoundManager.Instance.InitManager();  
        CameraManager.Instance.InitManager();
    }

    public void LoadSceneWithFade<T>(Scenes nextScene, Action<T> onLoadComplete = null, Action<T> onFinish = null) where T : BaseScene
    {
        int sceneIndex = (int)nextScene;
        if(_scenes.Count <= sceneIndex || sceneIndex < 0)
            return;

        StartCoroutine(LoadSceneWithFadeRoutine(sceneIndex, onLoadComplete, onFinish));
    }

    public void LoadSceneWithFade(Scenes nextScene, Action<BaseScene> onLoadComplete = null, Action<BaseScene> onFinish = null)
        => LoadSceneWithFade<BaseScene>(nextScene, onLoadComplete, onFinish);

    private IEnumerator LoadSceneWithFadeRoutine<T>(int sceneIndex, Action<T> onLoadComplete = null, Action<T> onFinish = null) where T : BaseScene
    {
        yield return StartCoroutine(ShowBlackAsync(true));
        
        if(_currentScene != null)
        {
            _currentScene.Release();
            Destroy(_currentScene.gameObject);
        }

        _currentScene = Instantiate(_scenes[sceneIndex]);
        _currentScene.OnPreLoadScene((Scenes)sceneIndex, _currentSceneType);
        onLoadComplete?.Invoke(_currentScene as T);
        _currentSceneType = (Scenes)sceneIndex;
        
        yield return StartCoroutine(ShowBlackAsync(false));

        _currentScene.Initialize();
        onFinish?.Invoke(_currentScene as T);
    }
    
    public IEnumerator ShowBlackAsync(bool value)
    {
        if (_blackPanel == null)
        {
            _blackPanel = Instantiate(_blackPanelPrefab, uiCanvas.transform);
            _blackPanel.transform.SetAsLastSibling();
        }

        _blackPanel.gameObject.SetActive(true);

        // todo fade 넣기
        const float FADE_DURATION = 0.5f;
        yield return _blackPanel.DOFade(value ? 1 : 0, FADE_DURATION).WaitForCompletion();
        _blackPanel.gameObject.SetActive(value);
    }

    public void SetLetterBoxSize(float newSize, float timer = 0.3f)
    {
        _topLetterBox.DOSizeDelta(new Vector2(0, newSize), timer);
    }

}
