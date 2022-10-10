using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField UserInputField;
    private string userName;
    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }

    public void SaveName()
    {

        userName = UserInputField.text.ToString();
        Manager.Instance.userName = userName;
    }

    public void Exit()
    {
        Manager.Instance.SaveBestScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    

}
