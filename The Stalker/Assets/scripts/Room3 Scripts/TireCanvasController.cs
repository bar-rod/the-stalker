using UnityEngine;

public class TireCanvasController : MonoBehaviour
{
    private CarTire carTire;
    private int state;

    private int totalBolts = 5;
    private int boltsPlaced = 0;
    private int[] boltTightenCounts;


    public void Initialize(CarTire tire, int currState)
    {
        carTire = tire;
        state = currState;

        boltTightenCounts = new int[totalBolts];
    }

    public void OnTireClicked()
    {
        if (state != 0) return;

        state = 1;
    }
    
    public void OnBoltHoleClicked(int index, bool playerHasBolts)
    {
        if (!playerHasBolts) return;

        boltsPlaced++;

        if (boltsPlaced >= totalBolts)
        {
            state = 2;
            carTire.AllBoltsPlaced();
        }
    }

    public void OnBoltClicked(int index, bool playerHasWrench)
    {
        if (!playerHasWrench) return;

        boltTightenCounts[index]++;

        if (boltTightenCounts[index] >= 3)
        {
            // this bolt is fully tightened
        }

        if (CheckAllBoltsTightened())
        {
            carTire.AllBoltsTightened();
        }
    }

    private bool CheckAllBoltsTightened()
    {
        foreach (int count in boltTightenCounts)
        {
            if (count < 3) return false;
        }
        return true;
    }
}
