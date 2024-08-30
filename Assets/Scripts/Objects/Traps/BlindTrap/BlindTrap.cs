using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindTrap : MonoBehaviour
{
    GameObject smokeScreen;
    BlindTrapTrigger mainTrap;
    float timer = 0f;

    private void Start()
    {
        mainTrap = GetComponentInParent<BlindTrapTrigger>();
        smokeScreen = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (smokeScreen.activeSelf != true && mainTrap.smokeOn)
            {
                timer = 0;
                smokeScreen.SetActive(true);
                mainTrap.smokeOn = false;
            }
        }
    }

    private void Update()
    {
        if (smokeScreen.activeSelf == true)
        {
            timer += 1 * Time.deltaTime;
            if (timer > 8)
            {
                smokeScreen.SetActive (false);
            }
        }
    }
}
