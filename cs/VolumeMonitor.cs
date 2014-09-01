using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clap_clap
{
    class VolumeMonitor
    {

        public System.Collections.Generic.SynchronizedCollection<double> volumes; // in System.ServiceModel.dll; provides threadsafe collection
        public volatile short volumeIndex;
        public short totalVolumes;

        public double clapThreshold;
        public double silenceThreshold;



        public VolumeMonitor(short totalVolumes, double clapThreshold = 0.5, double silenceThreshold = 20) 
        {
            this.clapThreshold = clapThreshold;
            this.silenceThreshold = silenceThreshold;

            this.totalVolumes = totalVolumes;
            volumes = new System.Collections.Generic.SynchronizedCollection<double>();
            Flush();
        }

        public void Flush()
        {
            volumes.Clear();
            //for (int i = 0; i < totalVolumes; i++) { volumes.Add( 20 * Math.Log10(1/32768f)); }
            for (int i = 0; i < totalVolumes; i++) { volumes.Add(0); }
            volumeIndex = 0;
        }

        public void SetCurrentVolume(double volume)
        {
            volumeIndex++;
            if (volumeIndex >= totalVolumes) volumeIndex = 0;
            volumes[volumeIndex] = volume;
        }

        public double GetCurrentVolume()
        {
            return volumes[volumeIndex];
        }

    }
}
