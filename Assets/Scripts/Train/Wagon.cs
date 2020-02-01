using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{

    [SerializeField] private List<WagonPart> wagonParts;

    public float WagonHealth;
    private int MaxCapacity;
    private int CurrentPassenger;

    void InitWagonData(float wagonHealth, int maxCapacity, int currentPassenger)
    {
        WagonHealth = wagonHealth;
        MaxCapacity = maxCapacity;
        CurrentPassenger = currentPassenger;
    }

    public void DamageWagon(float damageAmmount)
    {
        WagonHealth -= damageAmmount;
    }

    public void RepairWagon(float repairAmmount)
    {
        WagonHealth += repairAmmount;
    }

    public void UpdatePassangerCount(int count)
    {
        CurrentPassenger = count;
    }

    public List<WagonPart> GetWagonParts()
    {
        return wagonParts;
    }
}
