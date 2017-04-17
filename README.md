# PSGitCompletions
PowerShell competer for git

```PowerShell
Import-Module TabExpansionPlusPlus    # native completion of options works poorly without it
Import-Module ./PSGitCompletions.dll

Set-PSReadlineOption -ShowTooltip

cd <mygitrepo>
git com<tab> --am<tab>

git diff <ctrl+space>      # Expands with list of 50 most recent commits
git diff added<ctrl+space> # Expands with list of commits where message contains 'added'
```

## Provides command line completions for git

Extensive, multiline, tooltips are available in the ISE, but does not render well in the ConsoleHost.
