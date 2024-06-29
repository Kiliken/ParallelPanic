using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChampScript : MonoBehaviour
{
    public TextMeshProUGUI win;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1") 
        {
            win.text = "PLAYER1\nWIN";
        }
        else if (other.gameObject.name == "Player2")
        {
            win.text = "PLAYER2\nWIN";
        }
    }
}
