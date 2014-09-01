using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clap_clap
{
    public partial class Form1 : Form
    {
        SoundRecorder rec;

        
        // lowest possible sound value is
        // 20 * log10(1/32768f)
        // = -90.3089987
        // and highest would be 20 * log10(32768f/32768f) = 0
        // in practice, lowest value using sound card of my laptop is about 45
        // but it also depends on ambient sound...
        // hardcoded values then
        private int lowestSoundVolume = -25;

        public Form1()
        {
            // english messages pls
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            InitializeComponent();
            rec = new SoundRecorder();
            rec.VolumeChanged += OnVolumeChanged;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = -lowestSoundVolume;


            PopulateComboBox(rec.GetRecordingDevices());


        }

        private void play_Click(object sender, EventArgs e)
        {
            if (rec.IsRecording())
            {
                // we stop
                rec.StopRecording();
                EnableParams(true);
            }
            else
            {
                // let's (re)start 
                EnableParams(false);
                rec.SetRecordingDevice((string)soundDevicesComboBox.SelectedItem);
                rec.SetBufferProperties(
                    int.Parse(bufferLengthLabel.Text) / 1000.0,
                    int.Parse(listenTextBox.Text) / 1000.0,
                    (double)decimal.Parse(upperBoundTextBox.Text, System.Globalization.CultureInfo.InvariantCulture),
                    (double)decimal.Parse(lowerBoundTextBox.Text, System.Globalization.CultureInfo.InvariantCulture));
                rec.StartRecording();
            }
            
        }

        private void OnVolumeChanged(SoundRecorder rec, VolumeChangedEvent e)
        {
            progressBar1.BeginInvoke(new Action(() => { 
                int value = (int)e.volume;
                if (value > 0) value = 0;
                if (value < lowestSoundVolume) value = lowestSoundVolume;
                progressBar1.Value = -lowestSoundVolume + value; 
            }));
            volumeLabel.BeginInvoke(new Action(() => { volumeLabel.Text = "" + e.volume; })); 
            

        }

        private void EnableParams(bool enable)
        {
            play.Text = enable ? "record" : "stop";
            listenTextBox.Enabled = enable;
            lowerBoundTextBox.Enabled = enable;
            upperBoundTextBox.Enabled = enable;
            volumeLabel.Text = "";
            soundDevicesComboBox.Enabled = enable;
        }
        private void PopulateComboBox(string[] values)
        {
            soundDevicesComboBox.Items.Clear();
            if (values.Length <= 0) return;

            string defaultRecorder = "Microphone (2- USB2.0 High-Spee";
            bool found = false;
            foreach (string value in values) { 
                soundDevicesComboBox.Items.Add(value);
                // select default card if it exists
                found = found || (value == defaultRecorder);
            }

            if (found) soundDevicesComboBox.SelectedItem = defaultRecorder;
            else soundDevicesComboBox.SelectedItem = values[0];
        }




    }
}
