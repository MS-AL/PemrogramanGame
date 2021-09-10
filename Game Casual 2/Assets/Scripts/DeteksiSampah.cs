using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeteksiSampah : MonoBehaviour
{
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah;
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        MediaPlayerBenar.clip = audioBenar;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        MediaPlayerSalah.clip = audioSalah;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag)){
        Data.score += 25;
        textScore.text = Data.score.ToString();
        Destroy(collision.gameObject);
        MediaPlayerBenar.Play();
        }
        else{
            Data.score -= 25;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerSalah.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
