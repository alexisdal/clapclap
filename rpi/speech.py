#!/usr/bin/env python


# to call third party program
import sys
import subprocess

# to use curl
# apt-get install python-pip
# pip install pycurl
import pycurl


class Speech:

#    def __init__(self):
#        self.filename = "temp.flac"

# TODO : check that both flac and arecord are actually installed
#    def check_dependancies
        
    def record(self, duration = 3, filename = "temp.flac"):
        command = "arecord -d"+str(duration)+" -f dat | flac - -f -o "+filename        
        process = subprocess.Popen(command, shell=True,
                    stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
        process.wait()
        
    def speech_to_text(self, google_api_key, language = "en-US", filename = "temp.flac"):
        # do nothing
        pass


# main
if __name__ == "__main__":
   # do something
   speech = Speech()
   print "Please ask something"
   speech.record()                                           
                                        
                                        
                                        
                                        
