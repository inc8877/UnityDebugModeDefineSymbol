<p align="center">
  <img width="500" height="333" src="https://user-images.githubusercontent.com/29813954/116009658-a1969a80-a623-11eb-838d-e5bf004bd051.png">
</p>

# UnityDebugModeDefineSymbol

[![openupm](https://img.shields.io/npm/v/com.inc8877.unity-debug-mode-define-symbol?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.inc8877.unity-debug-mode-define-symbol/)

A useful tool for running specific code  
[What it is?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if)

## Table of Contents

- [UnityDebugModeDefineSymbol](#unitydebugmodedefinesymbol)
  - [Table of Contents](#table-of-contents)
  - [Compatibility](#compatibility)
  - [How to use](#how-to-use)
  - [Installation](#installation)
    - [Install via OpenUPM](#install-via-openupm)
    - [Install via Git URL](#install-via-git-url)
  - [Credits](#credits)

## Compatibility

| Unity |     Compatible     |
| :---: | :----------------: |
| 2021  | :white_check_mark: |
| 2020  | :white_check_mark: |
| 2019  | :white_check_mark: |

## How to use

1. Add this tool to your project [[how](#installation)]
2. Manage debug mode by following this path `Tools -> Debug Mode Definition ->` `On` / `Off`
<img width="372" alt="choiceDiaologWindow_DebugMode" src="https://user-images.githubusercontent.com/29813954/111028008-6c7c1300-83fc-11eb-83f5-49093ae5c7da.png">

3. For code that should be executed only when the debug mode is turned on, put it in the definition like this:

```c#
// ... code somewhere
#if DEBUG_MODE_IN_USE
// code here will be executed if the debug mode is turned on
#endif
// ... code somewhere
```

## Installation

### Install via OpenUPM

The package is available on the [openupm](https://openupm.com) registry. It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```c#
openupm add com.inc8877.unity-debug-mode-define-symbol
```

### Install via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add the following line to the dependencies block.

```c#
{
  "dependencies": {
    "com.inc8877.unity-debug-mode-define-symbol": "https://github.com/inc8877/UnityDebugModeDefineSymbol.git",
   }
}
```

## Credits

Cover background by [Florian Olivo](https://unsplash.com/@florianolv)
