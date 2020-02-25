using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private float timeToLerp = 4f;

    [SerializeField] private CinemachineFreeLook cinemachineFreeCam;
    public CinemachineCameraOffset cinemachineCameraOffset;

    [SerializeField] private GameObject front;


    [SerializeField] private CameraSettings sideViewSettings;
    [SerializeField] private CameraSettings topViewSettings;
    [SerializeField] private CameraSettings thirdPersonSettings;
    [SerializeField] private CameraSettings firstPersonSettings;


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToSideView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToTopView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToFirstPersonView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeToThirdPersonView();
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            Time.timeScale = 5;
        }
        else if (Input.GetKeyUp(KeyCode.PageUp))
        {
            Time.timeScale = 1;
        }
#endif
    }


    public void ChangeToSideView()
    {
        Debug.Log("SIDE VIEW");
        StartCoroutine(ChangeCamera(sideViewSettings));
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;

        //StartCoroutine(SideView());
        //playerMovement.topDown = false; Needs to be removed once player movement is refactored
    }

    public void ChangeToTopView()
    {
        Debug.Log("TOP VIEW");
        StartCoroutine(ChangeCamera(topViewSettings));
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;
        //StartCoroutine(TopView());
        //playerMovement.topDown = true; Needs to be removed once player movement is refactored
    }

    public void ChangeToFirstPersonView()
    {
        Debug.Log("First Person VIEW");
        StartCoroutine(ChangeCamera(firstPersonSettings));
        cinemachineFreeCam.LookAt = front.transform;
        //StartCoroutine(FirstPersonView());
        //playerMovement.topDown = false; Needs to be removed once player movement is refactored
    }

    public void ChangeToThirdPersonView()
    {
        Debug.Log("Third Person VIEW");
        StartCoroutine(ChangeCamera(thirdPersonSettings));
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;
        //StartCoroutine(ThirdPersonView());
        //playerMovement.topDown = false; Needs to be removed once player movement is refactored
    }


    private IEnumerator TopView()
    {
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;


        float startZOffset = cinemachineCameraOffset.m_Offset.z;


        float endValueY = 1f;
        float endValueX = 0f;
        float endZOffSet = 5;


        float midRigEndRadius = 35f;
        float endMidHeight = 0;

        float topRigEndRadius = 18f;
        float topHeightEnd = 30f;

        float endFov = 60;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;

            cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(startZOffset, endZOffSet, percCompleted);

            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            yield return null;
        }
    }


    private IEnumerator SideView()
    {
        float endValueY = 0.5f;
        float endValueX = 0f;

        float midRigEndRadius = 600;
        float endMidHeight = 0;

        float topRigEndRadius = 1.3f;
        float topHeightEndRadius = 4.5f;

        float endFov = 5f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;


        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;


        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;

            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startTopHeight, topHeightEndRadius, percCompleted);

            yield return null;
        }
    }

    private IEnumerator ThirdPersonView()
    {
        float endValueY = 0.5f;
        float endValueX = 90f;

        float midRigEndRadius = 2f;

        float endMidHeight = 0.5f;

        float topRigEndRadius = 2;
        float topHeightEnd = 4.5f;

        float endFov = 40f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;


        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
            yield return null;
        }
    }


    private IEnumerator FirstPersonView()
    {
        float endValueY = 0.5f;
        float endValueX = 90f;

        float midRigEndRadius = 0f;
        float endMidHeight = 0f;

        float topRigEndRadius = 0;
        float topHeightEnd = 4.5f;

        float endFov = 40f;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
            yield return null;
        }

        cinemachineFreeCam.LookAt = front.transform;
    }


    public IEnumerator ChangeCamera(CameraSettings settings)
    {
        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;
        float startZOffset = cinemachineCameraOffset.m_Offset.z;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;

            cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(startZOffset, settings.zOffSet, percCompleted);

            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, settings.yAxisValue, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, settings.xAxisValue, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius =
                Mathf.Lerp(startTopRigRadius, settings.topRig.radius, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, settings.topRig.height, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height =
                Mathf.Lerp(startMidHeight, settings.middleRig.height, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius =
                Mathf.Lerp(startMidRigRadius, settings.middleRig.radius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, settings.fov, percCompleted);
            yield return null;
        }
    }

    [Serializable]
    public struct CameraSettings
    {
        public float yAxisValue;
        public float xAxisValue;
        public float zOffSet;


        public OrbitRig middleRig;
        public OrbitRig topRig;


        public float fov;
    }

    [Serializable]
    public struct OrbitRig
    {
        public float radius;
        public float height;
    }
}