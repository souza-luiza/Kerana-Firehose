using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuEvents : MonoBehaviour
{
    public VisualTreeAsset firstMenuAsset;
    public VisualTreeAsset mainMenuAsset;
    public VisualTreeAsset optionsMenuAsset;
    public VisualTreeAsset creditsMenuAsset;

    private UIDocument _document;
    private VisualElement _firstMenuScreen;
    private VisualElement _mainMenuScreen;
    private VisualElement _optionsMenuScreen;
    private VisualElement _creditsMenuScreen;
    private Button _pressAnyButton;
    private Button _sairDoJogo;
    private Button _comecarJogo;
    private Button _configuracoes;
    private Button _voltarPMainMenu;
    private Button _creditos;
    private Button _voltarPOptionsMenu;
    private bool keyPressed = false;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        if (firstMenuAsset == null || mainMenuAsset == null || optionsMenuAsset == null || creditsMenuAsset == null)
        {
            Debug.LogError("VisualTreeAssets não atribuídos.");
            return;
        }

        _firstMenuScreen = firstMenuAsset.CloneTree();
        _mainMenuScreen = mainMenuAsset.CloneTree();
        _optionsMenuScreen = optionsMenuAsset.CloneTree();
        _creditsMenuScreen = creditsMenuAsset.CloneTree();

        if (_firstMenuScreen == null)
        {
            Debug.LogError("Elemento 'FirstMenuScreen' não encontrado.");
        }

        if (_mainMenuScreen == null)
        {
            Debug.LogError("Elemento 'MainMenuScreen' não encontrado.");
        }

        if (_optionsMenuScreen == null)
        {
            Debug.LogError("Elemento 'OptionsMenuScreen' não encontrado.");
        }

        if (_creditsMenuScreen == null)
        {
            Debug.LogError("Elemento 'CreditsMenuScreen' não encontrado.");
        }

        _document.rootVisualElement.Add(_firstMenuScreen);
        _document.rootVisualElement.Add(_mainMenuScreen);
        _document.rootVisualElement.Add(_optionsMenuScreen);
        _document.rootVisualElement.Add(_creditsMenuScreen);

        _pressAnyButton = _firstMenuScreen.Q<Button>("PressAnyButton");
        if (_pressAnyButton == null)
        {
            Debug.LogError("Botão 'PressAnyButton' não encontrado.");
        }

        _pressAnyButton?.RegisterCallback<KeyDownEvent>(OnPressAnywhereButton);

        // Inicialmente, exibir apenas a primeira tela do menu
        _firstMenuScreen.style.display = DisplayStyle.Flex;
        _mainMenuScreen.style.display = DisplayStyle.None;
        _optionsMenuScreen.style.display = DisplayStyle.None;
        _creditsMenuScreen.style.display = DisplayStyle.None;

        // Encontrar os botões e registrar os callbacks
        _sairDoJogo = _mainMenuScreen.Q<Button>("SairDoJogo");
        if (_sairDoJogo == null)
        {
            Debug.LogError("Botão 'SairDoJogo' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'SairDoJogo' encontrado.");
            _sairDoJogo.clicked += OnQuitButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'SairDoJogo'.");
        }

        _comecarJogo = _mainMenuScreen.Q<Button>("ComecarJogo");
        if (_comecarJogo == null)
        {
            Debug.LogError("Botão 'ComecarJogo' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'ComecarJogo' encontrado.");
            _comecarJogo.clicked += OnStartGameButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'ComecarJogo'.");
        }

        _configuracoes = _mainMenuScreen.Q<Button>("Configuracoes");
        if (_configuracoes == null)
        {
            Debug.LogError("Botão 'Configuracoes' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'Configuracoes' encontrado.");
            _configuracoes.clicked += OnOptionsButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'Configuracoes'.");
        }

        _voltarPMainMenu = _optionsMenuScreen.Q<Button>("VoltarPMainMenu");
        if (_voltarPMainMenu == null)
        {
            Debug.LogError("Botão 'VoltarPMainMenu' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'VoltarPMainMenu' encontrado.");
            _voltarPMainMenu.clicked += OnBackToMainMenuButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'VoltarPMainMenu'.");
        }

        _creditos = _optionsMenuScreen.Q<Button>("Creditos");
        if (_creditos == null)
        {
            Debug.LogError("Botão 'Creditos' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'Creditos' encontrado.");
            _creditos.clicked += OnCreditsButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'Creditos'.");
        }

        _voltarPOptionsMenu = _creditsMenuScreen.Q<Button>("VoltarPOptionsMenu");
        if (_voltarPOptionsMenu == null)
        {
            Debug.LogError("Botão 'VoltarPOptionsMenu' não encontrado.");
        }
        else
        {
            Debug.Log("Botão 'VoltarPOptionsMenu' encontrado.");
            _voltarPOptionsMenu.clicked += OnBackToOptionsMenuButtonClicked;
            Debug.Log("Callback de clique registrado para o botão 'VoltarPOptionsMenu'.");
        }
    }

    private void OnQuitButtonClicked()
    {
        Debug.Log("Botão 'SairDoJogo' clicado.");
        QuitGame();
    }

    private void OnStartGameButtonClicked()
    {
        Debug.Log("Botão 'ComecarJogo' clicado.");
        StartGame();
    }

    private void OnOptionsButtonClicked()
    {
        Debug.Log("Botão 'Configuracoes' clicado.");
        OpenOptions();
    }

    private void OnBackToMainMenuButtonClicked()
    {
        Debug.Log("Botão 'VoltarPMainMenu' clicado.");
        BackToMainMenu();
    }

    private void OnCreditsButtonClicked()
    {
        Debug.Log("Botão 'Creditos' clicado.");
        OpenCredits();
    }

    private void OnBackToOptionsMenuButtonClicked()
    {
        Debug.Log("Botão 'VoltarPOptionsMenu' clicado.");
        BackToOptionsMenu();
    }

    private void OnPressAnywhereButton(KeyDownEvent evt)
    {
        if (!keyPressed)
        {
            keyPressed = true;
            if (_firstMenuScreen != null && _mainMenuScreen != null)
            {
                _firstMenuScreen.style.display = DisplayStyle.None;
                _mainMenuScreen.style.display = DisplayStyle.Flex;
                Debug.Log("Você pressionou o botão!");

                // Verificar se os botões estão visíveis e interativos
                if (_sairDoJogo != null)
                {
                    Debug.Log($"Botão 'SairDoJogo' visível: {_sairDoJogo.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'SairDoJogo' interativo: {_sairDoJogo.enabledSelf}");
                }
                if (_comecarJogo != null)
                {
                    Debug.Log($"Botão 'ComecarJogo' visível: {_comecarJogo.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'ComecarJogo' interativo: {_comecarJogo.enabledSelf}");
                }
                if (_configuracoes != null)
                {
                    Debug.Log($"Botão 'Configuracoes' visível: {_configuracoes.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'Configuracoes' interativo: {_configuracoes.enabledSelf}");
                }
            }
        }
    }

    void StartGame()
    {
        Debug.Log("Iniciando o jogo...");
        SceneManager.LoadScene("Fase1_Atualizada");
    }

    void OpenOptions()
    {
        Debug.Log("Abrindo o menu de opções...");
        _mainMenuScreen.style.display = DisplayStyle.None;
        _optionsMenuScreen.style.display = DisplayStyle.Flex;
        Debug.Log("Menu de opções exibido.");
    }

    void BackToMainMenu()
    {
        Debug.Log("Voltando para o menu principal...");
        _optionsMenuScreen.style.display = DisplayStyle.None;
        _mainMenuScreen.style.display = DisplayStyle.Flex;
        Debug.Log("Menu principal exibido.");
    }

    void OpenCredits()
    {
        Debug.Log("Abrindo o menu de créditos...");
        _optionsMenuScreen.style.display = DisplayStyle.None;
        _creditsMenuScreen.style.display = DisplayStyle.Flex;
        Debug.Log("Menu de créditos exibido.");
    }

    void BackToOptionsMenu()
    {
        Debug.Log("Voltando para o menu de opções...");
        _creditsMenuScreen.style.display = DisplayStyle.None;
        _optionsMenuScreen.style.display = DisplayStyle.Flex;
        Debug.Log("Menu de opções exibido.");
    }

    void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();

