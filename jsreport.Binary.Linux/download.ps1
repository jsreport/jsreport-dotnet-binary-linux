[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
(new-object System.Net.WebClient).DownloadFile('https://github.com/jsreport/jsreport/releases/download/2.2.0/jsreport-linux.tar.gz','jsreport-linux.tar.gz')
& cmd.exe '/C 7z x "jsreport-linux.tar.gz" -so | 7z x -aoa -si -ttar'
ren jsreport jsreport.exe
Compress-Archive -LiteralPath jsreport.exe  -CompressionLevel Optimal -DestinationPath jsreport.zip -Force
del jsreport.exe
del jsreport-linux.tar.gz
del license.txt
