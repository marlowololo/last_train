using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{

    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;
    [SerializeField] Text resourceText;
    [SerializeField] Text passengerCount;
    [SerializeField] GameObject levelPanel;
    [SerializeField] Button playNextLevelButton;
    [SerializeField] Button repairTrainButton;
    [SerializeField] Button addWagonButton;

    private void Start()
    {
        playNextLevelButton.onClick.AddListener(StartNextLevel);
        repairTrainButton.onClick.AddListener(RepairTrainAction);
        addWagonButton.onClick.AddListener(AddWagonAction);
    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = "Resource : " + resourceInventoryAsset.resource;
        passengerCount.text = "Total Passenger : " + GameManager.Instance.train.GetTotalPassenger();
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

    private void AddWagonAction()
    {
        GameManager.Instance.train.AddWagon();
    }
}
