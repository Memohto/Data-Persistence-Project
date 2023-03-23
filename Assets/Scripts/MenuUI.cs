using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private InputField nameInput;

    private void Start()
    {
        GameManager.Instance.LoadData();
        bestScoreText.text = $"Best score: {GameManager.Instance.BestScore}";
        nameInput.text = GameManager.Instance.Name;
    }

    public void StartGame() {
        GameManager.Instance.Name = nameInput.text;
        GameManager.Instance.SaveData();
        SceneManager.LoadScene(1); 
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
