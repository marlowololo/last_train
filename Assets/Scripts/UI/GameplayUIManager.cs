using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{

    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;
    [SerializeField] Text resourceText;
    [SerializeField] GameObject levelPanel;
    [SerializeField] Button playNextLevelButton;
    [SerializeField] Button repairTrainButton;

    private void Start()
    {
        playNextLevelButton.onClick.AddListener(StartNextLevel);
        repairTrainButton.onClick.AddListener(RepairTrainAction);
    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = "Resource : " + resourceInventoryAsset.resource;
    }

    public void ShowLevelPanel()
    {
        levelPanel.gameObject.SetActive(true);
    }

    private void StartNextLevel()
    {
        levelPanel.gameObject.SetActive(false);
        GameManager.Instance.StartNextLevel();
    }

    private void RepairTrainAction()
    {
        GameManager.Instance.train.RepairTrain();
    }
}
