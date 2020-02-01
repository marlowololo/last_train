using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] Button PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
