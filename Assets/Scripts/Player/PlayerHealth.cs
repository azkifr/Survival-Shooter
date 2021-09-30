using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider HealthSlider;
    public Image DamageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {   //refernce komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealth = startingHealth;
    }


    void Update()
    {   //Jika terkena damaage
        if (damaged)
        {   //Merubah warna gambar menjadi value dari flashColour
            DamageImage.color = flashColour;
        }
        else
        {   //Fade out damage image
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;
        //mengurangi health
        currentHealth -= amount;
        //Merubah tampilan dari health slider
        HealthSlider.value = currentHealth;
        //Memainkan suara ketika terkena damage
        playerAudio.Play();
        //Memanggil method Death() jika darahnya kurang dari sama dengan 10 dan belu mati
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }
    public void RestartLevel ()
    {
        //meload ulang scene dengan index 0 pada build setting
        SceneManager.LoadScene (0);
    }
}
