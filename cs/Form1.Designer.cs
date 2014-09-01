namespace clap_clap
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.bufferLengthLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.silenceThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clapThresholdTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.soundDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.play = new System.Windows.Forms.Button();
            this.listenTextBox = new System.Windows.Forms.TextBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.riseTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buffer (ms)";
            // 
            // bufferLengthLabel
            // 
            this.bufferLengthLabel.AutoSize = true;
            this.bufferLengthLabel.Location = new System.Drawing.Point(137, 64);
            this.bufferLengthLabel.Name = "bufferLengthLabel";
            this.bufferLengthLabel.Size = new System.Drawing.Size(40, 17);
            this.bufferLengthLabel.TabIndex = 0;
            this.bufferLengthLabel.Text = "5000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Listen (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "silenceThreshold";
            // 
            // silenceThresholdTextBox
            // 
            this.silenceThresholdTextBox.Location = new System.Drawing.Point(361, 61);
            this.silenceThresholdTextBox.Name = "silenceThresholdTextBox";
            this.silenceThresholdTextBox.Size = new System.Drawing.Size(49, 22);
            this.silenceThresholdTextBox.TabIndex = 1;
            this.silenceThresholdTextBox.Text = "-20.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "clapThreshold";
            // 
            // clapThresholdTextBox
            // 
            this.clapThresholdTextBox.Location = new System.Drawing.Point(361, 85);
            this.clapThresholdTextBox.Name = "clapThresholdTextBox";
            this.clapThresholdTextBox.Size = new System.Drawing.Size(49, 22);
            this.clapThresholdTextBox.TabIndex = 1;
            this.clapThresholdTextBox.Text = "-3.0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(303, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // soundDevicesComboBox
            // 
            this.soundDevicesComboBox.FormattingEnabled = true;
            this.soundDevicesComboBox.Location = new System.Drawing.Point(26, 16);
            this.soundDevicesComboBox.Name = "soundDevicesComboBox";
            this.soundDevicesComboBox.Size = new System.Drawing.Size(315, 24);
            this.soundDevicesComboBox.TabIndex = 4;
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(361, 16);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(58, 24);
            this.play.TabIndex = 5;
            this.play.Text = "record";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // listenTextBox
            // 
            this.listenTextBox.Location = new System.Drawing.Point(136, 82);
            this.listenTextBox.Name = "listenTextBox";
            this.listenTextBox.Size = new System.Drawing.Size(49, 22);
            this.listenTextBox.TabIndex = 1;
            this.listenTextBox.Text = "50";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(365, 146);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(0, 17);
            this.volumeLabel.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            this.chart1.Location = new System.Drawing.Point(12, 183);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.Name = "volumes";
            series14.ChartArea = "ChartArea1";
            series14.Name = "claps";
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Size = new System.Drawing.Size(431, 129);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 329);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(431, 178);
            this.logTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "rise (ms)";
            // 
            // riseTextBox
            // 
            this.riseTextBox.Location = new System.Drawing.Point(361, 107);
            this.riseTextBox.Name = "riseTextBox";
            this.riseTextBox.Size = new System.Drawing.Size(49, 22);
            this.riseTextBox.TabIndex = 1;
            this.riseTextBox.Text = "200";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 519);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.soundDevicesComboBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listenTextBox);
            this.Controls.Add(this.riseTextBox);
            this.Controls.Add(this.clapThresholdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.silenceThresholdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bufferLengthLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ClapClap";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bufferLengthLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox silenceThresholdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox clapThresholdTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox soundDevicesComboBox;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.TextBox listenTextBox;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox riseTextBox;
    }
}

