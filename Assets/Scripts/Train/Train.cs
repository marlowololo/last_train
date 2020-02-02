using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Wagon WagonPrefab;
    [SerializeField] private float WagonCount;
    [SerializeField] private float WagonOffset;
    [SerializeField] private ResourceInventoryScriptable ResourceInventory;
    private List<Wagon> ListWagon;

    private const float REPAIR_COST = 10;
    private const float ADD_WAGON_COST = 50;

    public void InitWagon()
    {
        ListWagon = new List<Wagon>();
        for(int i = 0; i < WagonCount; i++)
        {
            ListWagon.Add(Instantiate<Wagon>(WagonPrefab, this.transform));
        }
        UpdateWagonView();
    }

    public void UpdateWagonView()
    {
        int i = 0;
        foreach(Wagon item in ListWagon)
        {
            item.transform.position = new Vector3(WagonOffset * (-i), 0, 0);
            i++;
        }
    }

    public void DamageWagon(int wagonIndex, float damageAmmount)
    {
        ListWagon[wagonIndex].DamageWagon(damageAmmount);
    }

    public void RepairWagon(int wagonIndex, float repairAmmount)
    {
        ListWagon[wagonIndex].RepairWagon(repairAmmount);
    }

    public List<WagonPart> GetAllWagonPart()
    {
        List<WagonPart> wagonParts = new List<WagonPart>();
        foreach(var item in ListWagon)
        {
            wagonParts.AddRange(item.GetWagonParts());
        }
        return wagonParts;
    }

    public List<Wagon> GetAllWagon()
    {
        return ListWagon;
    }

    public void RepairTrain()
    {
        if(ResourceInventory.resource >= REPAIR_COST)
        {
            ResourceInventory.resource -= REPAIR_COST;
            foreach(var wagon in ListWagon)
            {
                wagon.RepairAllPart();
            }
        }
    }

    public void AddWagon()
    {
        if(ResourceInventory.resource >= ADD_WAGON_COST)
        {
            ResourceInventory.resource -= ADD_WAGON_COST;
            ListWagon.Add(Instantiate<Wagon>(WagonPrefab, this.transform));
            UpdateWagonView();
        }
    }
}
