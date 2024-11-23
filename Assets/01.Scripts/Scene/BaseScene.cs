using UnityEngine;
using UnityEngine.UI;

public class BaseScene : MonoBehaviour
{
    [SerializeField, TextArea] private string _title;

    [SerializeField] private TitlePanel _titlePanelPrefab;
    private TitlePanel _titlePanel;

    public virtual void OnLoad()
    {
        if (_titlePanel == null)
        {
            _titlePanel = Instantiate(_titlePanelPrefab, GameManager.Instance.uiCanvas.transform);
        }
        _titlePanelPrefab.Show(_title);
    }
}