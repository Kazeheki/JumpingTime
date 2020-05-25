using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(true);
        GameEvents.PauseGame();
    }

    public void OnClickStart()
    {
        GameEvents.ResumeGame();

        gameObject.SetActive(false);
    }
}