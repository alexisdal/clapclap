using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using NAudio.Wave; // to aquire sound 


using System.Diagnostics; // to measure time (StopWatch)

namespace clap_clap
{

    // to handle events
    // typically sound volume changed
    class VolumeChangedEvent : EventArgs { public double volume { get; set; } public long elapsedMilliSeconds { get; set; }  };
    
    class SoundRecorder
    {
        // to publish volume changed events 
        public delegate void VolumeHandler(SoundRecorder rec, VolumeChangedEvent e);
        public event VolumeHandler VolumeChanged;
        
        //private int deviceID = -1;
        private WaveInEvent waveIn;
        private volatile bool recording = false; // the flag to know when to start/stop ?

        private short[] recordedSamples; // RAW wav PCM data buffer
        private int lastSampleId = 0; // last audio point id in buffer
        private double bufferDurationInSeconds = 0;

        private double volume; 
        //private short upperBound;
        //private short lowerBound;
        private double volumeWindowDurationInSeconds;

        private Stopwatch watch;


        public int sampleRate = 8000; // 8 kHz
        public int channels = 1; // mono


        public SoundRecorder() { 
            //default values
            watch = new Stopwatch();
            SetBufferProperties(5.0, 1.0); 
        }

        public void SetBufferProperties(double bufferDurationInSeconds, double volumeWindowDurationInSeconds)
        {
            // between 01sec and 30sec
            bufferDurationInSeconds = bufferDurationInSeconds > 30 ? 30 : bufferDurationInSeconds;
            bufferDurationInSeconds = bufferDurationInSeconds < 1 ? 1 : bufferDurationInSeconds;

            // let's say at least 10 samples. at 8000Hz : 10/8000 => 0.00125sec
            volumeWindowDurationInSeconds = volumeWindowDurationInSeconds < 0.00125 ? 0.00125 : volumeWindowDurationInSeconds;
            // do not overflow
            volumeWindowDurationInSeconds = volumeWindowDurationInSeconds > bufferDurationInSeconds 
                ? bufferDurationInSeconds : volumeWindowDurationInSeconds;
 
            bool wasrecording = recording;
            StopRecording();
            this.bufferDurationInSeconds = bufferDurationInSeconds;
            recordedSamples = new short[(int)(sampleRate * bufferDurationInSeconds)]; // c# silently initializes to zero
            lastSampleId = 0; // start at zero pls

            this.volumeWindowDurationInSeconds = volumeWindowDurationInSeconds;
            if (wasrecording) StartRecording();
        }

        public void StartRecording() 
        { 
            recording = true;
            waveIn.StartRecording();
            watch.Start();
        }
        public void StopRecording() 
        {
            if (recording) waveIn.StopRecording();
            recording = false; 
            watch.Stop(); watch.Reset();
        }
        public bool IsRecording() { return recording; }



        public string[] GetRecordingDevices()
        {
            int waveInDevices = WaveIn.DeviceCount;
            string[] results = new string[waveInDevices];
            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                //string msg = string.Format("{1}] [{2} channels]",
                //    waveInDevice, deviceInfo.ProductName, deviceInfo.Channels);
                string msg = deviceInfo.ProductName;
                //if (msg == "Microphone (USB2.0 High-Speed T") waveInDefaultDevice = waveInDevice;
                results[waveInDevice] = msg;
            }
            return results;
        }

        public bool SetRecordingDevice(string name)
        {
            int waveInDevices = WaveIn.DeviceCount;
            string[] results = new string[waveInDevices];
            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                string msg = deviceInfo.ProductName;
                if (msg == name)
                {
                    UpdateWaveInDevice(waveInDevice);
                    return true;
                }
            }
            return false;
        }

        private void UpdateWaveInDevice(int waveInDeviceIndex)
        {
            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = waveInDeviceIndex;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (!recording) return; // in case we get sound because waveIn has not finished handling its own StopRecording()
            // english messages svp
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            //if (!watch.IsRunning) watch.Restart(); // timer restart
            int volumeWindowDurationInSamples = (int)(volumeWindowDurationInSeconds * sampleRate);
            
            // populate buffer
            for (int index = 0; index < e.BytesRecorded ; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                
                //do something with sample
                lastSampleId++;
                //if (lastSampleId >= recordedSamples.Length) lastSampleId = 0;
                lastSampleId = lastSampleId % recordedSamples.Length; // reset to 0 when required
                this.recordedSamples[lastSampleId] = sample;

                if (lastSampleId % volumeWindowDurationInSamples == 0) 
                { 
                    UpdateVolume();
                    CheckBounds(watch.ElapsedMilliseconds);
                }

            }
  
        }

        private void UpdateVolume()
        {
            //int numSamples = (int)(sampleRate * volumeWindowDurationInSeconds);
            //double bigtotal = 0;
            //for (int i = 0; i < numSamples; i++)
            //{
            //    int index = lastSampleId - i; 
            //    if (index < 0) index += numSamples;
            //
            //    bigtotal += Math.Abs((int)recordedSamples[index]) / 32768f;
            //}
            //volume = (short)(bigtotal / numSamples * 32768f);

            // my initial idea was to compute a sliding average
            // but pratice shows it's not workgin right. 
            // according to links below, using a sliding max make much more sense.
            // source : https://stackoverflow.com/questions/14350790/naudio-peak-volume-meter#14355006
            //          https://stackoverflow.com/questions/2445756/how-can-i-calculate-audio-db-level#9812267
            // let's use max of log10 values
            int numSamples = (int)(sampleRate * volumeWindowDurationInSeconds);
            int max = 0;
            for (int i = 0; i < numSamples; i++)
            {
                int index = lastSampleId - i; 
                if (index < 0) index += numSamples;
                int abs_sample = Math.Abs((int)recordedSamples[index]);
                if (abs_sample > max) max = abs_sample;
            }
            volume = max / 32768f;
            volume = 20 * Math.Log10(volume);
        }

        private void CheckBounds(long elapsedMilliseconds)
        {
            // send news to UI
            VolumeChangedEvent e = new VolumeChangedEvent(); 
            e.volume = volume;
            e.elapsedMilliSeconds = watch.ElapsedMilliseconds;
            if (VolumeChanged != null) VolumeChanged(this, e);
        }


    }
}
