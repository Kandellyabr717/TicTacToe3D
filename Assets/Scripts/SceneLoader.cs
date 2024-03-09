using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private Animator _sceneTransition;

    public void Reload() => StartCoroutine(LoadScene(_controller.SceneIndex));
    
    public void LoadMenu() => StartCoroutine(LoadScene(0));

    public void LoadGame(int index) => StartCoroutine(LoadScene(index));

    private IEnumerator LoadScene(int index)
    {
        _sceneTransition.SetTrigger("Activate");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);
    }
}