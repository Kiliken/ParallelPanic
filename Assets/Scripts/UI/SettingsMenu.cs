using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class SettingsMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject pauseMenu;
    public TextMeshProUGUI musicBtnText;
    public TextMeshProUGUI sfxBtnText;
    public TextMeshProUGUI ppBtnText;
    public AudioSource bgm;
    public GameObject postProcessing;
    [SerializeField] private JsonSettings jSettings;

    public static bool sfx_on = true;
    public static bool music_on = true;
    public static bool pp_on = true;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(4).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(5).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(6).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(7).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();

        /* Here's the json loader
        if (jSettings.Load())
        {
            sfx_on = jSettings.settings.sfx;
            music_on = jSettings.settings.music;
            pp_on = jSettings.settings.pp;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null && Input.GetAxisRaw("Vertical") != 0){
            EventSystem.current.SetSelectedGameObject(transform.GetChild(4).gameObject);
        }
    }

    public void SfxOnOff(){
        sfx_on = !sfx_on;
        if(sfx_on)
            sfxBtnText.text = "ON";
        else
            sfxBtnText.text = "OFF";
    }

    public void MusicOnOff(){
        music_on = !music_on;
        if(music_on){
            bgm.volume = 0.4f;
            musicBtnText.text = "ON";
        }
        else{
            bgm.volume = 0f;
            musicBtnText.text = "OFF";
        }
    }

    public void PpOnOff(){
        pp_on = !pp_on;
        postProcessing.SetActive(pp_on);
        if(pp_on)
            ppBtnText.text = "ON";
        else
            ppBtnText.text = "OFF";
    }

    public void ReturnToPause(){
        jSettings.Save(sfx_on, music_on, pp_on);
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void OnEnable(){
        EventSystem.current.SetSelectedGameObject(transform.GetChild(4).gameObject);
    }
}
