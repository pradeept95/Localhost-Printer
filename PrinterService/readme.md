
# Install service

 1. Open Windows Powershell in Administrative Mode
 2. run comman
        
        sc.exe create {ServiceName} binpath= C:\temp\HotBag\WebPrintingService\HotBag.AspNetCore.WebPrintService.exe start=auto

 3. To start service >> in cmd.exe in Administrative Mode
    
        /k net start {ServiceName}
        
 4. To stop service >> in cmd.exe in Administrative Mode

        /k net stop {ServiceName}

5. To delete service >> in cmd.exe in Administrative Mode
        
        sc delete {ServiceName}



        sc.exe create TESTWebPrinting binpath= C:\temp\HotBag\WebPrintingService\HotBag.AspNetCore.WebPrintService.exe start=auto