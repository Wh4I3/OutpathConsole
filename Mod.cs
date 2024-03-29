﻿using UnityEngine;
using UnityEngine.SceneManagement;
using MelonLoader;
using OutpathConsole;

using System.IO;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Reflection;
using OverfortGames.FirstPersonController;
using OutpathConsole.Commands;

namespace OutpathConsole
{
    public class Mod : MelonMod
    {
        #region Initializing
        public static List<OutpathCommand> commandList = new List<OutpathCommand>();

        private MelonPreferences_Category controls;
        private MelonPreferences_Entry<KeyCode> openConsole;

        private readonly string configDirectory = Directory.GetCurrentDirectory() + "/UserData/OutpathConsole";
        public override void OnInitializeMelon()
        {
            commandList.Add(new Help());
            commandList.Add(new Give());
            commandList.Add(new GiveID());
            commandList.Add(new GiveAll());
            commandList.Add(new Remove());
            commandList.Add(new RemoveID());
            commandList.Add(new Clear());
            commandList.Add(new AddCredits());
            commandList.Add(new RemoveCredits());
            commandList.Add(new ClearCredits());
            commandList.Add(new Butcher());
            commandList.Add(new Tp());
            commandList.Add(new GetPosition());
            commandList.Add(new SetJumpCount());
            commandList.Add(new SetJumpForce());
            commandList.Add(new ResetJumpCount());
            commandList.Add(new ResetJumpForce());
            commandList.Add(new SpawnRandomNPC());
            commandList.Add(new SpawnRandomProp());

            if (!Directory.Exists(configDirectory))         Directory.CreateDirectory(configDirectory);

            controls = MelonPreferences.CreateCategory("Controls");
            controls.SetFilePath("UserData/OutpathConsole/Config.cfg");

            openConsole = controls.CreateEntry<KeyCode>("Open Console", KeyCode.T);

            controls.SaveToFile();
        }
        #endregion

        #region Deinitializing
        public override void OnDeinitializeMelon()
        {
            if (consoleVisible)         EnableConsole(); 
        }
        #endregion

        private static bool consoleVisible;
        private static readonly int consolePadding = 20;
        private static string commandPanelText = "Get started by using the \"/Help()\" command.\n";
        private static string commandLineTextField = "";
        private static string commandInput = "";
        private static Vector2 scrollPosition = Vector2.zero;
        public override void OnUpdate()
        {
            string activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == "Scene_Game")
            {
                if (Input.GetKeyDown(openConsole.Value)) EnableConsole();
                if (Input.GetKeyDown(KeyCode.Escape)) DisableConsole();

                if (commandLineTextField.Length > 0 && consoleVisible)
                {
                    for (int i = 0; i < commandLineTextField.Length; i++)
                    {
                        if (commandLineTextField[i] == '\n') ConfirmConsole();
                    }
                }

                if (PlayerGarden.instance != null)  if (PlayerGarden.instance.inMenu == -1) DisableConsole();

            }
        }
        public static void DrawConsolePanel()
        {
            GUI.skin.label.fontSize = 30;
            GUI.Box(new Rect(consolePadding, consolePadding, Screen.width - consolePadding * 2, Screen.height - consolePadding * 2), "Console");
            GUI.Box(new Rect(consolePadding * 2, consolePadding * 2, Screen.width - consolePadding * 4, Screen.height - consolePadding * 5 - 40), "");

            scrollPosition = GUI.BeginScrollView(new Rect(consolePadding * 2, consolePadding * 2, Screen.width - consolePadding * 4, Screen.height - consolePadding * 5 - 40), scrollPosition, new Rect(0, 0 , Screen.width - consolePadding * 6, Screen.height * 100));
            GUI.Label(new Rect(0, 0, Screen.width - consolePadding * 4, Screen.height * 100), commandPanelText);
            GUI.EndScrollView();
        }
        public static void DrawConsoleTextInput()
        {
            GUI.skin.textArea.fontSize = 30;
            GUI.SetNextControlName("Command Line");
            commandLineTextField = GUI.TextArea(new Rect(consolePadding * 2, Screen.height - consolePadding * 2 - 40, Screen.width - consolePadding * 4, 40), commandLineTextField, maxLength: -1);
        }
        private void EnableConsole()
        {
            consoleVisible = true;

            MelonEvents.OnGUI.Subscribe(DrawConsolePanel, 10);
            MelonEvents.OnGUI.Subscribe(DrawConsoleTextInput, 9);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FirstPersonController.instance.enableCameraRotation = false;
            PlayerGarden.instance.inMenu = 1;
            PlayerGardenInventory.instance.ResetItemInHand();
        }
        private void DisableConsole()
        {
            consoleVisible = false;
            
            MelonEvents.OnGUI.Unsubscribe(DrawConsolePanel);
            MelonEvents.OnGUI.Unsubscribe(DrawConsoleTextInput);
        }
        private static void ConfirmConsole()
        {
            commandInput = commandLineTextField;
            if (commandInput[0] != '/')
            {
                commandPanelText += commandLineTextField;
            }

            commandLineTextField = "";
            if (commandInput[0] == '/')
            {
                string[] parts = commandInput.Split(new char[] { '/', '(', ')' }, 4);
                foreach (OutpathCommand command in commandList)
                {
                    if (command.CommandName == parts[1])
                    {
                        commandPanelText += "\n" + command.Command(parts[2].TrimEnd(new char[] {'\n'}));
                    }
                }
            }
        }
    }
}
