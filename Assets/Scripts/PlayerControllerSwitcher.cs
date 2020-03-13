using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    public void SwitchToTopDown()
    {
        movement.topDown = true;
    }
}
