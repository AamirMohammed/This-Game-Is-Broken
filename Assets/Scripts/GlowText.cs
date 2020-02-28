using System.Collections;
using UnityEngine;

public class GlowText : MonoBehaviour
{
    public MeshRenderer[] characterMeshes;

    public float glowFadeTime = 1f;
    private Coroutine coroutine;

    private bool enabled;

    private void Start()
    {
        DisableGlow();
    }


    public void EnableGlow()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        enabled = true;
        foreach (MeshRenderer characterMesh in characterMeshes)
        {
            characterMesh.material.color = Color.white;
            characterMesh.material.SetColor("_EmissionColor", Color.white);
        }
    }

    public void DisableGlow()
    {
        enabled = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Glow(Color.white, Color.black, glowFadeTime));
    }

    private IEnumerator Glow(Color startColor, Color endColor, float time)
    {
        float timeSinceStarted = Time.time;
        float percentageComplete = 0f;

        while (percentageComplete <= 1.0f)
        {
            float timeRemaining = Time.time - timeSinceStarted;
            percentageComplete = timeRemaining / time;
            Color lerpedColor = Color.Lerp(startColor, endColor, percentageComplete);

            foreach (MeshRenderer characterMesh in characterMeshes)
            {
                characterMesh.material.color = lerpedColor;
                characterMesh.material.SetColor("_EmissionColor", lerpedColor);
                yield return null;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.contacts[0].normal == -Vector3.up)
        {
            Debug.Log("why am i true");
            EnableGlow();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (enabled)
            DisableGlow();
    }
}