using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clap_clap
{
    class ClapEvent : EventArgs { public long elapsedMilliSeconds { get; set; } };

    class VolumeMonitor
    {
        // to publish volume changed events 
        public delegate void ClapHandler(VolumeMonitor mon, ClapEvent e);
        public event ClapHandler ClapHandle;

        public System.Collections.Generic.SynchronizedCollection<double> volumes; // in System.ServiceModel.dll; provides threadsafe collection
        public System.Collections.Generic.SynchronizedCollection<double> claps; // in System.ServiceModel.dll; provides threadsafe collection
        public volatile short volumeIndex;
        public short totalVolumes;

        public double clapThreshold;
        public double silenceThreshold;

        public int risingEdgeThresholdInMilliSeconds;

        private long lastSilenceInMilliSeconds;

        enum Status
        {
            Silence,
            InBetween,
            Clap
        };
        private Status lastStatus;
        
        public VolumeMonitor(short totalVolumes, double clapThreshold = -0.1, 
            double silenceThreshold = -20, int risingEdgeThresholdInMilliSeconds = 1000) 
        {
            this.totalVolumes = totalVolumes;
            this.clapThreshold = clapThreshold;
            this.silenceThreshold = silenceThreshold;
            this.risingEdgeThresholdInMilliSeconds = risingEdgeThresholdInMilliSeconds;
            volumes = new System.Collections.Generic.SynchronizedCollection<double>();
            claps = new System.Collections.Generic.SynchronizedCollection<double>();
            Flush();
        }

        public void Flush()
        {
            volumes.Clear();
            //for (int i = 0; i < totalVolumes; i++) { volumes.Add( 20 * Math.Log10(1/32768f)); }
            for (int i = 0; i < totalVolumes; i++) { volumes.Add(0); claps.Add(0); }
            volumeIndex = 0;
            lastStatus = Status.Silence;
            lastSilenceInMilliSeconds = -1;
        }

        public void SetCurrentVolume(double volume, long elapsedMilliSeconds)
        {
            volumeIndex++;
            if (volumeIndex >= totalVolumes) volumeIndex = 0;
            volumes[volumeIndex] = volume;

            CheckBounds(elapsedMilliSeconds);


        }

        public double GetCurrentVolume()
        {
            return volumes[volumeIndex];
        }

        private void CheckBounds(long elapsedMilliseconds)
        {
            double vol = GetCurrentVolume();
            Status currentStatus = GetStatus(vol);
            claps[volumeIndex] = 0;
            if (currentStatus == Status.Silence) 
                lastSilenceInMilliSeconds = elapsedMilliseconds;
            if (currentStatus == Status.Clap
                && lastStatus != Status.Clap
                && lastSilenceInMilliSeconds > 0
                && elapsedMilliseconds - lastSilenceInMilliSeconds < risingEdgeThresholdInMilliSeconds)
            {
                // this is a clap!
                claps[volumeIndex] = 1;
                // send news to UI
                ClapEvent e = new ClapEvent(); e.elapsedMilliSeconds = elapsedMilliseconds;
                if (ClapHandle != null) ClapHandle(this, e);
            }
            lastStatus = currentStatus;

        }
        private Status GetStatus(double volume)
        {
            if (volume <= silenceThreshold) return Status.Silence;
            else if (volume >= clapThreshold) return Status.Clap;
            else return Status.InBetween;
        }


    }
}
