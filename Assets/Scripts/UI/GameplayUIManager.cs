using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{

    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;
    [SerializeField] Text resourceText;


    // Update is called once per frame
    void Update()
    {
        resourceText.text = "Resource : " + resourceInventoryAsset.resource;
    }
}
