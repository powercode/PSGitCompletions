Import-Module PowerHtml -ErrorAction Stop

function Import-GitHelp {
    param(
        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [Alias("PSPath")]
        [string[]] $LiteraLPath,
        [int] $DescriptionLimit = 1000)

    begin{
    function decode($s) { [System.Web.HttpUtility]::HtmlDecode($s) }

    
    function selectNodes($doc, $name, $optionalTail){
        $altName = "_" + $name.ToLowerInvariant()
        $nodes = $doc.SelectNodes("/html/body/div[@id='content']/div[@class='sect1']/h2[@id='$altName']/following-sibling::div$optionalTail")
        if ($null -eq $nodes) {
            $nodes = $doc.SelectNodes("/html/body/div[@id='content']/div[@class='sect1']/h2[@id='$name']/following-sibling::div$optionalTail")
        }
        return $nodes
    }

    function getoptions($doc){
        $paramNodes = selectNodes $doc OPTIONS -optionaltail "//dl"        
        $noDD = $true
        $current = @()
        foreach ($n in $paramNodes.ChildNodes) {
            switch ($n.Name) {
                'dt' {
                    
                    if (-not $noDdd) {
                        $option = decode $n.InnerText.Trim()
                        $current += [pscustomobject] @{                        
                            Option      = $option
                            Completion  = $option -replace "[=\s].*"
                            Description = ""
                            PSTypeName = "GitOption"
                        }
                    }
                }
                'dd' {
                    $noDD = $false 
                    foreach ($c in $current) {
                        $c.Description = decode $n.InnerText.Trim()
                        $c
                    }
                
                    $current = @() 
                }
            }
        }
    }
    }

    process {
        [string]$Path = (Resolve-Path -LiteralPath:$LiteraLPath).ProviderPath
        $doc = Get-Content -Raw $Path | Convertfrom-html
        $options = getoptions $doc
        $short = $doc.SelectNodes("/html/body/div[@id='header']/div[@class='sectionbody']/p").InnerText
        if (!$short){
            Write-Debug "Skipping $Path - does not look like a command"
            return
        }
        if ($short -match '^git-(?<name>[\w-]+)\s+-\s+(?<desc>.*)')
        {
            $name =  $matches.name
            $shortDesciption = $matches.desc
        }
        else {
            Write-Error -message "unexpected format" -Category InvalidData -ErrorId "UnexpectedShortDescFormat" -TargetObject ([pscustomobject]@{Path = $Path; Doc = $doc; Short = $short})
            return
        }
        
        $synopsis = (selectNodes $doc SYNOPSIS).InnerText
        $descriptionNodes = (selectNodes $doc DESCRIPTION /div).InnerText
        $description = $descriptionNodes | foreach-object {$len = 0} { $len += $_.Length; if ($len -lt $DescriptionLimit){$_} } | Join-String

        [PSCustomObject] @{
            Name = $name
            ShortDesc = $shortDesciption
            Description = (decode $description.Trim())
            Synopsis = (decode $synopsis.Trim())
            Options = $options | sort-object {!$_.Completion.StartsWith("<")}, Completion
            PSTypeName = "GitCommandHelp"
        }

    }
}

<#
.SYNOPSIS 
    Generates options for a specific command

.DESCRIPTION
    Generate a case for a switch expression to be added in GitCommand.GetOptions

.EXAMPLE
    Import-GitHelp 'C:/Program Files/Git/mingw64/share/doc/git-doc/git-switch.html' | Get-GitOption -CommandName switch | Set-Clipboard
#>
function Get-GitOption {
    param(
        [Parameter(ValueFromPipeline)]
        [PSTypeName("GitCommandHelp")]
        $InputObject
    )
    
    process {
        $commandName = $InputObject.Name
        "`t`"$commandName`" => new GitCommandOption[] {"
        foreach($option in $inputObject.Options){
            $c = $option.Completion
            $l = $option.Option
            $d = $option.Description -replace '"', '""' -replace '\r?\n', ' ' -replace '\(\d\)'
            "`t`t`t`t`tnew GitCommandOption(`"$c`", `"$l`", @`"$d`"),"
        }
        "`t`t`t`t}, "
    }    
}

<#
.SYNOPSIS
    Generates a new GitCommand to add to the command array in GitCommand.cs
#>
function Get-GitCommand {
    param(
        [Parameter(ValueFromPipeline)]
        [PSTypeName("GitCommandHelp")]        
        $InputObject
    )
    process {
        $commandName = $InputObject.Name                
        $short = $InputObject.ShortDesc
        $desc = $InputObject.Description -replace '"', '""'
        $syn = $InputObject.Synopsis -replace '"', '""'
        "`t`t`tnew GitCommand(`"$commandName`", `"$short`",`n@`"$syn`",`n`t`t@`"$desc`")"
    }
}

<#
.SYNOPSIS
    Generates a new GitCommand to add to the command array in GitCommand.cs
.EXAMPLE 
PS> New-GitCommandFile  'C:/Program Files/Git/mingw64/share/doc/git-doc' | Set-Content .\src\PSGitCompletions\GitCommand.cs

Updates the GitCommand.cs file with the available commands from help
#>
function New-GitCommandFile {
    param(
        [Parameter(Mandatory)]
        [string] $GitHelpDirectory
    )
    $gitHelp = Get-ChildItem -Path $GitHelpDirectory\git-*.htm* | Import-GitHelp
    $commands = $gitHelp | Get-GitCommand | Join-string -Separator ",`n"
    $options = $gitHelp | Get-GitOption | Join-string -Separator "`n"
    $template = Get-Content -Raw $PSScriptRoot\GitCommand_template.tt
    return $template -replace '{commands}', $commands -replace '{options}', $options    
}