using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;
    bool isDead;            


    Animator anim;                          
    float restartTimer;                    


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            isDead = true;

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void ShowWarning()
    {
        anim.SetTrigger("Warning");
    }
}