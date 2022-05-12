
@{

    RootModule        = 'PSGitCompletions.dll'

    ModuleVersion     = '2.36.0'

    GUID              = '456512b8-bb86-47d7-835b-486b21bf5381'

    Author            = 'PowerCode'

    Copyright         = '(c) PowerCode. All rights reserved.'

    Description       = 'Tab completions for git.exe'
    FunctionsToExport = ''
    CmdletsToExport   = ''
    VariablesToExport = ''
    AliasesToExport   = ''

    FileList = @("PSGitCompletions.psd1", "PSGitCompletions.dll")

    PrivateData = @{
        PSData = @{
            Tags = @('git')
            ProjectUri = 'http://github.com/PowerCode/PSGitCompletions'
        }
    }
}

