#download the binary from github and zip it as expected by c#
wget https://github.com/jsreport/jsreport/releases/download/2.9.0/jsreport-linux.tar.gz 
tar -xzf jsreport-linux.tar.gz 
mv jsreport jsreport.exe 
zip jsreport-new.zip ./jsreport.exe
mv jsreport-new.zip jsreport.zip
rm jsreport-linux.tar.gz
rm license.txt
rm jsreport.exe

# the test in travis unfortunatelly still fails on version `GLIBCXX_3.4.20' not found 
