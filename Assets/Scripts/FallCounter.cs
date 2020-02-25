using Cinemachine;
using UnityEngine;

public class FallCounter : MonoBehaviour
{
    public ShootText brokenTextShoot;

    private int currentBreakCount;
    [SerializeField] private int maxBreakCount;

    public Rigidbody playerRigidbody;

    [SerializeField] private CinemachineImpulseSource cinemachineImpulseSource;
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            currentBreakCount++;
            cinemachineImpulseSource.GenerateImpulse();
        }

        if (currentBreakCount >= maxBreakCount)
        {
            brokenTextShoot.Shoot();
            playerRigidbody.isKinematic = false;
            enabled = false;
        }
    }
}