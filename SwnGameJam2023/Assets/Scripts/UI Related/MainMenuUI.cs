using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public sceneManager sceneManager;
    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startButton = root.Q<Button>("startButton"); 
        Button quitButton = root.Q<Button>("quitButton"); 
        Button creditsButton = root.Q<Button>("creditsButton"); 

        startButton.clicked += () => sceneManager.gotoNextScene();
        quitButton.clicked += () => sceneManager.quitGame();
        creditsButton.clicked += () => sceneManager.gotoScene(2);
    }
}
