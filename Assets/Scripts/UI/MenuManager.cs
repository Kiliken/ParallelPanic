using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    private int currentIdx = 0;
    private int lastIdx = 0;
    float idx = 0;
    private int btnCount = 2;
    private float verticalInput = 0f;
    public AudioClip tickSFX;
    public AudioClip selectSFX;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        btnCount = transform.childCount;
        SetButtonActive(0);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        if(verticalInput != 0){
            idx = Mathf.Min(btnCount - 1, Mathf.Max(0f, idx + (-verticalInput) * Time.deltaTime * 10));
            Debug.Log(idx);
            currentIdx = (int)Mathf.Floor(idx);
            if(lastIdx != currentIdx){
                SetButtonActive(currentIdx);
                audioSource.clip = tickSFX;
                audioSource.Play();
            }
            lastIdx = currentIdx;
        }

        if(Input.GetButtonDown("Submit")){
            switch(currentIdx){
                case 0:
                    LoadGame();
                    break;
                case 1:
                    QuitGame();
                    break;
            }
        }
    }


    public void ShowMenu(){
        currentIdx = 0;
        GameObject button = transform.GetChild(0).gameObject;
        //button.GetComponent<MeshFilter>().mesh = button.GetComponent<MenuButton>().activeMesh;
    }


    public void SetButtonActive(int btnIdx){
        for(int i = 0; i < btnCount; i++){
            GameObject button = transform.GetChild(i).gameObject;
            if(i == btnIdx){
                button.transform.GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(1).gameObject.SetActive(false);
            }
            else{
                button.transform.GetChild(0).gameObject.SetActive(false);
                button.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void LoadGame(){
        audioSource.clip = selectSFX;
        audioSource.Play();
        SceneManager.LoadScene("FinalLevel");
    }

    public void QuitGame(){
        audioSource.clip = selectSFX;
        audioSource.Play();
        Application.Quit();
    }
}
