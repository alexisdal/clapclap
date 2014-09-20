#!/usr/bin/env python

# to call third party program
import sys  
import subprocess

# regular expressions
import re 

# for quick&ugly debug
#import pprint


import time
now = lambda: int(time.time()*1000)  # millisec
 
# inspired from http://stackoverflow.com/questions/4417546/constantly-print-subprocess-output-while-process-is-running
class ClapClap:

    class Status:
        silence    = 0
        in_between = 1
        clap       = 2

    def __init__(self, silence_threshold = 0.15, clap_threshold = 0.90,
        required_consecutive_claps = 1,
        max_clap_raise_duration_in_sec = 0.100,
        max_delay_between_consecutive_claps_in_sec = 1.0,
        debug = 0):
        self.silence_threshold = silence_threshold
        self.clap_threshold    = clap_threshold
        self.required_consecutive_claps = required_consecutive_claps
        self.max_delay_between_consecutive_claps_in_sec = max_delay_between_consecutive_claps_in_sec
        self.max_clap_raise_duration_in_sec = max_clap_raise_duration_in_sec
        self.debug = debug
        self.last_silence = now()
        self.last_clap    = now()
        self.previous_status = ClapClap.Status.silence
        self.consecutive_claps = 0
        

    def detect_claps(self):
        self.last_silence = -1.0
        self.last_clap    = -1.0
        self.previous_status = ClapClap.Status.silence
        self.consecutive_claps = 0
        self.start = now()
                        
        command="arecord -vvv -f dat /dev/null 2>&1"
    
    
        # record at 48000Hz 
        # typical output

        #Max peak (2048 samples): 0x000006c2 ##                   5%
        #Max peak (2048 samples): 0x000011e8 ###                  13%
        #Max peak (2048 samples): 0x00007f7e #################### 99%
        #Max peak (2048 samples): 0x0000305e ########             37%

        # so each line represents 2048/48000 = 0.0426666666666667 sec

        process = subprocess.Popen(command, shell=True, 
            stdout=subprocess.PIPE, stderr=subprocess.STDOUT)

        finished = False
        # Poll process for new output until finished
        while True:
            line = process.stdout.readline()
            if line == '' and process.poll() != None:
                break
            #sys.stdout.write(line)
            #sys.stdout.flush()
            result = re.search(r'([0-9]+)(%)', line, re.M) 
            #pprint.pprint(result)
            if (result):
                val = result.group(1)
                finished = self.append_value(int(val)/100.0, now())
                if (finished): 
                    break
                
                #sys.stdout.write(str(result.group(1)) + "\n")
                #sys.stdout.flush()
            
    

        #output = process.communicate()[0]
        process.kill
        #exit_code = process.returncode
        return finished


    def append_value(self, val, t):
        # val should be between 0 (silence) and 99 (max sound)
        val = 0.99 if val > 0.99 else val
        val = 0.00 if val < 0.00 else val
        #each interval is supposedly 0.0426666666666667 sec
        #dt = 0.0426666666666667
        current_status = self.get_status(val)
        if (self.debug >= 2): sys.stdout.write("level(%): "+str(val)+"\n")
        
        if (val >= self.clap_threshold and
            t - self.last_silence <= self.max_clap_raise_duration_in_sec*1000 and
            self.last_silence > self.last_clap):
            # it's a clap !
            if (t - self.last_clap <= self.max_delay_between_consecutive_claps_in_sec*1000):
                # it's a consecutive clap
                self.consecutive_claps += 1
            else:
                self.consecutive_claps = 1
            
            if (self.debug >= 1): 
                print ("  "+str((t-self.start)/1000.0)+"sec : "+str(self.consecutive_claps)+" claps")
        
        if (current_status == ClapClap.Status.silence):
            self.last_silence = t
        
        if (current_status == ClapClap.Status.clap):
            self.last_clap = t
            
        self.previous_status = self.get_status(val)
        
        return self.consecutive_claps >= self.required_consecutive_claps
    
    def get_status(self, val):
        if (val >= self.clap_threshold): 
            return ClapClap.Status.clap
        elif (val <= self.silence_threshold): 
            return ClapClap.Status.silence
        else: 
            return ClapClap.Status.in_between
         
    
# main
if __name__ == "__main__":
    cc = ClapClap()
    cc.debug = 2
    cc.required_consecutive_claps = 2
    finished = cc.detect_claps()
    if (finished):
        sys.exit(0)
    else:
        sys.exit(1)


