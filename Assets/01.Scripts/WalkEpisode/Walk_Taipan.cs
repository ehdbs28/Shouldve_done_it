using UnityEngine;
using DG.Tweening;

public class Walk_Taipan : MonoBehaviour
{
    [SerializeField] private float _speed = 1f; // 속도 (거리/초 단위)
    private Scene_WalkEpisode _walkEpisode;
    private Transform _target;
    public bool IsFinding { get; private set; }

    public void Setting(Scene_WalkEpisode sceneWalkEpisode)
    {
        _walkEpisode = sceneWalkEpisode;
        sceneWalkEpisode.OnDogEvent += On_DogEvent;
        _target = sceneWalkEpisode.Female.transform;
        IsFinding = false;
    }

    private void On_DogEvent()
    {
        IsFinding = true;
        DOMove();
    }

    private void Update()
    {
        if (IsFinding)
        {
            // 목표에 도달했는지 확인
            if (Vector3.Distance(transform.position, _target.position) <= 0.3f)
            {
                IsFinding = false;
                _walkEpisode.Failed();
            }
        }


    }

    private void DOMove()
    {
        // 목표 위치까지 이동
        float distance = Vector3.Distance(transform.position, _target.position);
        float duration = distance / _speed; // 이동 시간 계산
        transform.DOMove(_target.position, duration).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        if (_walkEpisode != null)
            _walkEpisode.OnDogEvent -= On_DogEvent;
    }
}