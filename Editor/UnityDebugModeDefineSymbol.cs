using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityDebugModeDefineSymbol.Editor
{
    internal static class DebugModeDefineSymbol
    {
        private static bool _debugIsOn;
        private const string debugModeSymbol = "DEBUG_MODE_IN_USE";

    
        [MenuItem("Tools/Debug Mode Definition/On")]
        internal static void TurnOnDebugModeDefinition()
        {
            _debugIsOn = GetState(); 
            if (_debugIsOn)
            {
                EditorUtility.DisplayDialog("Debug mode definition is turned On",
                    "DEBUG_MODE_IN_USE is already included in the scripting define symbols", "OK");
            }
            else
            {
                if (EditorUtility.DisplayDialog("Turn on the debug mode definition?",
                    "If the debug mode enabled, all the code in the definition 'DEBUG_MODE_IN_USE' will be executed", "Yes", "No"))
                {
                    _debugIsOn = true;
                    PlayerPrefs.SetInt("debugModeInUseKey", 1);
                    DefineSymbols();
                }
            }
        }
        [MenuItem("Tools/Debug Mode Definition/Off")]
        internal static void TurnOffDebugModeDefinition()
        {
            _debugIsOn = GetState();
            if (!_debugIsOn)
            {
                EditorUtility.DisplayDialog("Debug mode definition is already turned off",
                    "The code in the 'DEBUG_MODE_IN_USE' definition is not executed", "OK");
            }
            else
            {
                if (EditorUtility.DisplayDialog("Turn off the debug mode definition?",
                    "The code in the 'DEBUG_MODE_IN_USE' definition will not be execute", "Yes", "No"))
                {
                    _debugIsOn = false;
                    PlayerPrefs.SetInt("debugModeInUseKey", 0);
                    DefineSymbols();
                }
            }
        }

        private static bool GetState() => PlayerPrefs.GetInt("debugModeInUseKey", 0) == 1;
        
        private static void DefineSymbols()
        {
            BuildTargetGroup currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
        
            List<string> scriptingSymbols = 
                new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Split(';'));
        
            if (_debugIsOn)
            {
                if (!scriptingSymbols.Contains(debugModeSymbol)) scriptingSymbols.Add(debugModeSymbol);
                else return;
            }
            else
            {
                if (scriptingSymbols.Contains(debugModeSymbol)) scriptingSymbols.Remove(debugModeSymbol);
                else return;
            }

            string finalScriptingSymbols = string.Join(";", scriptingSymbols.ToArray()); 
            PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, finalScriptingSymbols);
        }
    }
}