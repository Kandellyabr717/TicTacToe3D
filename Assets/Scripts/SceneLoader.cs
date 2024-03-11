using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private Animator _sceneTransition;

    public void Reload() => StartCoroutine(LoadScene(_controller.SceneIndex));
    
    public void LoadMenu() => StartCoroutine(LoadScene(0));

    public void LoadGame() => StartCoroutine(LoadScene(1));

    public void Quit() => StartCoroutine(QuitApp());

    private IEnumerator LoadScene(int index)
    {
        _sceneTransition.SetTrigger("Activate");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);
    }

    private IEnumerator QuitApp()
    {
        _sceneTransition.SetTrigger("Activate");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}