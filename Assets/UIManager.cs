using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif


public class UIManager : MonoBehaviour
{
    public void setPlayerName(string name)
    {
        PlayerInfoScript.instance.currentPlayerName = name.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {   
        PlayerInfoScript.instance.SaveData();

        #if(UNITY_EDITOR)
            EditorApplication.ExitPlaymode();
        #else
            Appliction.Quit();
        #endif

    }
}
