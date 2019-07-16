 mvn install:install-file -Dfile=echowand-1.1.jar -DgroupId=jaist.tanlab -DartifactId=echowand -Dpackaging=jar -Dversion=1.1

 java -jar NoObserve.jar -i lan0 &
 #java -jar Observe.jar -i lan0