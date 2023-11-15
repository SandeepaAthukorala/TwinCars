using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public GameObject winPanel, failPanel;
    public Text timeText, winPanelTimeText;

    bool enemyReached,playerReached;
    string time;
    float minitues, seconds;

    private void FixedUpdate()
    {
        TimeCal();
    }//FixedUpdate

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject.GetComponent<Player>());
            playerReached = true;
            OnReached();
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject.GetComponent<Enemy>());
            enemyReached = true;
            OnReached();
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }//OnCollisionEnter

    void OnReached()
    {
        if (enemyReached && !playerReached)
        {
            failPanel.SetActive(true);
        }
        else 
        {
            winPanel.SetActive(true);
            winPanelTimeText.text = time;
        }

        Destroy(timeText.gameObject.transform.parent.gameObject);
        Destroy(gameObject.GetComponent<LevelManager>());
    }//OnReached (when reach win point)

    void TimeCal()
    {
        seconds += Time.deltaTime;

        if(seconds >= 60f)
        {
            seconds -= 60f;
            minitues += 1f;
        }

        if (seconds <= 9f && minitues <= 9f) time = "0" + minitues + " : 0" + ((int)seconds);
        else if (seconds <= 9f) time = minitues + " : 0" + ((int)seconds);
        else if (minitues <= 9f) time = "0" + minitues + " : " + ((int)seconds);
        else time = minitues + " : " + ((int)seconds);

        timeText.text = time;
    }//TimeCal

}//class
