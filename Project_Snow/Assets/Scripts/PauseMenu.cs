using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseUI;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        ToggleUI();
    }
}
