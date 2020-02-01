using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public Wagon WagonPrefab;
    public float WagonCount;
    public float WagonOffset;
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
}
