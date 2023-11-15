using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R)) RestartScene();
    }//FixedUpdate

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }//RestartScene
}//class

/*reason for created separate class for only restart is 
 * other objects are automaticaly desstroy after game is end*/