#if UNITY_EDITOR
        // Parar o jogo no editor do Unity
        EditorApplication.isPlaying = false;
#endif
    }

    private void Update()
    {
        if (Input.anyKeyDown && !keyPressed)
        {
            keyPressed = true;
            if (_firstMenuScreen != null && _mainMenuScreen != null)
            {
                _firstMenuScreen.style.display = DisplayStyle.None;
                _mainMenuScreen.style.display = DisplayStyle.Flex;
                Debug.Log("Tecla pressionada");

                // Verificar se os botões estão visíveis e interativos
                if (_sairDoJogo != null)
                {
                    Debug.Log($"Botão 'SairDoJogo' visível: {_sairDoJogo.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'SairDoJogo' interativo: {_sairDoJogo.enabledSelf}");
                }
                if (_comecarJogo != null)
                {
                    Debug.Log($"Botão 'ComecarJogo' visível: {_comecarJogo.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'ComecarJogo' interativo: {_comecarJogo.enabledSelf}");
                }
                if (_configuracoes != null)
                {
                    Debug.Log($"Botão 'Configuracoes' visível: {_configuracoes.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'Configuracoes' interativo: {_configuracoes.enabledSelf}");
                }
                if (_creditos != null)
                {
                    Debug.Log($"Botão 'Creditos' visível: {_creditos.resolvedStyle.display != DisplayStyle.None}");
                    Debug.Log($"Botão 'Creditos' interativo: {_creditos.enabledSelf}");
                }
            }
        }
    }
}
