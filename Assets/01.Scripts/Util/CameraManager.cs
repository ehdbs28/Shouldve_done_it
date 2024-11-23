using UnityEngine;
using DG.Tweening;
using System;
using Cinemachine;

public class CameraManager : MonoSingleton<CameraManager>
{
    private const int FOCUSED_PRIORITY = 30;
    private const int UNFOCUSED_PRIORITY = 1;

    private CinemachineVirtualCamera currentVCam = null;

    private Camera _camera;
    public Camera Camera => _camera;
    public override void InitManager()
    {
        _camera = Camera.main;
    }

    public void SettingCamera(Camera camera)
    {
        _camera = camera;
    }

    public void SetVirtualCamera(CinemachineVirtualCamera targetVCam)
    {
        if(currentVCam != null)
            currentVCam.Priority = UNFOCUSED_PRIORITY;
        
        currentVCam = targetVCam;

        if(currentVCam != null)
            currentVCam.Priority = FOCUSED_PRIORITY;
    }

    public void ZoomInCamera(Vector3 startPos, Vector3 endPos, float zoomTime,Ease ease,Action callback = null)
    {
        if (_camera == null) return;

        // 카메라 시작 위치 설정
        _camera.transform.position = startPos;

        // DOTween으로 카메라 위치 이동
        _camera.transform.DOMove(endPos, zoomTime).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void ZoomInCamera(float targetFOV, float zoomTime,Ease ease, Action callback = null)
    {
        if (_camera == null) return;

        // DOTween으로 FOV 변경
        _camera.DOFieldOfView(targetFOV, zoomTime).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void SetPosition(Vector3 endPosition, float timer, Action callback = null)
    {
        if (_camera == null) return;

        _camera.transform.DOMove(endPosition, timer)
            .OnComplete(() =>
            {
                callback?.Invoke();
            });
    }

    public void SetRotation(Quaternion endRotation, float timer, Action callback = null)
    {
        if (_camera == null) return;

        _camera.transform.DORotateQuaternion(endRotation, timer)
            .OnComplete(() =>
            {
                callback?.Invoke();
            });
    }

    public void Shake(float duration, float strength = 0.1f, int vibrato = 10, float randomness = 90f)
    {
        if (_camera == null) return;

        _camera.transform.DOShakePosition(duration, strength, vibrato, randomness, true);
    }
}
