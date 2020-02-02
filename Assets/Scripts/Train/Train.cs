using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Wagon WagonPrefab;
    [SerializeField] private float WagonCount;
    [SerializeField] private float WagonOffsetX;
    [SerializeField] private float WagonOffsetY;

    private List<Wagon> ListWagon;

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
            item.transform.position = new Vector3(WagonOffsetX * (-i), WagonOffsetY, 0);
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
}
