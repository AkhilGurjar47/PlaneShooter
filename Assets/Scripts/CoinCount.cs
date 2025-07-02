using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    public Text coinText;
    int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = count.ToString();
        coinText.text = "Coins : "+count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}
