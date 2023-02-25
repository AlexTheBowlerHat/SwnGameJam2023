using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreditsUI : MonoBehaviour
{
    public sceneManager sceneManager;
    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button backToMainMenuButton = root.Q<Button>("backToMainMenuButton"); 
        Button quitButton = root.Q<Button>("quitButton"); 

        backToMainMenuButton.clicked += () => sceneManager.gotoScene(0);
        quitButton.clicked += () => sceneManager.quitGame();
    }
}
