using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    int valueCoin = 0;

    [SerializeField] Text PointValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            valueCoin++;
            PointValue.text = "Coins: " + valueCoin;

            Debug.Log("Coin collected: " + valueCoin);

            if (valueCoin >= 7)
            {
                Debug.Log("You Win!");

            }
        }
    }
}