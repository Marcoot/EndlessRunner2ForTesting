using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int currentCoins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            currentCoins = currentCoins += 1;
            //Debug.Log(currentCoins);
            Destroy(other.gameObject);
        }
    }
}
