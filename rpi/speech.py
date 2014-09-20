#!/usr/bin/env python


# to call third party program
import sys
import subprocess

# to use curl
# to install pycurl on raspbian as of sept 2014 
# do not use apt-get install python-pip as it installs python2.7 to python2.6 ?
# instead
# apt-get install python-setuptools # => to get easy_install
# easy_install pip
# pip install pycurl
# fails... => it tries to install the .exe windows version !?!
#import pycurl


# to sleep
import time
#time.sleep(t)


# for json parsing
import json

# to parse command line arguments
import argparse

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
        #pass
        # let's forget pycurl
        url="https://www.google.com/speech-api/v2/recognize?output=json&xjerr=0&lang="+language+"&maxresults=1&pfilter=0&key="+google_api_key
        command="curl -s -X POST -H \"Content-Type:audio/x-flac; rate=48000\" -T \""+filename+"\" --referer \"http://www.example.com/\"  " + "\"" + url + "\"" 
        #print command
        process = subprocess.Popen(command, shell=True,
            stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
                                    
        
        json_response = ""
        while True:
            line = process.stdout.readline()
            json_response += line 
            if line == '' and process.poll() != None:
                break
            
            time.sleep(0.25)
       
        
        return self.extract_data(json_response)
        
         
    def extract_data(self, response):
        response = response.replace('{"result":[]}', "").strip()
        if (response == ""): 
            return ""
        data = json.loads(response)
        return data["result"][0]["alternative"][0]["transcript"]
        
        


# main
if __name__ == "__main__":


    parser = argparse.ArgumentParser(description='testing text to speech from raspi, powered by Google Webservice ')    
    parser.add_argument('-l','--lang', help='spoken language such as "en-US" (default) or "fr-FR"', required=False)
    parser.add_argument('-k','--key', help='your google webservice key', required=True)
    parser.add_argument('-d','--duration', help='duration of the recording in seconds (defaults to 3)', required=False)
    
    args = vars(parser.parse_args())
    
    if (args['lang'] == None):
        args['lang'] = "en-US"
    if (args['duration'] == None):
        args['duration'] = "3"
                
    
    
    sp = Speech()
    print "Please say something"
    #sp.record(3)
#    resp = """
#{"result":[]}
#{"result":[{"alternative":[{"transcript":"c\'est parti c'est parti on y va","confidence":0.92745072}],"final":true}],"result_index":0}
#"""
    #sp.extract_data(resp)                                   
    sp.record(int(args['duration']))
    print "You just said :"
    text = sp.speech_to_text(args['key'], args['lang'])
    if (text == ""):
        print "Nothing!?!"
    else:
        print text
                                        
                                        
                                        
