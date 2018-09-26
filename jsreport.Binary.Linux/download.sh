sudo apt-get install wget -y 
wget https://github.com/jsreport/jsreport/releases/download/2.2.0/jsreport-linux.tar.gz 
tar -xzf jsreport-linux.tar.gz 
mv jsreport jsreport.exe 
sudo apt-get install zip -y 
zip jsreport.zip ./jsreport.exe
rm jsreport-linux.tar.gz
rm license.txt
rm jsreport.exe