using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShelterScript : MonoBehaviour
{

    [SerializeField] private Camera camera;
    bool playZoom;

    private float zoomValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        playZoom = true;
        yield return new WaitForSeconds(7f);
        playZoom = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(playZoom)
        {
            camera.orthographicSize += zoomValue * Time.deltaTime;
        }
    }
}
