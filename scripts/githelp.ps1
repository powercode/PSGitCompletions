Import-Module PowerHtml -ErrorAction Stop

function Import-GitHelp {
    param(
        [Parameter(Mandatory)]
        [string] $path)

    function decode($s) { [System.Web.HttpUtility]::HtmlDecode($s) }

    $doc = Get-Content -Raw $Path | Convertfrom-html
    $paramNodes = $doc.SelectNodes('//*[@id="content"]/div[3]/div/div/dl')
    $noDD = $true
    $current = @()
    foreach ($n in $paramNodes.ChildNodes) {
        switch ($n.Name) {
            'dt' {
                
                if (-not $noDdd) {
                    $option = decode $n.InnerText.Trim()
                    $current += [pscustomobject] @{                        
                        "Option"      = $option
                        "Completion"  = $option -replace "[=\s].*"
                        "Description" = ""
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

function Get-GitOption {
    param(
        [Parameter(Mandatory)]
        [string] $CommandName,
        [Parameter(ValueFromPipeline)]
        $InputObject
    )

    begin {
        "`t`"$CommandName`" => new[] {"
    }
    process {
        $c = $InputObject.Completion
        $l = $InputObject.Option
        $d = $InputObject.Description -replace '"', '""' -replace '\r?\n', ' ' -replace '\(\d\)'
        "`t`t`t`t`tnew GitCommandOption(`"$c`", `"$l`", @`"$d`"),"
    }
    end {
        "`t`t`t`t}, "
    }
}
