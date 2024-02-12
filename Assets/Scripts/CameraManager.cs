using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField]
    private Camera Camera;

    [SerializeField]
    private Transform CameraPivot;

    [SerializeField]
    private const float SizeMin = 1;
    [SerializeField]
    private const float SizeMax = 90;
    [SerializeField]
    private const float SizeDefault = 25;
    [SerializeField]
    private float SizeChangeMult = 10f;

    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 wantLook;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, wantLook, ref velocity, smoothTime);
    }

    public void MoveCameraTo(Vector3 target)
    {
        wantLook = new Vector3(target.x, 0, target.z);
    }

    internal void ResizeCamera(float value = 0f)
    {
        if (value != 0f)
        {
            Camera.orthographicSize = Mathf.Max(MathF.Min(Camera.orthographicSize - value * SizeChangeMult, SizeMax), SizeMin);
        }
    }
}
