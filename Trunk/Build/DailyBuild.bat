rm -rf /home/psantos/.wapi/shared_fileshare-firebrick-Linux*
rm -rf *.txt
rm -rf *.html
rm -rf *.xml

cd .. 
nant -nologo clean 
svn update 
svn info > Build/SvnInfo.txt 

mono ../../midgard/Deploy/Odin.exe --verbose --project:Project/OrionsBelt.xml
nant -nologo -indent:1 -listener:NAnt.Core.DefaultLogger -logger:NAnt.Core.XmlLogger -logfile:Build/Build.log.xml tests > Build/NAntOutput.txt

cd Build
nant -nologo build-report
nant -nologo sendmail
chmod -R 0777 .
