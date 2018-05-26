Get-ChildItem -Directory -Path $PSScriptRoot\runtimes\ -Recurse -Filter 'native' | 
    ForEach-Object {
        # For windows
        $env:PATH = '{0}{1}{2}' -f @(
            $_.FullName
            [System.IO.Path]::PathSeparator
            $env:PATH 
        )
        # For Linux
        $env:LD_LIBRARY_PATH = '{0}{1}{2}' -f @(
            $_.FullName
            [System.IO.Path]::PathSeparator
            $env:LD_LIBRARY_PATH
        )
        # For macOS
        $env:DYLD_LIBRARY_PATH = '{0}{1}{2}' -f @(
            $_.FullName
            [System.IO.Path]::PathSeparator
            $env:DYLD_LIBRARY_PATH
        )
    }
