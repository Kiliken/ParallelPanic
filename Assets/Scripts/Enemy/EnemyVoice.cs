using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVoice : MonoBehaviour
{
    [SerializeField] private List<AudioClip> enemyVoices = new List<AudioClip>();
    [SerializeField] private EnemyController enemyController;
    AudioSource audioSource;
    private int voiceCount = 0;
    public bool playingVoice = true;
    public float maxAudioDist = 50;
    public float voiceVolume = 0;
    public float volumeMax = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        voiceCount = enemyVoices.Count;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playingVoice){
            float dist = enemyController.playerDistance;
            if(dist > maxAudioDist/2){
                voiceVolume = (float)System.Math.Round((maxAudioDist - dist)/maxAudioDist * 0.4, 2);
            }
            else{
                voiceVolume = (float)System.Math.Round((maxAudioDist - dist)/maxAudioDist, 2);
            }
            audioSource.volume = Mathf.Min(volumeMax, Mathf.Max(0, voiceVolume));
            //Debug.Log("Enemy distance: " + dist + " Volume: " + audioSource.volume);
            if(!audioSource.isPlaying){
                PlayRandomVoice();
            }
        }
        
    }

    private void PlayRandomVoice(){
        int voiceNo = Random.Range(0, voiceCount);
        audioSource.clip = enemyVoices[voiceNo];
        audioSource.Play();
    }
}
