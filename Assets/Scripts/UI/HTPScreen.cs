using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HTPScreen : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(4).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null && Input.GetAxisRaw("Vertical") != 0){
            EventSystem.current.SetSelectedGameObject(transform.GetChild(4).gameObject);
        }
        
    }

    public void ReturnToPause(){
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void OnEnable(){
        EventSystem.current.SetSelectedGameObject(transform.GetChild(4).gameObject);
    }
}
