using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityDebugModeDefineSymbol.Editor
{
    internal static class DebugModeDefineSymbol
    {
        private const string debugModeSymbol = "DEBUG_MODE_IN_USE";

    
        [MenuItem("Tools/Debug Mode Definition/On")]
        internal static void TurnOnDebugModeDefinition()
        {
            if (DefineDebugModeActivity())
            {
                EditorUtility.DisplayDialog("Debug mode definition is turned On",
                    "DEBUG_MODE_IN_USE is already included in the scripting define symbols", "OK");
            }
            else
            {
                if (EditorUtility.DisplayDialog("Turn on the debug mode definition?",
                    "If the debug mode enabled, all the code in the definition 'DEBUG_MODE_IN_USE' will be executed", "Yes", "No"))
                {
                    PlayerPrefs.SetInt("debugModeInUseKey", 1);
                    DefineSymbols(true);
                }
            }
        }
        [MenuItem("Tools/Debug Mode Definition/Off")]
        internal static void TurnOffDebugModeDefinition()
        {
            if (!DefineDebugModeActivity())
            {
                EditorUtility.DisplayDialog("Debug mode definition is already turned off",
                    "The code in the 'DEBUG_MODE_IN_USE' definition is not executed", "OK");
            }
            else
            {
                if (EditorUtility.DisplayDialog("Turn off the debug mode definition?",
                    "The code in the 'DEBUG_MODE_IN_USE' definition will not be execute", "Yes", "No"))
                {
                    PlayerPrefs.SetInt("debugModeInUseKey", 0);
                    DefineSymbols(false);
                }
            }
        }

        private static bool DefineDebugModeActivity()
        {
            BuildTargetGroup currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
        
            List<string> scriptingSymbols = 
                new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Split(';'));

            return scriptingSymbols.Contains(debugModeSymbol);
        }
        
        private static void DefineSymbols(bool state)
        {
            BuildTargetGroup currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
        
            List<string> scriptingSymbols = 
                new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Split(';'));
        
            if (state)
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