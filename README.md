# UnityDebugModeDefineSymbol
A useful tool for running specific code <br>
[What it is?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if)


### Compatibility
|  Unity  | Compatible |
|:-------:|:----------:|
|  2020   |:white_check_mark:|
|  2019   |:white_check_mark:|

## How to use
1. Add source code of this repo to your project
2. Manage debug mode by following this path `Tools -> Debug Mode Definition ->` `On` / `Off`
<img width="372" alt="choiceDiaologWindow" src="https://user-images.githubusercontent.com/29813954/110636484-fa65bd00-81b4-11eb-88e9-c0b55ad82a21.png">

3. For code that should be executed only when the debug mode is turned on, put it in the definition like this:

```c#
// ... code somewhere
#if DEBUG_MODE_IN_USE
// code here will be executed if the debug mode is turned on
#endif
// ... code somewhere
```
